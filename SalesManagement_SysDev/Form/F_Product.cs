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
using System.Data.Entity.Core.Common.CommandTrees;

namespace SalesManagement_SysDev
{
    public partial class F_Product : Form
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
        private M_ProductContents _Pr = new M_ProductContents();

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
        private IEnumerable<M_DispProduct> _dispProductPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispProduct> _dispProductPrinting;                 // 印刷用データ

        public F_Product()
        {
            InitializeComponent();
        }
        private void F_Product_Load(object sender, EventArgs e)
        {
            商品管理ToolStripMenuItem.Enabled = false;
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

        // 更新ボタン
        // 4.2 商品情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 4.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate()) return;

            // 4.2.2 商品情報作成
            var regProduct = GenerateDataAtUpdate();

            // 4.2.3 商品情報更新
            ProductUpdate(regProduct);

        }
        //
        //
        // 5.3.2.1 妥当な商品データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
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
        // 4.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private M_Product GenerateDataAtUpdate()
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
        // 4.2.3 商品情報更新
        //
        //
        private bool ProductUpdate(M_Product regProduct)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Pr.PutProduct(regProduct);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_MaID.Focus();

            return true;
        }

        // 削除ボタン
        // 4.3 商品情報削除
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int PrID = int.Parse(txt_PrID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(PrID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        // 削除処理
        // in       PrID : 削除するPrID
        private void Delete(int PrID)
        {
            // _it.DeletePrID(int.Parse(PrID));
            _Pr.DeleteProduct(PrID);

            // データ取得&表示
            dataGridView_Product_regist.DataSource = _Pr.GetDispProducts();
        }




        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Product_regist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Product_regist.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_MaID.Clear();
            txt_PrID.Clear();
            txt_PrName.Clear();
            txt_ScID.Clear();
            txt_PrModelNumber.Clear();
            txt_PrColor.Clear();
            txt_PrReleaseDate.Clear();
            txt_Price.Clear();
            txt_PrSafetyStock.Clear();
            txt_PrJCode.Clear();
            txt_memo.Clear();
            txt_PrHidden.Clear();
            chk_PrHidden.Checked = false;

            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_MaID.Focus();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Product_regist.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispProductPaging = _Pr.GetDispProducts();
            dataGridView_Product_regist.DataSource = _dispProductPaging;

            // 全データ数取得
            _recordCount = _dispProductPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Product_regist.FirstDisplayedScrollingRowIndex = ScrollPosition;

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





        private void ログイン管理toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_login form_login = new F_login();
            form_login.ShowDialog();
        }

        private void 顧客管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Client form_client = new F_Client();
            form_client.ShowDialog();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Product form_product = new F_Product();
            form_product.ShowDialog();

        }

        private void 受注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Order form_order = new F_Order();
            form_order.ShowDialog();

        }

        private void 注文管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Chumon form_chumon = new F_Chumon();
            form_chumon.ShowDialog();

        }

        private void 入荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Arrival form_arrival = new F_Arrival();
            form_arrival.ShowDialog();

        }

        private void 出荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Shipment form_shipment = new F_Shipment();
            form_shipment.ShowDialog();

        }

        private void 在庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Stock form_stock = new F_Stock();
            form_stock.ShowDialog();

        }

        private void 入庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Warehousing form_warehousing = new F_Warehousing();
            form_warehousing.ShowDialog();
        }

        private void 出庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Syukko form_syukko = new F_Syukko();
            form_syukko.ShowDialog();

        }

        private void 社員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Employee form_employee = new F_Employee();
            form_employee.ShowDialog();

        }

        private void 売上管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Sale form_sale = new F_Sale();
            form_sale.ShowDialog();

        }

        private void 発注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Hattyu form_hattyu = new F_Hattyu();
            form_hattyu.ShowDialog();

        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Product_regist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Product_regist.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Product_regist.CurrentRow.Cells[1].Value;
            string id3 = (string)dataGridView_Product_regist.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Product_regist.CurrentRow.Cells[3].Value;
            string id5 = (string)dataGridView_Product_regist.CurrentRow.Cells[4].Value;
            int id6 = (int)dataGridView_Product_regist.CurrentRow.Cells[5].Value;
            int id7 = (int)dataGridView_Product_regist.CurrentRow.Cells[6].Value;
            int id8 = (int)dataGridView_Product_regist.CurrentRow.Cells[7].Value;
            string id9 = (string)dataGridView_Product_regist.CurrentRow.Cells[8].Value;
            DateTime id10 = (DateTime)dataGridView_Product_regist.CurrentRow.Cells[9].Value;
            int id11 = (int)dataGridView_Product_regist.CurrentRow.Cells[10].Value;
            string id12 = (string)dataGridView_Product_regist.CurrentRow.Cells[11].Value;
            string id13 = (string)dataGridView_Product_regist.CurrentRow.Cells[12].Value;

            txt_PrID.Text = Convert.ToString(id);
            txt_MaID.Text = Convert.ToString(id2);
            txt_PrName.Text = Convert.ToString(id3);
            txt_Price.Text = Convert.ToString(id4);
            txt_PrJCode.Text = Convert.ToString(id5);
            txt_PrSafetyStock.Text = Convert.ToString(id6);
            txt_ScID.Text = Convert.ToString(id7);
            txt_PrModelNumber.Text = Convert.ToString(id8);
            txt_PrColor.Text = Convert.ToString(id9);
            txt_PrReleaseDate.Text = Convert.ToString(id10);
            chk_PrHidden.Checked = Convert.ToBoolean(id11);
            txt_PrHidden.Text = Convert.ToString(id12);
            txt_memo.Text = Convert.ToString(id13);

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=M__Product;";

            //実行するSQL文の指定
            command.CommandText = "@SELECT * FROM M_Product WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            //検索条件をテキストボックスから抽出し、SQL文をセット
            for (int count = 0; count < 11; ++count)
            {
                if (PrID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@PrID", SqlDbType.VarChar);
                    command.Parameters["@PrID"].Value = PrID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command + "PrID LIKE @PrID ";

                }
                else if (MaID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@MaID", SqlDbType.VarChar);
                    command.Parameters["@MaID"].Value = MaID.Text;
                    //if ("@PrID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "MaID LIKE @MaID ";

                }
                else if (PrName.Text != "" && count == 2)
                {
                    command.Parameters.Add("@PrName", SqlDbType.VarChar);
                    command.Parameters["@PrName"].Value = "%" + PrName.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrName LIKE @PrName ";

                }
                else if (Price.Text != "" && count == 3)
                {
                    command.Parameters.Add("@Price", SqlDbType.VarChar);
                    command.Parameters["@Price"].Value = Price.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "Price LIKE @Price ";

                }
                else if (PrJCode.Text != "" && count == 4)
                {
                    command.Parameters.Add("@PrJCode", SqlDbType.VarChar);
                    command.Parameters["@PrJCode"].Value = "%" + PrJCode.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrJCode LIKE @PrJCode ";

                }
                else if (PrSafetyStock.Text != "" && count == 5)
                {
                    command.Parameters.Add("@PrSafetyStock", SqlDbType.VarChar);
                    command.Parameters["@PrSafetyStock"].Value = PrSafetyStock.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrSafetyStock LIKE @PrSafetyStock ";

                }
                else if (ScID.Text != "" && count == 6)
                {
                    command.Parameters.Add("@ScID", SqlDbType.VarChar);
                    command.Parameters["@ScID"].Value = ScID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "ScID LIKE @ScID ";

                }
                else if (PrModelNumber.Text != "" && count == 7)
                {
                    command.Parameters.Add("@PrModelNumber", SqlDbType.VarChar);
                    command.Parameters["@PrModelNumber"].Value = PrModelNumber.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command + "PrModelNumber LIKE @PrModelNumber ";

                }
                else if (PrColor.Text != "" && count == 8)
                {
                    command.Parameters.Add("@PrColor", SqlDbType.VarChar);
                    command.Parameters["@PrColor"].Value = "%" + PrColor.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrColor LIKE @PrColor ";

                }
                else if (PrReleaseDate.Text != "" && count == 9)
                {
                    command.Parameters.Add("@PrReleaseDate", SqlDbType.VarChar);
                    command.Parameters["@PrReleaseDate"].Value = "%" + PrReleaseDate.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrReleaseDate LIKE @PrReleaseDate ";

                }
                else if (PrHidden.Text != "" && count == 10)
                {
                    command.Parameters.Add("@PrHidden", SqlDbType.VarChar);
                    command.Parameters["@PrHidden"].Value = "%" + PrHidden.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command + AND + "PrHidden LIKE @PrHidden ";

                }
                //2つ目以降の条件の前部にANDを接続
                if (AND == "" && "@PrID" != null || "@MaID" != null || "@Price" != null ||
                    "@PrJCode" != null || "@PrSafetyStock" != null || "@ScID" != null ||
                    "@PrModelNumber" != null || "@PrColor" != null || "@PrReleaseDate" != null || "@PrHidden" != null)
                {
                    command.CommandText = command + "AND ";
                }

            }
            try
            {
                //データベースに接続
                conn.Open();
                //SQL文の実行、データが  readerに格納される
                SqlDataReader reader = command.ExecuteReader();

                if()
                {

                }

            }
            finally
            {
                //データベースを切断
                conn.Close();
            }

        }
    }
}




    
