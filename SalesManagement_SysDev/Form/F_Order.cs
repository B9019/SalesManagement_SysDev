using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.ContentsManagement;
using SalesManagement_SysDev.Model.Entity.Disp;

namespace SalesManagement_SysDev
{
    public partial class F_Order : Form
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
        private T_OrderContents _Pr = new T_OrderContents();

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
        private IEnumerable<T_DispOrder> _disOrderPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispOrder> _dispOrderPrinting;                 // 印刷用データ
        public F_Order()
        {
            InitializeComponent();
        }

        private void txt_OrID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SoID_TextChanged(object sender, EventArgs e)
        {

        }

        private void F_Order_Load(object sender, EventArgs e)
        {
            受注管理ToolStripMenuItem.Enabled = false;
        }

        // 登録ボタン
        // 8.1受注情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 8.1.1妥当な受注情報取得
            if (!Get_Order_Data_AtRegistration())
                return;

            // 8.1.2妥当な受注情報作成
            var regOrder = Generate_Data_AtRegistration();

            // 8.1.3受注情報登録
            if (!Generate_Registration(regOrder))
                return;
        }
        // 
        //
        //8.1.1　妥当な受注データ取得（新規登録）
        //
        //
        private bool Get_Order_Data_AtRegistration()
        {
            // 受注データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            //// 営業所ID
            //if (String.IsNullOrEmpty(txt_SoID.Text))
            //{
            //    MessageBox.Show("営業所IDは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
            {
                MessageBox.Show("顧客IDは必須項目です");
                txt_ClID.Focus();
                return false;
            }
            // 顧客担当者名
            if (String.IsNullOrEmpty(txt_ClCharge.Text))
            {
                MessageBox.Show("顧客担当者名は必須項目です");
                txt_ClCharge.Focus();
                return false;
            }
            //　受注年月日
            if (String.IsNullOrEmpty(txt_OrDate.Text))
            {
                MessageBox.Show("受注年月日は必須項目です");
                txt_OrDate.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 受注ID
            if (!_ic.NumericCheck(txt_OrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrID.Focus();
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
            // 顧客担当者名
            if (!_ic.NumericCheck(txt_ClCharge.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClCharge.Focus();
                return false;
            }
            // 受注年月日
            if (!_ic.NumericCheck(txt_OrDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrDate.Focus();
                return false;
            }

            ////　文字チェック ////

            //　顧客担当者名
            if (!_ic.FullWidthCharCheck(txt_ClCharge.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClCharge.Focus();
                return false;
            }
            // 　受注年月日
            if (!_ic.FullWidthCharCheck(txt_OrDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrDate.Focus();
                return false;
            }

            /////文字数チェック/////
            // 受注ID
            if (txt_OrID.TextLength > 50)
            {
                MessageBox.Show("受注IDは4文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 4)
            {
                MessageBox.Show("SoIDは4文字以下です");
                txt_SoID.Focus();
                return false;
            }
            // 社員ID
            if (txt_EmID.TextLength > 50)
            {
                MessageBox.Show("社員IDは50文字以下です");
                txt_EmID.Focus();
                return false;
            }
            //　顧客ID
            if (txt_ClID.TextLength > 13)
            {
                MessageBox.Show("ClIDは13文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 顧客担当者名
            if (txt_ClCharge.TextLength > 2)
            {
                MessageBox.Show("顧客担当者名は2文字以下です");
                txt_ClCharge.Focus();
                return false;
            }
            // 受注年月日
            if (txt_OrDate.TextLength > 20)
            {
                MessageBox.Show("受注年月日は20文字以下です");
                txt_OrDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 8.1.2 受注情報作成
        //
        //
        private T_Order Generate_Data_AtRegistration()
        {
            return new T_Order
            {
                OrID = int.Parse(txt_OrID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                ClCharge = txt_ClCharge.Text,
                OrFlag = 0,
            };

        }
        //
        //
        // 8.1.3　受注情報登録
        //
        //
        private bool Generate_Registration(T_Order regOrder)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 受注情報の登録
            var errorMessage = _Pr.PostT_Order(regOrder);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            txt_OrID.Focus();

            return true;

        }

        }

}