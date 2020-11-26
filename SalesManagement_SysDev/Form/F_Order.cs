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
        private M_OrderContents _Pr = new M_OrderContents();

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
        //4.1.1　妥当な受注データ取得（新規登録）
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
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
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
            // 非表示理由
            if (String.IsNullOrEmpty(txt_OrHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_OrHidden.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_PrName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }
            // 　JANコードの文字チェック
            if (!_ic.FullWidthCharCheck(txt_PrJCode.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrJCode.Focus();
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
            if (txt_PrID.TextLength > 4)
            {
                MessageBox.Show("商品IDは4文字以下です");
                txt_PrID.Focus();
                return false;
            }
            // 商品名
            if (txt_PrName.TextLength > 50)
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
            var errorMessage = _Pr.PostM_Product(regProduct);

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
