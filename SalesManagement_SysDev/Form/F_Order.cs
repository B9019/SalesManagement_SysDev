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
using MetroFramework.Forms;

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

        //// データベース処理モジュール（T_Division）
        private T_OrderContents _Or = new T_OrderContents();

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

            dataGridView_Order.ColumnCount = 7;

            dataGridView_Order.Columns[0].HeaderText = "受注ID ";
            dataGridView_Order.Columns[1].HeaderText = "営業所ID ";
            dataGridView_Order.Columns[2].HeaderText = "社員ID ";
            dataGridView_Order.Columns[3].HeaderText = "顧客ID";
            dataGridView_Order.Columns[4].HeaderText = "受注年月日";
            dataGridView_Order.Columns[5].HeaderText = "非表示理由";
            dataGridView_Order.Columns[6].HeaderText = "備考";

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
                OrDate = DateTime.Parse(txt_OrDate.Text),
                OrHidden = txt_OrHidden.Text,
            };

        }
        //
        //
        // 4.1.3　商品情報登録
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
            //RefreshDataGridView();
            txt_OrID.Focus();

            return true;

        }
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
        // 4.2 商品情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 4.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate()) return;

            // 4.2.2 商品情報作成
            var regOrder = GenerateDataAtUpdate();

            // 4.2.3 商品情報更新
            OrderUpdate(regOrder);

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
        //
        //
        // 4.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private T_Order GenerateDataAtUpdate()
        {
            return new T_Order
            {
                OrID = int.Parse(txt_OrID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                ClCharge = txt_ClCharge.Text,
                OrDate = DateTime.Parse(txt_OrDate.Text),
                OrHidden = txt_OrHidden.Text,

            };
        }
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
            txt_OrID.Focus();

            return true;
        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Order WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 9; count++)
            {
                if (txt_OrID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@OrID", SqlDbType.VarChar);
                    command.Parameters["@OrID"].Value = txt_OrID.Text;
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
                else if (txt_OrDate.Text != "" && count == 9)
                {
                    command.Parameters.Add("@OrDate", SqlDbType.VarChar);
                    command.Parameters["@PrReleaseDate"].Value = "%" + txt_OrDate.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "OrDate LIKE @OrDate ";
                    ++andnum;
                }
                else if (txt_OrHidden.Text != "" && count == 10)
                {
                    command.Parameters.Add("@PrHidden", SqlDbType.NVarChar);
                    command.Parameters["@PrHidden"].Value = "%" + txt_OrHidden.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrHidden LIKE @PrHidden ";
                    ++andnum;
                }
                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 10)
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
            int OrID = int.Parse(txt_OrID.Text);
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
            txt_OrID.Clear();
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
            txt_OrID.Focus();
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
            RefreshDataGridView();
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
            string id7 = (string)dataGridView_Order.CurrentRow.Cells[6].Value;
            string id8 = (string)dataGridView_Order.CurrentRow.Cells[7].Value;

            txt_OrID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_ClID.Text = Convert.ToString(id4);
            txt_ClCharge.Text = Convert.ToString(id5);
            txt_OrDate.Text = Convert.ToString(id6);
            txt_OrHidden.Text = Convert.ToString(id7);
            txt_memo.Text = Convert.ToString(id8);

        }

        private void F_Order_Load_1(object sender, EventArgs e)
        {

        }
    }
}
