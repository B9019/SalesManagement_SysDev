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
    public partial class F_Arrival : MetroForm
    {
        public int transfer_int ;//権限変数
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
        private T_ArrivalContents _Ar = new T_ArrivalContents();

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
                txt_ArID.Focus();
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
            ////　日付型チェック ////
            if (!_ic.DateFormCheck(txt_ArDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ArDate.Focus();
                return false;
            }
            ////　文字チェック ////

            ////　備考
            //if (!_ic.FullWidthCharCheck(txt_Armemo.Text, out errorMessage))
            //{
            //    MessageBox.Show(errorMessage);
            //    txt_Armemo.Focus();
            //    return false;
            //}
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
                MessageBox.Show("入荷IDは6文字以下です");
                txt_ArID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
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
            if (txt_ClID.TextLength > 4)
            {
                MessageBox.Show("顧客IDは4文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 入荷年月日
            if (txt_ArDate.TextLength > 10)
            {
                MessageBox.Show("入荷年月日は10文字以下です");
                txt_ArDate.Focus();
                return false;
            }
            //　備考
            if (txt_Armemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Armemo.Focus();
                return false;
            }
            //　非表示理由
            if (txt_ArHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
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
            _dispArrivalPaging = _Ar.GetDispArrivals();
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
        // 更新ボタン
        // 11.2 入荷情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 11.2.1 妥当な入荷データ取得
            if (!GetValidDataAtUpdate()) return;

            //11.2.2 入荷情報作成
            var regArrival = GenerateDataAtUpdate();

            // 11.2.3 入荷情報更新
            ArrivalUpdate(regArrival);

        }
        //
        //
        //　11.3.2.1 妥当な入荷データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 入荷データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 入荷ID
            if (String.IsNullOrEmpty(txt_ArID.Text))
            {
                MessageBox.Show("入荷IDは必須項目です");
                txt_ArID.Focus();
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
            ////　日付型チェック ////
            if (!_ic.DateFormCheck(txt_ArDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ArDate.Focus();
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
                MessageBox.Show("入荷IDは6文字以下です");
                txt_ArID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
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
            if (txt_ClID.TextLength > 4)
            {
                MessageBox.Show("顧客IDは4文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 入荷年月日
            if (txt_ArDate.TextLength > 9)
            {
                MessageBox.Show("入荷年月日は9文字以下です");
                txt_ArDate.Focus();
                return false;
            }
            //　備考
            if (txt_Armemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Armemo.Focus();
                return false;
            }
            //　非表示理由
            if (txt_ArHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_ArHidden.Focus();
                return false;
            }
            return true;

        }
        //
        //
        // 11.2.2 カテゴリー情報作成
        //
        //
        // out      Arrival : Arrivalデータ
        private T_Arrival GenerateDataAtUpdate()
        {
            return new T_Arrival
            {
                ArID = int.Parse(txt_ArID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                ArDate = DateTime.Parse(txt_ArDate.Text),
                Armemo = txt_Armemo.Text,
                ArHidden = txt_ArHidden.Text,

            };
        }
        //
        //
        // 11.2.3 入荷情報更新
        //
        //
        private bool ArrivalUpdate(T_Arrival regArrival)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Ar.PutArrival(regArrival);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_ArID.Focus();

            return true;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            fncAllSelect();
        }
        private void fncAllSelect()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=65B7FDBF103579B7D7CE0C17EE5CC7E8_)\システム開発演習I\プロジェクト\SALESMANAGEMENT_SYSDEV\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";
            //command.Parameters.Add("@PrFlag", SqlDbType.VarChar);
            //command.Parameters["@PrFlag"].Value = "0";
            command.CommandText = "SELECT * FROM T_Arrival WHERE ArFlag = 0 AND ";
            command.Connection = conn;
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            dataGridView_Arrival.Rows.Clear();
            while (rd.Read())
            {
                dataGridView_Arrival.Rows.Add(rd["ArID"], rd["SoID"], rd["EmID"], rd["ClID"],
                    rd["OrID"], rd["ArDate"], rd["ArStateFlag"], rd["ArFlag"],
                    rd["ArHidden"], rd["Armemo"]);
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=65B7FDBF103579B7D7CE0C17EE5CC7E8_)\システム開発演習I\プロジェクト\SALESMANAGEMENT_SYSDEV\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Arrival WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 8; count++)
            {
                if (txt_ArID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@ArID", SqlDbType.VarChar);
                    command.Parameters["@ArID"].Value = txt_ArID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "ArID LIKE @ArID ";
                    ++andnum;

                }
                else if (txt_SoID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@SoID", SqlDbType.VarChar);
                    command.Parameters["@SoID"].Value = txt_SoID.Text;
                    //if ("@PrID" != null)
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
                    //if ("@PrID" != null || "@MaID" != null)
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
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClID LIKE @ClID ";
                    ++andnum;
                }
                else if (txt_OrID.Text != "" && count == 4)
                {
                    command.Parameters.Add("@OrID", SqlDbType.VarChar);
                    command.Parameters["@OrID"].Value = "%" + txt_OrID.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "OrID LIKE @OrID ";
                    ++andnum;
                }
                else if (txt_ArDate.Text != "" && count == 5)
                {
                    command.Parameters.Add("@ArDate", SqlDbType.VarChar);
                    command.Parameters["@ArDate"].Value = txt_ArDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ArDate LIKE @ArDate ";
                    ++andnum;
                }
                else if (txt_Armemo.Text != "" && count == 6)
                {
                    command.Parameters.Add("@Armemo", SqlDbType.VarChar);
                    command.Parameters["@Armemo"].Value = txt_Armemo.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Armemo LIKE @Armemo ";
                    ++andnum;
                }
                else if (txt_ArHidden.Text != "" && count == 7)
                {
                    command.Parameters.Add("@ArHidden", SqlDbType.VarChar);
                    command.Parameters["@ArHidden"].Value = txt_ArHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ArHidden LIKE @ArHidden ";
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
                dataGridView_Arrival.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Arrival.Rows.Add(rd["ArID"], rd["SoID"], rd["EmID"], rd["ClID"],
                            rd["OrID"], rd["ArDate"], rd["ArHidden"], rd["Armemo"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            F_login form_login = new F_login();
            form_login.ShowDialog();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            F_Client form_client = new F_Client();
            form_client.ShowDialog();
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            F_Product form_product = new F_Product();
            form_product.ShowDialog();

        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            F_Order form_order = new F_Order();
            form_order.ShowDialog();

        }

        private void btn_chumon_Click(object sender, EventArgs e)
        {
            F_Chumon form_chumon = new F_Chumon();
            form_chumon.ShowDialog();

        }

        private void btn_arrival_Click(object sender, EventArgs e)
        {
            F_Arrival form_arrival = new F_Arrival();
            form_arrival.ShowDialog();

        }

        private void btn_syukka_Click(object sender, EventArgs e)
        {
            F_Shipment form_shipment = new F_Shipment();
            form_shipment.ShowDialog();

        }

        private void btn_zaiko_Click(object sender, EventArgs e)
        {
            F_Stock form_stock = new F_Stock();
            form_stock.ShowDialog();

        }

        private void btn_warehousing_Click(object sender, EventArgs e)
        {
            F_Warehousing form_warehousing = new F_Warehousing();
            form_warehousing.ShowDialog();
        }

        private void btn_syukko_Click(object sender, EventArgs e)
        {
            F_Syukko form_syukko = new F_Syukko();
            form_syukko.ShowDialog();

        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            F_Employee form_employee = new F_Employee();
            form_employee.ShowDialog();

        }

        private void btn_sale_Click(object sender, EventArgs e)
        {
            F_Sale form_sale = new F_Sale();
            form_sale.ShowDialog();

        }

        private void btn_hattyu_Click(object sender, EventArgs e)
        {
            F_Hattyu form_hattyu = new F_Hattyu();
            form_hattyu.ShowDialog();

        }

        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Arrival_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Arrival.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Arrival.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Arrival.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Arrival.CurrentRow.Cells[3].Value;
            int id5 = (int)dataGridView_Arrival.CurrentRow.Cells[4].Value;
            DateTime id6 = (DateTime)dataGridView_Arrival.CurrentRow.Cells[5].Value;
            string id7 = (string)dataGridView_Arrival.CurrentRow.Cells[6].Value;
            string id8 = (string)dataGridView_Arrival.CurrentRow.Cells[7].Value;

            txt_ArID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_ClID.Text = Convert.ToString(id4);
            txt_OrID.Text = Convert.ToString(id5);
            txt_ArDate.Text = Convert.ToString(id6);
            txt_Armemo.Text = Convert.ToString(id7);
            txt_ArHidden.Text = Convert.ToString(id8);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int ArID = int.Parse(txt_ArID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(ArID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();

        }
        // 削除処理
        // in       ArID : 削除するArID
        private void Delete(int ArID)
        {
            // _it.DeletePrID(int.Parse(PrID));
            _Ar.DeleteArrival(ArID);

            // データ取得&表示
            dataGridView_Arrival.DataSource = _Ar.GetDispArrivals();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_ArID.Text = "";
            txt_SoID.Text = "";
            txt_EmID.Text = "";
            txt_ClID.Text = "";
            txt_OrID.Text = "";
            txt_ArDate.Text = "";
            txt_ArHidden.Text = "";
        }

    }
}
