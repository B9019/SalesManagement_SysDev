using MetroFramework.Forms;
using SalesManagement_SysDev.Model.ContentsManagement;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class F_Order : MetroForm
    {
        public int transfer_int;//権限変数

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

        //// データベース処理モジュール（T_Order）
        private T_OrderContents _Or = new T_OrderContents();
        private T_ChumonContents _Ch = new T_ChumonContents();


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
        private IEnumerable<T_DispOrder> _dispOrderPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispOrder> _dispOrderPrinting;                 // 印刷用データ

        int HIDEFlag;
        int ComitFlag;
        int rdChID;
        DateTime chdate;

        //int OrIDneiv;       //注文管理画面に情報を映す際の変数
        //int SoIDneiv;
        //int EmIDneiv;
        //int ClIDneiv;
        //string ClChargeneiv;
        //DateTime OrDateneiv;
        //int OrStateFlagneiv;
        //int OrFlagneiv;
        //string OrHiddenneiv;


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
            HIDEFlag = 0;
            ComitFlag = 0;
            dataGridView_Order.ColumnCount = 10;

            dataGridView_Order.Columns[0].HeaderText = "受注ID ";
            dataGridView_Order.Columns[1].HeaderText = "営業所ID ";
            dataGridView_Order.Columns[2].HeaderText = "社員ID ";
            dataGridView_Order.Columns[3].HeaderText = "顧客ID";
            dataGridView_Order.Columns[4].HeaderText = "顧客担当者名";
            dataGridView_Order.Columns[5].HeaderText = "受注年月日";
            dataGridView_Order.Columns[6].HeaderText = "受注状態フラグ";
            dataGridView_Order.Columns[7].HeaderText = "受注管理フラグ";
            dataGridView_Order.Columns[8].HeaderText = "非表示理由";
            dataGridView_Order.Columns[9].HeaderText = "備考";

            dataGridView_Order_Detail.ColumnCount = 5;

            dataGridView_Order_Detail.Columns[0].HeaderText = "受注詳細ID";
            dataGridView_Order_Detail.Columns[1].HeaderText = "受注ID";
            dataGridView_Order_Detail.Columns[2].HeaderText = "商品ID";
            dataGridView_Order_Detail.Columns[3].HeaderText = "数量";
            dataGridView_Order_Detail.Columns[4].HeaderText = "合計金額";

            dataGridView_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView_Order_Detail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            //F_login f_login = new F_login();
            //F_home f_home = new F_home();
            ////transfer_int = f_home.transfer_int;
            //transfer_int = f_home.transfer_int;

            btn_delete.Enabled = false;

            if (transfer_int == 1 ||
               transfer_int == 5)
            {
                btn_delete.Enabled = true;
            }

            //OrIDneiv = 0;           //注文管理画面にデータを移す際の変数をロード時に初期化
            //SoIDneiv = 0;
            //EmIDneiv = 0;
            //ClIDneiv = 0;
            //ClChargeneiv = "";
            //OrDateneiv = DateTime.Now;
            //OrStateFlagneiv  = 0;
            //OrFlagneiv = 0;
            //OrHiddenneiv = "";

            loginauthor();
        }

        private bool loginauthor()
        {
            using (SalesManagement_DevContext dbContext = new SalesManagement_DevContext())
            {
                var loresult = dbContext.M_Employees
                    .Where(e => e.EmID == transfer_int)
                    .ToArray();
                foreach (var item in loresult)
                {
                    txt_loginSoID.Text = (item.SoID).ToString();
                    txt_loginEmID.Text = (item.EmID).ToString();
                }
                return true;
            }
        }

            // 登録ボタン
            // 8.1受注情報登録
            private void btn_regist_Click(object sender, EventArgs e)
            {
                if (chk_order.Checked == true)//受注登録
                {
                    if (!Get_Order_Data_AtRegistration())
                        return;
                    var regOrder = Generate_Data_AtRegistration();
                    if (!Generate_Registration(regOrder))
                        return;
                }
                else if (chk_orderdetail.Checked == true)//受注詳細登録
                {
                    if (!Get_Order_Detail_Data_AtRegistration())
                        return;
                    var regOrderDetail = Generate_Data_AtRegistration_Detail();
                    if (!Generate_Registration_Detail(regOrderDetail))
                        return;
                }
                //else if (chk_commit_FLG.Checked == true)//確定処理
                //{
                //    Get_Chumon_Data_AtRegistration();
                //}
            }
        private void btn_commit_FLG_Click(object sender, EventArgs e)
        {
            Get_Chumon_Data_AtRegistration();//確定処理

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
                ////　文字チェック ////

                //　顧客担当者名の文字チェック
                if (!_ic.FullWidthCharCheck(txt_ClCharge.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_ClCharge.Focus();
                    return false;
                }
                //日付チェック
                // 　受注年月日の文字チェック
                if (!_ic.DateFormCheck(txt_OrDate.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrDate.Focus();
                    return false;
                }

                /////文字数チェック/////
                // 受注ID
                if (txt_OrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です");
                    txt_OrID.Focus();
                    return false;
                }
                // 営業所ID
                if (txt_SoID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2字以下です");
                    txt_SoID.Focus();
                    return false;
                }
                // 社員ID
                if (txt_EmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字以下です");
                    txt_EmID.Focus();
                    return false;
                }
                //　顧客ID
                if (txt_ClID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字以下です");
                    txt_ClID.Focus();
                    return false;
                }
                // 顧客担当者名
                if (txt_ClCharge.TextLength > 50)
                {
                    MessageBox.Show("顧客担当者名は50文字以下です");
                    txt_ClCharge.Focus();
                    return false;
                }
                // 受注年月日
                if (txt_OrDate.TextLength > 10)
                {
                    MessageBox.Show("受注年月日は10文字以下です");
                    txt_OrDate.Focus();
                    return false;
                }
                return true;
            }
            private bool Get_Order_Detail_Data_AtRegistration()
            {
                // 受注データの形式チェック
                string errorMessage = string.Empty;

                ///// 入力内容の適否 /////

                //　受注詳細ID
                if (String.IsNullOrEmpty(txt_OrDetailID.Text))
                {
                    MessageBox.Show("受注詳細IDは必須項目です");
                    txt_OrDetailID.Focus();
                    return false;
                }
                // 受注ID
                if (String.IsNullOrEmpty(txt_OrID2.Text))
                {
                    MessageBox.Show("受注IDは必須項目です");
                    txt_OrID.Focus();
                    return false;
                }
                //　商品ID
                if (String.IsNullOrEmpty(txt_PrID.Text))
                {
                    MessageBox.Show("商品IDは必須項目です");
                    txt_PrID.Focus();
                    return false;
                }
                //　数量
                if (String.IsNullOrEmpty(txt_OrQuantity.Text))
                {
                    MessageBox.Show("数量は必須項目です");
                    txt_OrQuantity.Focus();
                    return false;
                }
                //　合計金額
                if (String.IsNullOrEmpty(txt_OrTotalPrice.Text))
                {
                    MessageBox.Show("合計金額は必須項目です");
                    txt_OrTotalPrice.Focus();
                    return false;
                }

                ///// 入力内容の形式チェック /////

                //// 数値チェック ////

                // 受注詳細ID
                if (!_ic.NumericCheck(txt_OrDetailID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrDetailID.Focus();
                    return false;
                }
                // 商品ID
                if (!_ic.NumericCheck(txt_PrID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_PrID.Focus();
                    return false;
                }
                // 数量
                if (!_ic.NumericCheck(txt_OrQuantity.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrQuantity.Focus();
                    return false;
                }
                // 合計金額
                if (!_ic.NumericCheck(txt_OrTotalPrice.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrTotalPrice.Focus();
                    return false;
                }
                ///文字数チェック
                // 受注詳細ID
                if (txt_OrDetailID.TextLength > 6)
                {
                    MessageBox.Show("受注詳細IDは6文字以下です");
                    txt_OrDetailID.Focus();
                    return false;
                }
                // 商品ID
                if (txt_PrID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です");
                    txt_PrID.Focus();
                    return false;
                }
                // 数量
                if (txt_OrQuantity.TextLength > 4)
                {
                    MessageBox.Show("数量は4文字以下です");
                    txt_OrQuantity.Focus();
                    return false;
                }
                // 合計金額
                if (txt_OrTotalPrice.TextLength > 10)
                {
                    MessageBox.Show("合計金額は10文字以下です");
                    txt_OrTotalPrice.Focus();
                    return false;
                }
                return true;
            }

            //
            //
            // 8.1.2 受注情報作成,注文情報作成
            //
            //
            private T_Order Generate_Data_AtRegistration()
            {
                if (chk_hide_FLG.Checked == false)
                {
                    txt_OrHidden.Text = "";
                }
                return new T_Order
                {
                    OrID = int.Parse(txt_OrID.Text),
                    SoID = int.Parse(txt_SoID.Text),
                    EmID = int.Parse(txt_EmID.Text),
                    ClID = int.Parse(txt_ClID.Text),
                    ClCharge = txt_ClCharge.Text,
                    OrDate = DateTime.Now,
                    OrStateFlag = 0,
                    OrFlag = 0,
                    OrHidden = txt_OrHidden.Text,
                };

            }
            private T_OrderDetail Generate_Data_AtRegistration_Detail()
            {
                return new T_OrderDetail
                {
                    OrDetailID = int.Parse(txt_OrDetailID.Text),
                    OrID = int.Parse(txt_OrID2.Text),
                    PrID = int.Parse(txt_PrID.Text),
                    OrQuantity = int.Parse(txt_OrQuantity.Text),
                    OrTotalPrice = int.Parse(txt_OrTotalPrice.Text)
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
                // 商品情報の登録
                var errorMessage = _Or.PostT_Order(regOrder);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }
                //// 画面更新
                fncAllSelect();
                txt_OrID.Focus();

                return true;

            }
            private bool Generate_Registration_Detail(T_OrderDetail regOrderDetail)
            {
                // 登録可否
                if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }
                // 商品情報の登録
                var errorMessage = _Or.PostT_OrderDetail(regOrderDetail);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }
                //// 画面更新
                fncAllSelect();
                txt_OrID.Focus();
                return true;

            }
            private bool Get_Chumon_Data_AtRegistration()
            {               
            //受注情報を注文テーブルに送る
                int id = int.Parse(txt_OrID.Text);
                using (SalesManagement_DevContext dbContext = new SalesManagement_DevContext())
                {
                    var result = dbContext.T_Orders
                        .Where(o => o.OrID == id).GroupJoin(
                        dbContext.T_Chumons,
                        o => o.OrID,
                        c => c.OrID,
                        (o, c) => new { o.SoID, o.ClID, o.OrFlag, o.OrID })
                        .ToArray();
                foreach (var item in result)
                {
                    var regChumon = new T_Chumon()
                        {
                            SoID = item.SoID,
                            EmID = null,
                            ClID = item.ClID,
                            OrID = item.OrID,
                            ChDate = null,
                            ChStateFlag = 0,
                            ChFlag = 0,
                            ChHidden = txt_OrHidden.Text
                        };
                        // 注文情報の登録
                        var errorMessage = _Ch.PostT_Chumon(regChumon);

                        if (errorMessage != string.Empty)
                        {
                            MessageBox.Show(errorMessage);
                            return false;
                        }
                }
            var chresult = dbContext.T_Chumons
                        .Where(c => c.OrID == id)
                        .ToArray();
                    foreach (var item in chresult)
                    {
                        var regChumonDetail = new T_ChumonDetail()
                        {
                            ChID = item.ChID,
                            PrID = int.Parse(txt_PrID.Text),
                            ChQuantity = int.Parse(txt_OrQuantity.Text)
                        };
                        // 注文情報の登録
                        var errorMessage = _Ch.PostT_ChumonDetail(regChumonDetail);

                        if (errorMessage != string.Empty)
                        {
                            MessageBox.Show(errorMessage);
                            return false;
                        }
                    }
                    //// 画面更新
                    fncAllSelect();
                    txt_OrID.Focus();
                    return true;
                }
            }
            //private bool Generate_Registration_Chumon(T_Chumon regChumon)
            //{
            //    // 商品情報の登録
            //    var errorMessage = _Ch.PostT_Chumon(regChumon);

            //    if (errorMessage != string.Empty)
            //    {
            //        MessageBox.Show(errorMessage);
            //        return false;
            //    }
            //    //// 画面更新
            //    RefreshDataGridView();
            //    return true;

            //}
            //private bool Generate_Registration_ChumonDetail(T_ChumonDetail regChumonDetail)
            //{
            //    // 商品情報の登録
            //    var errorMessage = _Ch.PostT_ChumonDetail(regChumonDetail);

            //    if (errorMessage != string.Empty)
            //    {
            //        MessageBox.Show(errorMessage);
            //        return false;
            //    }
            //    //// 画面更新
            //    RefreshDataGridView();
            //    return true;

            //}



            //// 表示データ更新
            //private void RefreshDataGridView()
            //{
            //    // スクロール位置取得
            //    int ScrollPosition = dataGridView_Order.FirstDisplayedScrollingRowIndex;

            //    // データ取得&表示（データバインド）
            //    _dispOrderPaging = _Or.GetDispOrders();
            //    dataGridView_Order.DataSource = _dispOrderPaging;

            //    // 全データ数取得
            //    _recordCount = _dispOrderPaging.Count();

            //    // スクロール位置セット
            //    if (0 < ScrollPosition) dataGridView_Order.FirstDisplayedScrollingRowIndex = ScrollPosition;

            //    // 入力クリア
            //    ClearInput();

            //    // ページング初期化
            //    ClearPaging();

            //}

            // 更新ボタン
            // 4.2 受注情報更新
            private void btn_update_Click(object sender, EventArgs e)
            {
                if (chk_order.Checked == true)
                {
                    // 4.2.1 妥当な受注データ取得
                    if (!GetValidDataAtUpdate()) return;
                    // 4.2.2 受注情報作成
                    var regOrder = GenerateDataAtUpdate();
                    // 4.2.3 受注情報更新
                    OrderUpdate(regOrder);
                    return;
                }
                else if (chk_orderdetail.Checked == true)
                {
                    // 4.2.1 妥当な受注データ取得
                    if (!GetValidDataAtUpdate()) return;
                    var regOrderDetail = GenerateDataAtUpdate_Detail();
                    OrderUpdateDetail(regOrderDetail);
                    return;
                }
                //else if(chk_commit_FLG.Enabled == true)
                //{
                //    // 8.1.1妥当な受注情報取得
                //    if (!GetValidDataAtUpdate()) return;

                //    // 8.1.2妥当な受注情報作成
                //    var regChumon = Generate_Data_AtRegistration_Chumon();
                //    // 8.1.3受注情報登録
                //    if (!Generate_Registration_Chumon(regChumon)) 
                //        return;
                //    // 8.1.2妥当な受注詳細情報作成
                //    var regChumonDetail = Generate_Data_AtRegistration_Detail_Chumon();
                //    // 8.1.3受注詳細情報登録
                //        if (!Generate_Registration_ChumonDetail(regChumonDetail))
                //            return;
                //}
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

                // 受注ID
                if (String.IsNullOrEmpty(txt_OrID.Text))
                {
                    MessageBox.Show("受注IDは必須項目です");
                    txt_OrID2.Focus();
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
                ///// 入力内容の形式チェック /////

                //// 数値チェック ////

                // 受注ID
                if (!_ic.NumericCheck(txt_OrID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrID2.Focus();
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
                // 受注詳細ID
                if (!_ic.NumericCheck(txt_OrDetailID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrDetailID.Focus();
                    return false;
                }
                // 商品ID
                if (!_ic.NumericCheck(txt_PrID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_PrID.Focus();
                    return false;
                }
                // 数量
                if (!_ic.NumericCheck(txt_OrQuantity.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrQuantity.Focus();
                    return false;
                }
                // 合計金額
                if (!_ic.NumericCheck(txt_OrTotalPrice.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrTotalPrice.Focus();
                    return false;
                }
                ////　文字チェック ////

                //　顧客担当者名の文字チェック
                if (!_ic.FullWidthCharCheck(txt_ClCharge.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_ClCharge.Focus();
                    return false;
                }
                // 　受注年月日の文字チェック
                if (!_ic.FullWidthCharCheck(txt_OrDate.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_OrDate.Focus();
                    return false;
                }

                /////文字数チェック/////
                // 受注ID
                if (txt_OrID.TextLength > 6)
                {
                    MessageBox.Show("受注IDは6文字以下です");
                    txt_OrID2.Focus();
                    return false;
                }
                // 営業所ID
                if (txt_SoID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2字以下です");
                    txt_SoID.Focus();
                    return false;
                }
                // 社員ID
                if (txt_EmID.TextLength > 6)
                {
                    MessageBox.Show("社員IDは6文字以下です");
                    txt_EmID.Focus();
                    return false;
                }
                //　顧客ID
                if (txt_ClID.TextLength > 6)
                {
                    MessageBox.Show("顧客IDは6文字以下です");
                    txt_ClID.Focus();
                    return false;
                }
                // 顧客担当者名
                if (txt_ClCharge.TextLength > 50)
                {
                    MessageBox.Show("顧客担当者名は50文字以下です");
                    txt_ClCharge.Focus();
                    return false;
                }
                // 受注年月日
                if (txt_OrDate.TextLength > 10)
                {
                    MessageBox.Show("受注年月日は10文字以下です");
                    txt_OrDate.Focus();
                    return false;
                }
                // 受注詳細ID
                if (txt_OrDetailID.TextLength > 6)
                {
                    MessageBox.Show("受注詳細IDは6文字以下です");
                    txt_OrDetailID.Focus();
                    return false;
                }
                // 商品ID
                if (txt_PrID.TextLength > 6)
                {
                    MessageBox.Show("商品IDは6文字以下です");
                    txt_PrID.Focus();
                    return false;
                }
                // 数量
                if (txt_OrQuantity.TextLength > 4)
                {
                    MessageBox.Show("数量は4文字以下です");
                    txt_OrQuantity.Focus();
                    return false;
                }
                // 合計金額
                if (txt_OrTotalPrice.TextLength > 10)
                {
                    MessageBox.Show("合計金額は10文字以下です");
                    txt_OrTotalPrice.Focus();
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
            private T_Order GenerateDataAtUpdate()
            {
                if (chk_hide_FLG.Checked == false)
                {
                    txt_OrHidden.Text = "";
                }

                if (chk_hide_FLG.Checked == true)
                {
                    HIDEFlag = 1;
                }
                else
                {
                    HIDEFlag = 0;
                }

                if (btn_commit_FLG.Enabled == true)
                {
                    ComitFlag = 1;
                }
                else
                {
                    ComitFlag = 0;
                }
                return new T_Order
                {
                    OrID = int.Parse(txt_OrID.Text),
                    SoID = int.Parse(txt_SoID.Text),
                    EmID = int.Parse(txt_EmID.Text),
                    ClID = int.Parse(txt_ClID.Text),
                    ClCharge = txt_ClCharge.Text,
                    OrDate = DateTime.Now,
                    OrStateFlag = ComitFlag,
                    OrFlag = HIDEFlag,
                    OrHidden = txt_OrHidden.Text,

                };
            }
            private T_OrderDetail GenerateDataAtUpdate_Detail()
            {
                return new T_OrderDetail
                {
                    OrDetailID = int.Parse(txt_OrDetailID.Text),
                    OrID = int.Parse(txt_OrID2.Text),
                    PrID = int.Parse(txt_PrID.Text),
                    OrQuantity = int.Parse(txt_OrQuantity.Text),
                    OrTotalPrice = int.Parse(txt_OrTotalPrice.Text)
                };

            }
            //private T_Chumon Generate_Data_AtRegistration_Chumon()
            //{
            //    chdate = DateTime.Now;

            //    return new T_Chumon
            //    {
            //        //ChID = int.Parse(txt_OrID.Text),
            //        SoID = int.Parse(txt_SoID.Text),
            //        ClID = int.Parse(txt_ClID.Text),
            //        OrID = int.Parse(txt_OrID2.Text),
            //        ChDate = chdate,
            //        ChStateFlag = 0,

            //    };
            //}
            //private T_ChumonDetail Generate_Data_AtRegistration_Detail_Chumon()
            //{            //接続先DBの情報をセット
            //    SqlConnection conn = new SqlConnection();
            //    SqlCommand command = new SqlCommand();
            //    conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";
            //    //実行するSQL文の指定
            //    command.CommandText = @"SELECT ChID from T_Chumon WHERE ChDate LIKE @ChDate;";
            //    command.Connection = conn;
            //    //sql文のwhere句の接続に使う
            //    //検索条件をテキストボックスから抽出し、SQL文をセット
            //    //　日本語可　：SqlDbType.NVarChar
            //    //　日本語不可：SqlDbType.VarChar
            //    command.Parameters.Add("@ChDate", SqlDbType.VarChar);
            //    command.Parameters["@ChDate"].Value = chdate;
            //    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
            //    //{
            //    //    command.CommandText = command + "AND ";
            //    //}
            //    //実行するSQL文の条件追加
            //    try
            //    {
            //        //データベースに接続
            //        conn.Open();
            //        //SQL文の実行、データが  readerに格納される
            //        SqlDataReader rd = command.ExecuteReader();
            //        if (rd.HasRows)
            //        {
            //            while (rd.Read())
            //            {
            //                rdChID = rd.GetInt32(rd.GetOrdinal("ChID"));
            //            }
            //        }
            //    }
            //    finally
            //    {
            //        //データベースを切断
            //        conn.Close();
            //    }

            //    return new T_ChumonDetail
            //    {
            //        //ChDetailID = int.Parse(txt_OrDetailID.Text),
            //        ChID = rdChID,
            //        PrID = int.Parse(txt_PrID.Text),
            //        ChQuantity = int.Parse(txt_OrQuantity.Text),
            //    };
            //}

            //
            //
            // 4.2.3 商品情報更新
            //
            //
            private bool OrderUpdate(T_Order regOrder)
            {
                // 更新可否
                if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }

                var errorMessage = _Or.PutOrder(regOrder);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }

                // 表示データ更新 & 入力クリア
                RefreshDataGridView();
                txt_OrID2.Focus();

                return true;
            }
            private bool OrderUpdateDetail(T_OrderDetail regOrderDetail)
            {
                // 更新可否
                if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }

                var errorMessage = _Or.PutOrderDetail(regOrderDetail);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }

                // 表示データ更新 & 入力クリア
                RefreshDataGridView();
                txt_OrID2.Focus();

                return true;
            }


            private void btn_search_Click(object sender, EventArgs e)
            {
                //接続先DBの情報をセット
                SqlConnection conn = new SqlConnection();
                SqlCommand command = new SqlCommand();
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //実行するSQL文の指定
                command.CommandText = @"SELECT * FROM T_Order WHERE ";
                command.Connection = conn;

                //sql文のwhere句の接続に使う
                string AND = "";
                int andnum = 0;
                //検索条件をテキストボックスから抽出し、SQL文をセット
                //　日本語可　：SqlDbType.NVarChar
                //　日本語不可：SqlDbType.VarChar
                for (int count = 0; count < 8; count++)
                {
                    if (txt_OrID2.Text != "" && count == 0)
                    {
                        command.Parameters.Add("@OrID", SqlDbType.VarChar);
                        command.Parameters["@OrID"].Value = txt_OrID2.Text;
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + "OrID LIKE @OrID ";
                        ++andnum;

                    }
                    else if (txt_SoID.Text != "" && count == 1)
                    {
                        command.Parameters.Add("@SoID", SqlDbType.VarChar);
                        command.Parameters["@SoID"].Value = txt_SoID.Text;
                        //if ("@SoID" != null)
                        //{
                        //    command.CommandText = command + "AND ";
                        //}
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "SoID LIKE @SoID ";
                        ++andnum;
                    }
                    else if (txt_EmID.Text != "" && count == 2)
                    {
                        command.Parameters.Add("@EmID", SqlDbType.NVarChar);
                        command.Parameters["@EmID"].Value = "%" + txt_EmID.Text + "%";
                        //if ("@OrID" != null || "@SoID" != null)
                        //{
                        //    command.CommandText = command + "AND ";
                        //}
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "EmID LIKE @EmID ";
                        ++andnum;
                    }
                    else if (txt_ClID.Text != "" && count == 3)
                    {
                        command.Parameters.Add("@ClID", SqlDbType.VarChar);
                        command.Parameters["@ClID"].Value = txt_ClID.Text;
                        //if ("@OrID" != null || "@SoID" != null || "@ClID" != null)
                        //{
                        //    command.CommandText = command + "AND ";
                        //}
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "ClID LIKE @ClID ";
                        ++andnum;
                    }
                    else if (txt_ClCharge.Text != "" && count == 4)
                    {
                        command.Parameters.Add("@ClCharge", SqlDbType.VarChar);
                        command.Parameters["@ClCharge"].Value = "%" + txt_ClCharge.Text + "%";
                        //if ("@OrID" != null || "@SoID" != null || "@ClID" != null || "@ClCharge" != null)
                        //{
                        //    command.CommandText = command + "AND ";
                        //}
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "ClCharge LIKE @ClCharge ";
                        ++andnum;
                    }
                    else if (txt_OrDate.Text != "" && count == 5)
                    {
                        command.Parameters.Add("@OrDate", SqlDbType.VarChar);
                        command.Parameters["@PrReleaseDate"].Value = "%" + txt_OrDate.Text + "%";
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "OrDate LIKE @OrDate ";
                        ++andnum;
                    }
                    else if (txt_OrHidden.Text != "" && count == 6)
                    {
                        command.Parameters.Add("@PrHidden", SqlDbType.NVarChar);
                        command.Parameters["@PrHidden"].Value = "%" + txt_OrHidden.Text + "%";
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "PrHidden LIKE @PrHidden ";
                        ++andnum;
                    }
                    else if (count == 7)
                    {
                        command.Parameters.Add("@OrFlag", SqlDbType.NVarChar);
                        command.Parameters["@OrFlag"].Value = HIDEFlag;
                        //実行するSQL文の条件追加
                        command.CommandText = command.CommandText + AND + "OrFlag LIKE @OrFlag ";
                        ++andnum;
                    }
                    //2つ目以降の条件の前部にANDを接続
                    if (andnum != 0)
                    {
                        AND = "AND ";
                    }
                    //最後にセミコロンを接続する
                    while (count == 7)
                    {
                        command.CommandText = command.CommandText + ";";
                        break;
                    }

                }
                try
                {
                    //データベースに接続
                    conn.Open();
                    //SQL文の実行、データが  readerに格納される
                    SqlDataReader rd = command.ExecuteReader();
                    dataGridView_Order.Rows.Clear();


                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            dataGridView_Order.Rows.Add(rd["OrID"], rd["SoID"], rd["EmID"], rd["ClID"],
                                rd["ClCharge"], rd["OrDate"],
                                rd["OrHidden"], rd["memo"]);
                        }
                    }
                }
                finally
                {
                    //データベースを切断
                    conn.Close();
                }


            }
            // 削除ボタン
            // 4.3 商品情報削除
            private void btn_delete_Click(object sender, EventArgs e)
            {
                // データ行番号を取得
                int OrID = int.Parse(txt_OrID2.Text);
                using (var dcm = new DeleteConfirmForm())
                {
                    // 確認後、削除実行
                    if (dcm.ShowDialog(this) == DialogResult.OK) Delete(OrID);
                }

                // 表示データ更新 & 入力クリア
                RefreshDataGridView();
            }

            // 削除処理
            // in      ChID: 削除するChID
            private void Delete(int OrID)
            {
                // _it.DeletePrID(int.Parse(PrID));
                _Or.DeleteOrder(OrID);

                // データ取得&表示
                dataGridView_Order.DataSource = _Or.GetDispOrder();
            }




            // 入力クリア
            internal void ClearInput()
            {
                // 表示モード設定
                dataGridView_Order.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // データグリッド選択解除
                dataGridView_Order.ClearSelection();

                // テキストボックス＆コンボボックスクリア
                txt_OrID2.Clear();
                txt_SoID.Clear();
                txt_EmID.Clear();
                txt_ClID.Clear();
                txt_ClCharge.Clear();
                txt_OrDate.Clear();
                txt_OrHidden.Clear();


                //// ボタンリセット
                //btn_regist.Enabled = true;
                //buttonUpdate.Enabled = false;
                //buttonDelete.Enabled = false;

                // コード改変無効処置リセット
                //txt_MaID.Enabled = false;

                // 入力フォーカスリセット
                txt_OrID2.Focus();
            }

            // 表示データ更新
            private void RefreshDataGridView()
            {
                // スクロール位置取得
                int ScrollPosition = dataGridView_Order.FirstDisplayedScrollingRowIndex;

                // データ取得&表示（データバインド）
                _dispOrderPaging = _Or.GetDispOrder();
                dataGridView_Order.DataSource = _dispOrderPaging;

                // 全データ数取得
                _recordCount = _dispOrderPaging.Count();

                // スクロール位置セット
                if (0 < ScrollPosition) dataGridView_Order.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
                fncAllSelect();
            }
            private void fncAllSelect()
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand command = new SqlCommand();
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //command.Parameters.Add("@PrFlag", SqlDbType.VarChar);
                //command.Parameters["@PrFlag"].Value = "0";
                command.CommandText = "SELECT * FROM T_Order WHERE OrFlag = 0;";
                command.Connection = conn;
                conn.Open();
                SqlDataReader rd = command.ExecuteReader();
                dataGridView_Order.Rows.Clear();
                while (rd.Read())
                {
                    dataGridView_Order.Rows.Add(rd["OrID"], rd["SoID"], rd["EmID"], rd["ClID"],
                        rd["ClCharge"], rd["OrDate"], rd["OrStateFlag"], rd["OrFlag"],
                        rd["OrHidden"]);
                }
            dataGridView_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SqlConnection conn2 = new SqlConnection();
                SqlCommand command2 = new SqlCommand();
                conn2.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //command.Parameters.Add("@PrFlag", SqlDbType.VarChar);
                //command.Parameters["@PrFlag"].Value = "0";
                command2.CommandText = "SELECT * FROM T_OrderDetail;";
                command2.Connection = conn2;
                conn2.Open();
                SqlDataReader rd2 = command2.ExecuteReader();
                dataGridView_Order_Detail.Rows.Clear();
                while (rd2.Read())
                {
                    dataGridView_Order_Detail.Rows.Add(rd2["OrDetailID"], rd2["OrID"], rd2["PrID"], rd2["OrQuantity"], rd2["OrTotalPrice"]);
                }
            dataGridView_Order_Detail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //// データ取得&表示（データバインド）
            //_dispProductPaging = _Pr.GetDispProducts();
            //dataGridView_Product.DataSource = _dispProductPaging;

            ////全データの表示
            //dataGridView_Product.Rows.Clear();
            //try
            //{
            //    var context = new SalesManagement_DevContext();
            //    foreach (var p in context.M_Products)
            //    {
            //        dataGridView_Product.Rows.Add(p.PrID, p.MaID, p.PrName, p.Price,p.PrJCode,p.);
            //    }
            //    context.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Order_regist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                int id = (int)dataGridView_Order.CurrentRow.Cells[0].Value;
                int id2 = (int)dataGridView_Order.CurrentRow.Cells[1].Value;
                int id3 = (int)dataGridView_Order.CurrentRow.Cells[2].Value;
                int id4 = (int)dataGridView_Order.CurrentRow.Cells[3].Value;
                string id5 = (string)dataGridView_Order.CurrentRow.Cells[4].Value;
                DateTime id6 = (DateTime)dataGridView_Order.CurrentRow.Cells[5].Value;
                int id7 = (int)dataGridView_Order.CurrentRow.Cells[6].Value;
                int id8 = (int)dataGridView_Order.CurrentRow.Cells[7].Value;
                string id9 = (string)dataGridView_Order.CurrentRow.Cells[8].Value;

                txt_OrID.Text = Convert.ToString(id);
                txt_SoID.Text = Convert.ToString(id2);
                txt_EmID.Text = Convert.ToString(id3);
                txt_ClID.Text = Convert.ToString(id4);
                txt_ClCharge.Text = Convert.ToString(id5);
                txt_OrDate.Text = Convert.ToString(id6);
                txt_OrHidden.Text = Convert.ToString(id9);
            }
            private void dataGridView_Order_Detail_regist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                int Dt = (int)dataGridView_Order_Detail.CurrentRow.Cells[0].Value;
                int Dt1 = (int)dataGridView_Order_Detail.CurrentRow.Cells[1].Value;
                int Dt2 = (int)dataGridView_Order_Detail.CurrentRow.Cells[2].Value;
                int Dt3 = (int)dataGridView_Order_Detail.CurrentRow.Cells[3].Value;
                int Dt4 = (int)dataGridView_Order_Detail.CurrentRow.Cells[4].Value;

                txt_OrDetailID.Text = Convert.ToString(Dt);
                txt_OrID2.Text = Convert.ToString(Dt1);
                txt_PrID.Text = Convert.ToString(Dt2);
                txt_OrQuantity.Text = Convert.ToString(Dt3);
                txt_OrTotalPrice.Text = Convert.ToString(Dt4);
            }

            private void Checked_Order_HideFlag(object sender, EventArgs e)
            {
                if (chk_hide_FLG.Checked == true)
                {
                    txt_OrHidden.Text = "";
                    HIDEFlag = 1;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
                }
                else if (chk_hide_FLG.Checked == false)
                {
                    txt_OrHidden.Text = "非表示理由を入力(50文字)";
                    HIDEFlag = 0;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
                }
                return;

            }
            private void identity()
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand command = new SqlCommand();
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";
                //command.Parameters.Add("@PrFlag", SqlDbType.VarChar);
                //command.Parameters["@PrFlag"].Value = "0";
                command.CommandText = "SELECT ";
                command.Connection = conn;
                conn.Open();
                SqlDataReader rd = command.ExecuteReader();

            }

            private void btn_chumon_Click(object sender, EventArgs e)
            {

            }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
    }

