using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.ContentsManagement;
using SalesManagement_SysDev.Model.Entity.Disp;
using System.Data.SqlClient;

namespace SalesManagement_SysDev
{
    public partial class F_Arrival : Form
    {
        // ***** モジュール実装（よく使う他クラスで定義したメソッドが利用できるようあらかじめ実装します。）

        // 共通データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        //// データベース処理モジュール（項目処理）
        //private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        //// データベース処理モジュール（コードカウンター）
        //private CodeCounterCommon _cc = new CodeCounterCommon();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        //// メッセージ処理モジュール
        private Messages _ms = new Messages();

        //// データベース処理モジュール（M_Division）
        private T_ArrivalContents _Pr = new T_ArrivalContents();

        // ***** プロパティ定義

        //// トップフォーム
        public F_home f_home;

        //// 選択行番号
        private int _lineNo;

        // バージョン管理
        // データベースからデータを読み込んだ時の時間を管理します。
        // 後にデータベースに書き込む時、異なるバージョンのデータ（読み込んだデータが既に他者によって書き換えられている）
        // だった場合、書き込みは失敗します。（楽観的同時実行制御）
        private byte[] _timeStamp;

        // ページング関係プロパティ
        private int _pageCountPaging;                                       // 全表示ページ数
        private int _recordCount;                                           // 全表示データ数
        private int _pageSizePaging;                                        // １ページ表示データ行数
        private int _currentPage;                                           // 現在のページ
        private int _recordNo;                                              // ページ先頭位置のデータ（スタートデータ）
        private IEnumerable<T_DispArrival> _dispArrivalPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispArrival> _dispArrivalPrinting;                 // 印刷用データ

        public F_Arrival()
        {
            InitializeComponent();
        }

        private void F_Arrival_Load(object sender, EventArgs e)
        {
            入荷管理ToolStripMenuItem.Enabled = false;
            dataGridView_Arrival.ColumnCount = 9;

            dataGridView_Arrival.Columns[0].HeaderText = "入荷ID ";
            dataGridView_Arrival.Columns[1].HeaderText = "営業所ID ";
            dataGridView_Arrival.Columns[2].HeaderText = "社員ID ";
            dataGridView_Arrival.Columns[3].HeaderText = "顧客ID";
            dataGridView_Arrival.Columns[4].HeaderText = "受注ID";
            dataGridView_Arrival.Columns[5].HeaderText = " 入荷年月日";
            dataGridView_Arrival.Columns[6].HeaderText = "非表示理由";
            dataGridView_Arrival.Columns[7].HeaderText = "備考";
            dataGridView_Arrival.Columns[8].HeaderText = "入荷失敗フラグ";

        }
        // 登録ボタン
        //11.1入荷情報登録

        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 11.1.1妥当な入荷情報取得
            if (!Get_Arrival_Data_AtRegistration())
                return;

            // 11.1.2妥当な入荷情報作成
            var regArrival = Generate_Data_AtRegistration();

            // 11.1.3入荷情報登録
            if (!Generate_Registration(regArrival))
                return;

        }
        // 
        //
        //11.1.1　妥当な入荷データ取得（新規登録）
        //
        //
        private bool Get_Arrival_Data_AtRegistration()
        {
            // 入荷データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 入荷ID
            if (String.IsNullOrEmpty(txt_ArID.Text))
            {
                MessageBox.Show("入荷IDは必須項目です");
                ArID.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
            {
                MessageBox.Show("顧客IDは必須項目です");
                txt_ClID.Focus();
                return false;
            }
            //　入荷年月日
            if (String.IsNullOrEmpty(txt_ArDate.Text))
            {
                MessageBox.Show("入荷年月日は必須項目です");
                txt_ArDate.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 入荷ID
            if (!_ic.NumericCheck(txt_ArID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ArID.Focus();
                return false;
            }
            //　営業所ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            //  顧客ID
            if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClID.Focus();
                return false;
            }
            // 受注ID
            if (!_ic.NumericCheck(txt_OrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrID.Focus();
                return false;
            }

            ////　文字チェック ////

            //　備考
            if (!_ic.FullWidthCharCheck(txt_Armemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Armemo.Focus();
                return false;
            }
            // 　非表示理由の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ArHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ArHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 入荷ID
            if (txt_ArID.TextLength > 6)
            {
                MessageBox.Show("メーカIDは6文字以下です");
                txt_ArID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("商品IDは2文字以下です");
                txt_SoID.Focus();
                return false;
            }
            // 社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("商品名は6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            //　顧客ID
            if (txt_ClID.TextLength > 4)
            {
                MessageBox.Show("JANコードは4文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("小分類IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 入荷年月日
            if (txt_ArDate.TextLength > 9)
            {
                MessageBox.Show("型番は9文字以下です");
                txt_ArDate.Focus();
                return false;
            }
            //　備考
            if (txt_Armemo.TextLength > 30)
            {
                MessageBox.Show("色は30文字以下です");
                txt_Armemo.Focus();
                return false;
            }
            //　非表示理由
            if (txt_ArHidden.TextLength > 30)
            {
                MessageBox.Show("価格は30文字以下です");
                txt_ArHidden.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 11.1.2 入荷情報作成
        //
        //
        private T_Arrival Generate_Data_AtRegistration()
        {
            return new T_Arrival
            {
                ArID = int.Parse(txt_ArID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                ArDate = DateTime.Parse(txt_ArDate.Text),
                Armemo= txt_Armemo.Text,
                ArHidden = txt_ArHidden.Text,

            };

        }
        //
        //
        // 11.1.3　入荷情報登録
        //
        //
        private bool Generate_Registration(T_Arrival regArrival)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 入荷情報の登録
            var errorMessage = _Ar.PostT_Arrival(regArrival);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_ArID.Focus();

            return true;

        }
        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Arrival.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispArrivalPaging = _Pr.GetDispArrivals();
            dataGridView_Arrival.DataSource = _dispArrivalPaging;

            // 全データ数取得
            _recordCount = _dispArrivalPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Arrival.FirstDisplayedScrollingRowIndex = ScrollPosition;

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();

        }
        // ページング初期化
        private void ClearPaging()
        {
            //// ページサイズ初期化（全行表示）
            //textBoxPageSize.Text = "0";
            //_pageSizePaging = Convert.ToInt32(textBoxPageSize.Text);
            //_recordCount = _dispItemPaging.Count();
            _pageCountPaging = 1;

            // 表示ページ＆ページトップデータ初期化
            _currentPage = 1;
            _recordNo = 0;
        }
        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Arrival.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Arrival.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_ArID.Clear();
            txt_SoID.Clear();
            txt_EmID.Clear();
            txt_ClID.Clear();
            txt_OrID.Clear();
            txt_ArDate.Clear();
            txt_Armemo.Clear();
            txt_ArHidden.Clear();
            chk_hide_FLG.Checked = false;

            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_ArID.Focus();
        }



    }
}
