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
    public partial class F_Client : MetroForm
    {
        public int transfer_int;
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
        private M_ClientContents _Cl = new M_ClientContents();

        // ***** プロパティ定義

        //// トップフォーム
        public F_home f_home;

        //F_login f_login = new F_login();
        //F_Arrival f_arrival = new F_Arrival();
        //F_Chumon f_chumon = new F_Chumon();
        //F_Client f_client = new F_Client();
        //F_Employee f_employee = new F_Employee();
        //F_Hattyu f_hattyu = new F_Hattyu();
        //F_Order f_order = new F_Order();
        //F_Product f_product = new F_Product();
        //F_Sale f_sale = new F_Sale();
        //F_Shipment f_shipment = new F_Shipment();
        //F_Stock f_stock = new F_Stock();
        //F_Syukko f_syukko = new F_Syukko();
        //F_Warehousing f_warehousing = new F_Warehousing();



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
        private IEnumerable<M_DispClient> _dispClientPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispClient> _dispClientPrinting;                 // 印刷用データ
        int HIDEFlag;

        public F_Client()
        {
            InitializeComponent();
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void F_Client_Load_1(object sender, EventArgs e)
        {
            btn_client.Enabled = false;
            dataGridView_Client.ColumnCount = 9;

            dataGridView_Client.Columns[0].HeaderText = "顧客ID ";
            dataGridView_Client.Columns[1].HeaderText = "営業所ID ";
            dataGridView_Client.Columns[2].HeaderText = "顧客名 ";
            dataGridView_Client.Columns[3].HeaderText = "住所";
            dataGridView_Client.Columns[4].HeaderText = "電話番号";
            dataGridView_Client.Columns[5].HeaderText = "郵便番号 ";
            dataGridView_Client.Columns[6].HeaderText = "FAX";
            dataGridView_Client.Columns[7].HeaderText = "顧客管理フラグ";
            dataGridView_Client.Columns[8].HeaderText = "非表示理由";
           

            F_login f_login = new F_login();
            transfer_int = f_login.transfer_int;

            btn_delete.Enabled = false;

            if (transfer_int == 1 ||
               transfer_int == 5)
            {
                btn_delete.Enabled = true;
            }
            HIDEFlag = 0;
        }


        // 登録ボタン
        // 3.1顧客情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 3.1.1妥当な顧客情報取得
            if (!Get_Client_Data_AtRegistration())
                return;

            // 3.1.2妥当な顧客情報作成
            var regClient = Generate_Data_AtRegistration();

            // 3.1.3顧客情報登録
            if (!Generate_Registration(regClient))
                return;

        }
        // 
        //
        //3.1.1　妥当な顧客データ取得（新規登録）
        //
        //
        private bool Get_Client_Data_AtRegistration()
        {
            // 顧客データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
            {
                MessageBox.Show("顧客IDは必須項目です");
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 顧客名
            if (String.IsNullOrEmpty(txt_ClName.Text))
            {
                MessageBox.Show("顧客名は必須項目です");
                txt_ClName.Focus();
                return false;
            }
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 住所
            if (String.IsNullOrEmpty(txt_ClAddress.Text))
            {
                MessageBox.Show("住所は必須項目です");
                txt_ClAddress.Focus();
                return false;
            }
            // 電話番号
            if (String.IsNullOrEmpty(txt_ClPhone.Text))
            {
                MessageBox.Show("電話番号は必須項目です");
                txt_ClPhone.Focus();
                return false;
            }
            //　郵便番号
            if (String.IsNullOrEmpty(txt_ClPostal.Text))
            {
                MessageBox.Show("郵便番号は必須項目です");
                txt_ClPostal.Focus();
                return false;
            }
            // FAX
            if (String.IsNullOrEmpty(txt_ClFAX.Text))
            {
                MessageBox.Show("FAXは必須項目です");
                txt_ClFAX.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 顧客ID
            if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClID.Focus();
                return false;
            }
            //　営業所ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 郵便番号
            if (!_ic.PostNoCheck(txt_ClPostal.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClPostal.Focus();
                return false;
            }

            ////　文字チェック ////

            //　顧客名の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ClName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClName.Focus();
                return false;
            }
            // 　住所の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ClAddress.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClAddress.Focus();
                return false;
            }
            //　電話番号の文字チェック
            if (!_ic.PhoneNoCheck(txt_ClPhone.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClPhone.Focus();
                return false;
            }
            // 　FAXの文字チェック
            if (!_ic.HalfCharCheck(txt_ClFAX.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClFAX.Focus();
                return false;
            }
            // 非表示理由
            if (!_ic.FullWidthCharCheck(txt_ClHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClHidden.Focus();
                return false;
            }


            /////文字数チェック/////
            // 顧客ID
            if (txt_ClID.TextLength > 4)
            {
                MessageBox.Show("顧客IDは4文字以下で入力してください");
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下で入力してください");
                txt_SoID.Focus();
                return false;
            }
            // 顧客名
            if (txt_ClName.TextLength > 50)
            {
                MessageBox.Show("顧客名は50文字以下で入力してください");
                txt_ClName.Focus();
                return false;
            }
            //　住所
            if (txt_ClAddress.TextLength > 50)
            {
                MessageBox.Show("住所は50文字以下で入力してください");
                txt_ClAddress.Focus();
                return false;
            }
            // 電話番号
            if (txt_ClPhone.TextLength > 13)
            {
                MessageBox.Show("電話番号は11文字以下で入力してください");
                txt_ClPhone.Focus();
                return false;
            }
            // 郵便番号
            if (txt_ClPostal.TextLength > 7)
            {
                MessageBox.Show("郵便番号は7文字以下で入力してください");
                txt_ClPostal.Focus();
                return false;
            }
            //　FAX
            if (txt_ClFAX.TextLength >13)
            {
                MessageBox.Show("FAXは20文字以下で入力してください");
                txt_ClFAX.Focus();
                return false;
            }
            //　非表示理由
            if (txt_ClHidden.TextLength > 30)
            {
                MessageBox.Show("非表示は30文字以下で入力してください");
                txt_ClHidden.Focus();
                return false;
            }

            return true;
        }
        //
        //
        // 3.1.2 顧客情報作成
        //
        //
        private M_Client Generate_Data_AtRegistration()
        {
            if (chk_hide_FLG.Checked == false)
            {
                txt_ClHidden.Text = "";
            }

            return new M_Client
            {
                ClID = int.Parse(txt_ClID.Text),
                SoID = int.Parse(txt_SoID.Text),
                ClName = txt_ClName.Text,
                ClAddress = txt_ClAddress.Text,
                ClPhone = txt_ClPhone.Text,
                ClPostal = int.Parse(txt_ClPostal.Text),
                ClFAX = txt_ClFAX.Text,
                ClFlag = 0,
                ClHidden = txt_ClHidden.Text,

            };

        }
        //
        //
        // 3.1.3　顧客情報登録
        //
        //
        private bool Generate_Registration(M_Client regClient)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Cl.PostM_Client(regClient);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_ClID.Focus();

            return true;

        }
        // 更新ボタン
        // 3.2 顧客情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 3.2.1 妥当な顧客データ取得
            if (!GetValidDataAtUpdate()) return;

            // 3.2.2 顧客情報作成
            var regClient = GenerateDataAtUpdate();

            // 3.2.3 顧客情報更新
            ClientUpdate(regClient);

        }

        //
        //
        // 5.3.2.1 妥当な商品データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 顧客データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
            {
                MessageBox.Show("顧客IDは必須項目です");
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 顧客名
            if (String.IsNullOrEmpty(txt_ClName.Text))
            {
                MessageBox.Show("顧客名は必須項目です");
                txt_ClName.Focus();
                return false;
            }
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 住所
            if (String.IsNullOrEmpty(txt_ClAddress.Text))
            {
                MessageBox.Show("住所は必須項目です");
                txt_ClAddress.Focus();
                return false;
            }
            // 電話番号
            if (String.IsNullOrEmpty(txt_ClPhone.Text))
            {
                MessageBox.Show("電話番号は必須項目です");
                txt_ClPhone.Focus();
                return false;
            }
            //　郵便番号
            if (String.IsNullOrEmpty(txt_ClPostal.Text))
            {
                MessageBox.Show("郵便番号は必須項目です");
                txt_ClPostal.Focus();
                return false;
            }
            // FAX
            if (String.IsNullOrEmpty(txt_ClFAX.Text))
            {
                MessageBox.Show("FAXは必須項目です");
                txt_ClFAX.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 顧客ID
            if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClID.Focus();
                return false;
            }
            //　営業所ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 郵便番号
            if (!_ic.PostNoCheck(txt_ClPostal.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClPostal.Focus();
                return false;
            }

            ////　文字チェック ////

            //　顧客名の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ClName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClName.Focus();
                return false;
            }
            // 　住所の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ClAddress.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClAddress.Focus();
                return false;
            }
            //　電話番号の文字チェック
            if (!_ic.PhoneNoCheck(txt_ClPhone.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClPhone.Focus();
                return false;
            }
            // 　FAXの文字チェック
            if (!_ic.HalfCharCheck(txt_ClFAX.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClFAX.Focus();
                return false;
            }
            // 非表示理由
            if (!_ic.FullWidthCharCheck(txt_ClHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClHidden.Focus();
                return false;
            }


            /////文字数チェック/////
            // 顧客ID
            if (txt_ClID.TextLength > 4)
            {
                MessageBox.Show("顧客IDは4文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
                txt_SoID.Focus();
                return false;
            }
            // 顧客名
            if (txt_ClName.TextLength > 50)
            {
                MessageBox.Show("顧客名は50文字以下です");
                txt_ClName.Focus();
                return false;
            }
            //　住所
            if (txt_ClAddress.TextLength > 50)
            {
                MessageBox.Show("住所は50文字以下です");
                txt_ClAddress.Focus();
                return false;
            }
            // 電話番号
            if (txt_ClPhone.TextLength > 13)
            {
                MessageBox.Show("電話番号は13文字以下です");
                txt_ClPhone.Focus();
                return false;
            }
            // 郵便番号
            if (txt_ClPostal.TextLength > 7)
            {
                MessageBox.Show("郵便番号は7文字以下です");
                txt_ClPostal.Focus();
                return false;
            }
            //　FAX
            if (txt_ClFAX.TextLength > 13)
            {
                MessageBox.Show("FAXは13文字以下です");
                txt_ClFAX.Focus();
                return false;
            }
            //　非表示理由
            if (txt_ClHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_ClHidden.Focus();
                return false;
            }

            return true;

        }
        //
        //
        // 3.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private M_Client GenerateDataAtUpdate()
        {
            if (chk_hide_FLG.Checked == false)
            {
                txt_ClHidden.Text = "";
            }
            if (chk_hide_FLG.Checked == true)
            {
                HIDEFlag = 1;
            }
            return new M_Client
            {
                ClID = int.Parse(txt_ClID.Text),
                SoID = int.Parse(txt_SoID.Text),
                ClName = txt_ClName.Text,
                ClAddress = txt_ClAddress.Text,
                ClPhone = txt_ClPhone.Text,
                ClPostal = int.Parse(txt_ClPostal.Text),
                ClFAX = txt_ClFAX.Text,
                ClFlag = HIDEFlag,
                ClHidden = txt_ClHidden.Text,

            };
        }
        //
        //
        // 4.2.3 商品情報更新
        //
        //
        private bool ClientUpdate(M_Client regClient)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Cl.PutClient(regClient);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_ClID.Focus();

            return true;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\81807\DESKTOP\SALESMANAGEMENT_SYSDEV\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Client WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 10; count++)
            {
                if (txt_ClID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@ClID", SqlDbType.VarChar);
                    command.Parameters["@ClID"].Value = txt_ClID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "ClID LIKE @ClID ";
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
                else if (txt_ClName.Text != "" && count == 2)
                {
                    command.Parameters.Add("@ClName", SqlDbType.VarChar);
                    command.Parameters["@ClName"].Value = txt_ClName.Text;
                    //if ("@EmID" != null || "@EmID != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClName LIKE @ClName ";
                    ++andnum;
                }
                else if (txt_ClAddress.Text != "" && count == 3)
                {
                    command.Parameters.Add("@ClAddress", SqlDbType.VarChar);
                    command.Parameters["@ClAddress"].Value = txt_ClAddress.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClAddress LIKE @ClAddress ";
                    ++andnum;
                }
                else if (txt_ClPhone.Text != "" && count == 4)
                {
                    command.Parameters.Add("@ClPhone", SqlDbType.VarChar);
                    command.Parameters["@ClPhone"].Value = txt_ClPhone.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClPhone LIKE @ClPhone ";
                    ++andnum;
                }
                else if (txt_ClPostal.Text != "" && count == 5)
                {
                    command.Parameters.Add("@ClPostal", SqlDbType.VarChar);
                    command.Parameters["@ClPostal"].Value = txt_ClPostal.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClPostal LIKE @ClPostal ";
                    ++andnum;
                }
                else if (txt_ClFAX.Text != "" && count == 6)
                {
                    command.Parameters.Add("@ClFAX", SqlDbType.NVarChar);
                    command.Parameters["@ClFAX"].Value = "%" + txt_ClFAX.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClFAX LIKE @ClFAX ";
                    ++andnum;
                }
                else if (txt_ClHidden.Text != "" && count == 7)
                {
                    command.Parameters.Add("@ClHidden", SqlDbType.NVarChar);
                    command.Parameters["@ClHidden"].Value = "%" + txt_ClHidden.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClHidden LIKE @ClHidden ";
                    ++andnum;
                }

                else if (txt_Clmemo.Text != "" && count == 8)
                {
                    command.Parameters.Add("@Clmemo", SqlDbType.NVarChar);
                    command.Parameters["@Clmemo"].Value = "%" + txt_Clmemo.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Clmemo LIKE @Clmemo ";
                    ++andnum;
                }
                else if (count == 9)
                {
                    command.Parameters.Add("@ClFlag", SqlDbType.NVarChar);
                    command.Parameters["@ClFlag"].Value = HIDEFlag;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClFlag LIKE @ClFlag ";
                    ++andnum;
                }

                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 9)
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
                dataGridView_Client.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Client.Rows.Add(rd["ClID"], rd["SoID"], rd["ClName"], rd["ClAddress"],
                            rd["ClPhone"], rd["ClPostal"], rd["ClFAX"], rd["ClHidden"], rd["Clmemo"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }
        }

        // 削除処理
        // in       ClID : 削除するClID
        private void Delete(int ClID)
        {
            // _it.DeleteClID(int.Parse(ClID));
            _Cl.DeleteClient(ClID);

            // データ取得&表示
            dataGridView_Client.DataSource = _Cl.GetDispClients();
        }

        //一覧表示
        private void btn_all_Click(object sender, EventArgs e)
        {
            AllDataGridView();
        }

        //入力クリア処理
        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }




        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Client.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Client.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_ClID.Clear();
            txt_SoID.Clear();
            txt_ClName.Clear();
            txt_ClAddress.Clear();
            txt_ClPhone.Clear();
            txt_ClPhone.Clear();
            txt_ClPostal.Clear();
            txt_ClFAX.Clear();
            txt_ClHidden.Clear();

            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_ClID.Focus();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Client.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispClientPaging = _Cl.GetDispClients();
            dataGridView_Client.DataSource = _dispClientPaging;

            // 全データ数取得
            _recordCount = _dispClientPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Client.FirstDisplayedScrollingRowIndex = ScrollPosition;

            // 入力クリア
            ClearInput();

            // ページング初期化
            ClearPaging();

        }
        // 一覧表示（テキストクリアなし）
        private void AllDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Client.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispClientPaging = _Cl.GetDispClients();
            dataGridView_Client.DataSource = _dispClientPaging;

            // 全データ数取得
            _recordCount = _dispClientPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Client.FirstDisplayedScrollingRowIndex = ScrollPosition;

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

        // 削除ボタン
        // 3.3 顧客情報削除
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int ClID = int.Parse(txt_ClID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(ClID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Client.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Client.CurrentRow.Cells[1].Value;
            string id3 = (string)dataGridView_Client.CurrentRow.Cells[2].Value;
            string id4 = (string)dataGridView_Client.CurrentRow.Cells[3].Value;
            string id5 = (string)dataGridView_Client.CurrentRow.Cells[4].Value;
            int id6 = (int)dataGridView_Client.CurrentRow.Cells[5].Value;
            string id7 = (string)dataGridView_Client.CurrentRow.Cells[6].Value;
            int id8 = (int)dataGridView_Client.CurrentRow.Cells[7].Value;
            string id9 = (string)dataGridView_Client.CurrentRow.Cells[8].Value;

            txt_ClID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_ClName.Text = Convert.ToString(id3);
            txt_ClAddress.Text = Convert.ToString(id4);
            txt_ClPhone.Text = Convert.ToString(id5);
            txt_ClPostal.Text = Convert.ToString(id6);
            txt_ClFAX.Text = Convert.ToString(id7);
            chk_hide_FLG.Checked = Convert.ToBoolean(id8);
            txt_ClHidden.Text = Convert.ToString(id9);

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

        private void Checked_Client_HideFlag(object sender, EventArgs e)
        {
            if (chk_hide_FLG.Checked == true)
            {
                txt_ClHidden.Text = "";
                HIDEFlag = 1;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            else if (chk_hide_FLG.Checked == false)
            {
                txt_ClHidden.Text = "非表示理由を入力(50文字)";
                HIDEFlag = 0;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            return;

        }
    }
}
