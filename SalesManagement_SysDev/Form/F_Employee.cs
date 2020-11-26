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
    public partial class F_Employee : Form
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

        //// データベース処理モジュール（M_Employee）
        private M_EmployeeContents _Em = new M_EmployeeContents();

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
        private IEnumerable<M_DispEmployee> _dispEmployeePaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispEmployee> _dispEmployeePrinting;                 // 印刷用データ


        public F_Employee()
        {
            InitializeComponent();
        }
        private void F_Employee_Load_1(object sender, EventArgs e)
        {
            商品管理ToolStripMenuItem.Enabled = false;
            dataGridView_Employee.ColumnCount = 9;

            dataGridView_Employee.Columns[0].HeaderText = "社員ID";
            dataGridView_Employee.Columns[1].HeaderText = "社員名";
            dataGridView_Employee.Columns[2].HeaderText = "営業所ID";
            dataGridView_Employee.Columns[3].HeaderText = "役職ID";
            dataGridView_Employee.Columns[4].HeaderText = "入社年月日";
            dataGridView_Employee.Columns[5].HeaderText = "パスワード ";
            dataGridView_Employee.Columns[6].HeaderText = "電話番号";
            dataGridView_Employee.Columns[7].HeaderText = "社員管理フラグ";
            dataGridView_Employee.Columns[8].HeaderText = "非表示理由";

        }
        // 登録ボタン
        // 6.1社員情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 6.1.1妥当な社員情報取得
            if (!Get_Employee_Data_AtRegistration())
                return;

            // 6.1.2妥当な社員情報作成
            var regEmployee = Generate_Data_AtRegistration();

            // 6.1.3社員情報登録
            if (!Generate_Registration(regEmployee))
                return;
        }


        // 
        //
        //6.1.1　妥当な社員データ取得（新規登録）
        //
        //
        private bool Get_Employee_Data_AtRegistration()
        {
            // 社員データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            //　社員ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("社員IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 社員名
            if (String.IsNullOrEmpty(txt_EmName.Text))
            {
                MessageBox.Show("社員名は必須項目です");
                txt_EmName.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 入社年月日
            if (String.IsNullOrEmpty(txt_EmHiredate.Text))
            {
                MessageBox.Show("入社年月日は必須項目です");
                txt_EmHiredate.Focus();
                return false;
            }
            //　非表示理由
            if (String.IsNullOrEmpty(txt_EmHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_EmHidden.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            //　社員ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 役職ID
            if (!_ic.NumericCheck(txt_PoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PoID.Focus();
                return false;
            }
            ////　文字チェック ////

            //　社員名
            if (!_ic.FullWidthCharCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            // 　入社年月日の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmHiredate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmHiredate.Focus();
                return false;
            }
            // 　電話番号の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmPhone.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmPhone.Focus();
                return false;
            }
            // 　備考の文字チェック
            if (!_ic.FullWidthCharCheck(txt_Emmemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Emmemo.Focus();
                return false;
            }


            /////文字数チェック/////
            // 社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            // 社員名
            if (txt_EmName.TextLength > 50)
            {
                MessageBox.Show("社員名は50文字以下です");
                txt_EmName.Focus();
                return false;
            }
            //　営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
                txt_SoID.Focus();
                return false;
            }
            //　役職ID
            if (txt_PoID.TextLength > 2)
            {
                MessageBox.Show("役職IDは2文字以下です");
                txt_PoID.Focus();
                return false;
            }
            // 電話番号
            if (txt_EmPhone.TextLength > 13)
            {
                MessageBox.Show("電話番号は13文字以下です");
                txt_EmPhone.Focus();
                return false;
            }
            //　非表示理由
            if (txt_EmHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_EmHidden.Focus();
                return false;
            }
            //　備考
            if (txt_Emmemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Emmemo.Focus();
                return false;
            }

            return true;
        }
        //
        //
        // 6.1.2 社員情報作成
        //
        //
        private M_Employee Generate_Data_AtRegistration()
        {
            return new M_Employee
            {
                EmID = int.Parse(txt_EmID.Text),
                EmName = txt_EmName.Text,
                SoID = int.Parse(txt_SoID.Text),
                PoID = int.Parse(txt_PoID.Text),
                EmHiredate = DateTime.Parse(txt_EmHiredate.Text),
                //EmPassword = txt_EmPassword.Text,
                EmPhone = txt_EmPhone.Text,
                EmHidden = txt_EmHidden.Text,
                Emmemo = txt_Emmemo.Text,

            };

        }
        //
        //
        // 6.1.3　社員情報登録
        //
        //
        private bool Generate_Registration(M_Employee regEmployee)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 社員情報の登録
            var errorMessage = _Em.PostM_Employee(regEmployee);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_EmID.Focus();

            return true;

        }

        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Employee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Employee.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_EmID.Clear();
            txt_EmName.Clear();
            txt_SoID.Clear();
            txt_PoID.Clear();
            txt_EmHiredate.Clear();
            txt_EmPhone.Clear();
            txt_EmHidden.Clear();
            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_EmID.Focus();
        }

        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Employee.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispEmployeePaging = _Em.GetDispEmployees();
            dataGridView_Employee.DataSource = _dispEmployeePaging;

            // 全データ数取得
            _recordCount = _dispEmployeePaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Employee.FirstDisplayedScrollingRowIndex = ScrollPosition;

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

        // 更新ボタン
        // 6.2 社員情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 6.2.1 妥当な社員データ取得
            if (!GetValidDataAtUpdate()) return;

            // 6.2.2 社員情報作成
            var regEmployee = GenerateDataAtUpdate();

            // 6.2.3 社員情報更新
            EmployeeUpdate(regEmployee);

        }
        //
        //
        // 6.3.2.1 妥当な商品データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 社員データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            //　社員ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("社員IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 社員名
            if (String.IsNullOrEmpty(txt_EmName.Text))
            {
                MessageBox.Show("社員名は必須項目です");
                txt_EmName.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 入社年月日
            if (String.IsNullOrEmpty(txt_EmHiredate.Text))
            {
                MessageBox.Show("入社年月日は必須項目です");
                txt_EmHiredate.Focus();
                return false;
            }
            //　非表示理由
            if (String.IsNullOrEmpty(txt_EmHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_EmHidden.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            //　社員ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 役職ID
            if (!_ic.NumericCheck(txt_PoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PoID.Focus();
                return false;
            }
            ////　文字チェック ////

            //　社員名
            if (!_ic.FullWidthCharCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            // 　入社年月日の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmHiredate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmHiredate.Focus();
                return false;
            }
            // 　電話番号の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmPhone.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmPhone.Focus();
                return false;
            }
            // 　備考の文字チェック
            if (!_ic.FullWidthCharCheck(txt_Emmemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Emmemo.Focus();
                return false;
            }


            /////文字数チェック/////
            // 社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            // 社員名
            if (txt_EmName.TextLength > 50)
            {
                MessageBox.Show("社員名は50文字以下です");
                txt_EmName.Focus();
                return false;
            }
            //　営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
                txt_SoID.Focus();
                return false;
            }
            //　役職ID
            if (txt_PoID.TextLength > 2)
            {
                MessageBox.Show("役職IDは2文字以下です");
                txt_PoID.Focus();
                return false;
            }
            // 電話番号
            if (txt_EmPhone.TextLength > 13)
            {
                MessageBox.Show("電話番号は13文字以下です");
                txt_EmPhone.Focus();
                return false;
            }
            //　非表示理由
            if (txt_EmHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_EmHidden.Focus();
                return false;
            }
            //　備考
            if (txt_Emmemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Emmemo.Focus();
                return false;
            }

            return true;

        }
        //
        //
        // 6.2.2 カテゴリー情報作成
        //
        //
        // out      Employee : Employeeデータ
        private M_Employee GenerateDataAtUpdate()
        {
            return new M_Employee
            {
                EmID = int.Parse(txt_EmID.Text),
                EmName = txt_EmName.Text,
                SoID = int.Parse(txt_SoID.Text),
                PoID = int.Parse(txt_PoID.Text),
                EmHiredate = DateTime.Parse(txt_EmHiredate.Text),
                //EmPassword = txt_EmPassword.Text,
                EmPhone = txt_EmPhone.Text,
                EmHidden = txt_EmHidden.Text,

            };
        }
        //
        //
        // 6.2.3 社員情報更新
        //
        //
        private bool EmployeeUpdate(M_Employee regEmployee)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Em.PutEmployee(regEmployee);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_EmID.Focus();

            return true;
        }

        private void btn_al_Click(object sender, EventArgs e)
        {
            fncAllSelect();
        }
        private void fncAllSelect()
        {
            // データ取得&表示（データバインド）
            _dispEmployeePaging = _Em.GetDispEmployees();
            dataGridView_Employee.DataSource = _dispEmployeePaging;

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
        // 削除ボタン
        // 6.3 社員情報削除

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int EmID = int.Parse(txt_EmID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(EmID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }
        // 削除処理
        // in       EmID : 削除するEmID
        private void Delete(int EmID)
        {
            // _it.DeleteEmID(int.Parse(EmID));
            _Em.DeleteEmployee(EmID);

            // データ取得&表示
            dataGridView_Employee.DataSource = _Em.GetDispEmployees();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM M_Employee WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 8; count++)
            {
                if (txt_EmID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@EmID", SqlDbType.VarChar);
                    command.Parameters["@EmID"].Value = txt_EmID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "EmID LIKE @EmID ";
                    ++andnum;

                }
                else if (txt_EmName.Text != "" && count == 1)
                {
                    command.Parameters.Add("@EmName", SqlDbType.NVarChar);
                    command.Parameters["@EmName"].Value = txt_EmName.Text;
                    //if ("@PrID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmName LIKE @EmName ";
                    ++andnum;
                }
                else if (txt_SoID.Text != "" && count == 2)
                {
                    command.Parameters.Add("@SoID", SqlDbType.NVarChar);
                    command.Parameters["@SoID"].Value = "%" + txt_SoID.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SoID LIKE @SoID ";
                    ++andnum;
                }
                else if (txt_PoID.Text != "" && count == 3)
                {
                    command.Parameters.Add("@PoID", SqlDbType.VarChar);
                    command.Parameters["@PoID"].Value = txt_PoID.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PoID LIKE @PoID ";
                    ++andnum;
                }
                else if (txt_EmHiredate.Text != "" && count == 4)
                {
                    command.Parameters.Add("@EmHiredate", SqlDbType.VarChar);
                    command.Parameters["@EmHiredate"].Value = "%" + txt_EmHiredate.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmHiredate LIKE @EmHiredate ";
                    ++andnum;
                }
                else if (txt_EmPhone.Text != "" && count == 5)
                {
                    command.Parameters.Add("@EmPhone", SqlDbType.NVarChar);
                    command.Parameters["@PrSafetyStock"].Value = txt_EmPhone.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmPhone LIKE @EmPhone ";
                    ++andnum;
                }
                else if (txt_EmHidden.Text != "" && count == 6)
                {
                    command.Parameters.Add("@EmHidden", SqlDbType.NVarChar);
                    command.Parameters["@EmHidden"].Value = txt_EmHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmHidden LIKE @EmHidden ";
                    ++andnum;
                }
                else if (txt_Emmemo.Text != "" && count == 7)
                {
                    command.Parameters.Add("@Emmemo", SqlDbType.NVarChar);
                    command.Parameters["@Emmemo"].Value = txt_Emmemo.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Emmemo LIKE @Emmemo ";
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
                dataGridView_Employee.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Employee.Rows.Add(rd["EmID"], rd["MaName"], rd["SoID"], rd["PoID"],
                            rd["EmHiredate"], rd["EmPhone"], rd["EmHidden"], rd["Emmemo"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 顧客管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 受注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 注文管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 入荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 出荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 在庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 入庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 出庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 社員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 売上管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 発注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
