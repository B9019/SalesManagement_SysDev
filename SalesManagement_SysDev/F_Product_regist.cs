using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class F_Product_regist : Form
    {
        // ***** モジュール実装（よく使う他クラスで定義したメソッドが利用できるようあらかじめ実装します。）

        // 共通データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（項目処理）
        private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        // データベース処理モジュール（コードカウンター）
        private CodeCounterCommon _cc = new CodeCounterCommon();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        // メッセージ処理モジュール
        private Messages _ms = new Messages();

        // データベース処理モジュール（M_Division）
        private M_ProductContents _Pr = new M_ProductContents();

        // ***** プロパティ定義

        // トップフォーム
        public TopForm _topForm;

        // 選択行番号
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
        private IEnumerable<M_DispProduct> _dispDivisionPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispProduct> _dispDivisionPrinting;                 // 印刷用データ


        public F_Product_regist()
        {
            InitializeComponent();
        }

        private void F_Product_regist_Load(object sender, EventArgs e)
        {
            // **** ボタンのロック制御
            btn_search.Enabled = false;
            btn_regist.Enabled = true;
            btn_update.Enabled = false;
            btn_all.Enabled = true;
            btn_print.Enabled = true;
            btn_delete.Enabled = false;
            btn_clear.Enabled = true;

            // ****ロックされたボタンの表示変更
            btn_search.BackColor = Color.DarkGray;
            btn_update.BackColor = Color.DarkGray;
            btn_delete.BackColor = Color.DarkGray;

        }

        private void F_Product_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:   // 検索
                    if (btn_search.Enabled == true)
                        btn_search.PerformClick();
                    break;
                case Keys.F2:   //登録
                    if (btn_regist.Enabled == true)
                        btn_regist.PerformClick();
                    break;
                case Keys.F3:   //更新
                    if (btn_update.Enabled == true)
                        btn_update.PerformClick();
                    break;
                case Keys.F4:   //一覧表示
                    if (btn_all.Enabled == true)
                        btn_all.PerformClick();
                    break;
                case Keys.F5:   //印刷
                    if (btn_print.Enabled == true)
                        btn_print.PerformClick();
                    break;
                case Keys.F6:   //削除
                    if (btn_delete.Enabled == true)
                        btn_delete.PerformClick();
                    break;
                case Keys.F7:   //入力クリア
                    if (btn_clear.Enabled == true)
                        btn_clear.PerformClick();
                    break;
            }
        }
        // 登録ボタン
        // 4.1商品情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 4.1.1妥当な商品情報取得
            if (!Get_Product_Data_AtRegistration())
                return;

            // 4.1.2妥当な商品情報作成
            var regProduct = Generate_Data_AtRegistration();

            // 4.1.3商品情報登録
            if (!Generate_Registration(regProduct))
                return;


        }

        // 
        //
        //4.1.1　妥当な商品データ取得（新規登録）
        //
        //
        private bool Get_Product_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////
            
            // メーカID
            if (String.IsNullOrEmpty(txt_MaID.Text))
            {
                MessageBox.Show("メーカIDは必須項目です");
                MaID.Focus();
                return false;
            }
            // 商品ID
            if (String.IsNullOrEmpty(txt_PrID.Text))
            {
                MessageBox.Show("商品IDは必須項目です");
                txt_PrID.Focus();
                return false;
            }
            // 商品名
            if (String.IsNullOrEmpty(txt_PrName.Text))
            {
                MessageBox.Show("商品名は必須項目です");
                txt_PrName.Focus();
                return false;
            }
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 小分類ID
            if (String.IsNullOrEmpty(txt_ScID.Text))
            {
                MessageBox.Show("小分類IDは必須項目です");
                txt_ScID.Focus();
                return false;
            }
            // 型番
            if (String.IsNullOrEmpty(txt_PrModelNumber.Text))
            {
                MessageBox.Show("型番は必須項目です");
                txt_PrModelNumber.Focus();
                return false;
            }
            //　色
            if (String.IsNullOrEmpty(txt_PrColor.Text))
            {
                MessageBox.Show("色は必須項目です");
                txt_PrColor.Focus();
                return false;
            }
            // 発売日
            if (String.IsNullOrEmpty(txt_PrReleaseDate.Text))
            {
                MessageBox.Show("発売日は必須項目です");
                txt_PrReleaseDate.Focus();
                return false;
            }
            //　価格
            if (String.IsNullOrEmpty(txt_Price.Text))
            {
                MessageBox.Show("価格は必須項目です");
                txt_Price.Focus();
                return false;
            }
            //　安全在庫数
            if (String.IsNullOrEmpty(txt_PrSafetyStock.Text))
            {
                MessageBox.Show("安全在庫数は必須項目です");
                txt_PrSafetyStock.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////
            
            // メーカID
            if (!_ic.NumericCheck(txt_MaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_MaID.Focus();
                return false;
            }
            //　商品ID
            if (!_ic.NumericCheck(txt_PrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }
            // 安全在庫数
            if (!_ic.NumericCheck(txt_PrSafetyStock.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrSafetyStock.Focus();
                return false;
            }
            //  小分類ID
            if (!_ic.NumericCheck(txt_ScID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_MaID.Focus();
                return false;
            }
            // 型番
            if (!_ic.NumericCheck(txt_PrModelNumber.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrModelNumber.Focus();
                return false;
            }
            // 価格
            if (!_ic.NumericCheck(txt_Price.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Price.Focus();
                return false;
            }
            
            ////　文字チェック ////
            
            //　商品名
            if (!_ic.FullWidthCharCheck(txt_PrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }
            // 　JANコードの文字チェック
            if (!_ic.FullWidthCharCheck(txt_PrJCode.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }
            //　色の文字チェック
            if (!_ic.FullWidthCharCheck(txt_PrColor.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrColor.Focus();
                return false;
            }
            // 　備考の文字チェック
            if (!_ic.FullWidthCharCheck(txt_memo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_memo.Focus();
                return false;
            }

            /////文字数チェック/////
            // メーカID
            if (txt_MaID.TextLength > 50)
            {
                MessageBox.Show("メーカIDは4文字以下です");
                MaID.Focus();
                return false;
            }
            // 商品ID
            if (txt_PrID.TextLength >4)
            {
                MessageBox.Show("商品IDは4文字以下です");
                txt_PrID.Focus();
                return false;
            }
            // 商品名
            if(txt_PrName.TextLength > 50)
            {
                MessageBox.Show("商品名は50文字以下です");
                txt_PrName.Focus();
                return false;
            }
            //　JANコード
            if (txt_PrJCode.TextLength > 13)
            {
                MessageBox.Show("JANコードは13文字以下です");         
                txt_PrJCode.Focus();
                return false;
            }
            // 小分類ID
            if (txt_ScID.TextLength > 2)
            {
                MessageBox.Show("小分類IDは2文字以下です");
                txt_ScID.Focus();
                return false;
            }
            // 型番
            if (txt_PrModelNumber.TextLength > 20)
            {
                MessageBox.Show("型番は20文字以下です");
                txt_PrModelNumber.Focus();
                return false;
            }
            //　色
            if (txt_PrColor.TextLength > 20)
            {
                MessageBox.Show("色は20文字以下です");
                txt_PrColor.Focus();
                return false;
            }
            //　価格
            if (txt_Price.TextLength > 9)
            {
                MessageBox.Show("価格は9文字以下です");
                txt_Price.Focus();
                return false;
            }
            //　安全在庫数
            if (txt_PrSafetyStock.TextLength > 4)
            {
                MessageBox.Show("安全在庫数は4文字以下です");
                txt_PrSafetyStock.Focus();
                return false;
            }
            // 備考の適否
            if (txt_memo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_memo.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 4.1.2 商品情報作成
        //
        //
        private M_Product Generate_Data_AtRegistration()
        {
            return new M_Product
            {
                PrID = int.Parse(txt_PrID.Text),
                MaID = int.Parse(txt_MaID.Text),
                PrName = txt_PrName.Text,
                Price = int.Parse(txt_Price.Text),
                PrJCode = txt_PrJCode.Text,
                PrSafetyStock = int.Parse(txt_PrSafetyStock.Text),
                ScID = int.Parse(txt_ScID.Text),
                PrModelNumber = int.Parse(txt_PrModelNumber.Text),
                PrColor = txt_PrColor.Text,
                PrReleaseDate = DateTime.Parse(txt_PrReleaseDate.Text),
                PrFlag = 0,
                PrMemo = txt_memo.Text

            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(M_Product regProduct)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Pr.PostM_Division(regProduct);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_MaID.Focus();

            return true;

        }


    }
}
