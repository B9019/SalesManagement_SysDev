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
    public partial class F_Hattyu : MetroForm
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

        //// データベース処理モジュール（M_Division）
        private T_HattyuContents _Ha = new T_HattyuContents();

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
        private IEnumerable<T_DispHattyu> _dispHattyuPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispHattyu> _dispHattyuPrinting;                 // 印刷用データ

        public F_Hattyu()
        {
            InitializeComponent();
        }

        private void F_Hattyu_Load(object sender, EventArgs e)
        {
            dataGridView_Hattyu.ColumnCount = 11;

            dataGridView_Hattyu.Columns[0].HeaderText = "発注ID";
            dataGridView_Hattyu.Columns[1].HeaderText = "メーカID";
            dataGridView_Hattyu.Columns[2].HeaderText = "発注社員ID";
            dataGridView_Hattyu.Columns[3].HeaderText = "発注年月日";
            dataGridView_Hattyu.Columns[4].HeaderText = "備考";
            dataGridView_Hattyu.Columns[5].HeaderText = "非表示理由";

        }
        // 登録ボタン
        // 14.1発注情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 14.1.1妥当な発注情報取得
            if (!Get_Hattyu_Data_AtRegistration())
                return;

            // 14.1.2妥当な発注情報作成
            var regHattyu = Generate_Data_AtRegistration();

            // 14.1.3発注情報登録
            if (!Generate_Registration(regHattyu))
                return;

        }
        // 
        //
        //14.1.1　妥当な発注データ取得（新規登録）
        //
        //
        private bool Get_Hattyu_Data_AtRegistration()
        {
            // 発注データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 発注ID
            if (String.IsNullOrEmpty(txt_HaID.Text))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (String.IsNullOrEmpty(txt_MaID.Text))
            {
                MessageBox.Show("メーカIDは必須項目です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("発注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 発注年月日
            if (String.IsNullOrEmpty(txt_HaDate.Text))
            {
                MessageBox.Show("発注年月日は必須項目です");
                txt_HaDate.Focus();
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
            // 発注ID
            if (!_ic.NumericCheck(txt_HaID.Text, out errorMessage))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (!_ic.NumericCheck(txt_MaID.Text, out errorMessage))
            {
                MessageBox.Show("メーカIDは必須項目です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show("発注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 発注年月日
            if (!_ic.NumericCheck(txt_HaDate.Text, out errorMessage))
            {
                MessageBox.Show("発注年月日は必須項目です");
                txt_HaDate.Focus();
                return false;
            }

            ////　文字チェック ////

            //　備考
            if (!_ic.FullWidthCharCheck(txt_Hamemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Hamemo.Focus();
                return false;
            }
            // 　非表示の文字チェック
            if (!_ic.FullWidthCharCheck(txt_HaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_HaHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 発注ID
            if (txt_HaID.TextLength > 6)
            {
                MessageBox.Show("発注IDは6文字以下です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (txt_MaID.TextLength > 4)
            {
                MessageBox.Show("メーカIDは4文字以下です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("発注社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            //　発注年月日
            if (txt_HaDate.TextLength > 10)
            {
                MessageBox.Show("発注年月日は10文字以下です");
                txt_HaDate.Focus();
                return false;
            }
            // 備考
            if (txt_Hamemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Hamemo.Focus();
                return false;
            }
            // 非表示理由
            if (txt_HaHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_HaHidden.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 14.1.2 発注情報作成
        //
        //
        private T_Hattyu Generate_Data_AtRegistration()
        {
            return new T_Hattyu
            {
                HaID = int.Parse(txt_HaID.Text),
                MaID = int.Parse(txt_MaID.Text),
                EmID = int.Parse(txt_EmID.Text),
                HaDate = DateTime.Parse(txt_HaDate.Text),
                Hamemo = txt_Hamemo.Text,
                HaHidden = txt_HaHidden.Text,

            };

        }
        //
        //
        // 14.1.3　発注情報登録
        //
        //
        private bool Generate_Registration(T_Hattyu regHattyu)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Ha.PostT_Hattyu(regHattyu);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_HaID.Focus();

            return true;

        }
        // 更新ボタン
        // 14.2 発注情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 14.2.1 妥当な発注データ取得
            if (!GetValidDataAtUpdate()) return;

            // 14.2.2 発注情報作成
            var regHattyu = GenerateDataAtUpdate();

            // 14.2.3 発注情報更新
            HattyuUpdate(regHattyu);

        }
        //
        //
        // 14.3.2.1 妥当な発注データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 発注データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 発注ID
            if (String.IsNullOrEmpty(txt_HaID.Text))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (String.IsNullOrEmpty(txt_MaID.Text))
            {
                MessageBox.Show("メーカIDは必須項目です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("発注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 発注年月日
            if (String.IsNullOrEmpty(txt_HaDate.Text))
            {
                MessageBox.Show("発注年月日は必須項目です");
                txt_HaDate.Focus();
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
            // 発注ID
            if (!_ic.NumericCheck(txt_HaID.Text, out errorMessage))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (!_ic.NumericCheck(txt_MaID.Text, out errorMessage))
            {
                MessageBox.Show("メーカIDは必須項目です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show("発注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 発注年月日
            if (!_ic.NumericCheck(txt_HaDate.Text, out errorMessage))
            {
                MessageBox.Show("発注年月日は必須項目です");
                txt_HaDate.Focus();
                return false;
            }

            ////　文字チェック ////

            //　備考
            if (!_ic.FullWidthCharCheck(txt_Hamemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Hamemo.Focus();
                return false;
            }
            // 　非表示の文字チェック
            if (!_ic.FullWidthCharCheck(txt_HaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_HaHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 発注ID
            if (txt_HaID.TextLength > 6)
            {
                MessageBox.Show("発注IDは6文字以下です");
                txt_HaID.Focus();
                return false;
            }
            // メーカID
            if (txt_MaID.TextLength > 4)
            {
                MessageBox.Show("メーカIDは4文字以下です");
                txt_MaID.Focus();
                return false;
            }
            // 発注社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("発注社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            //　発注年月日
            if (txt_HaDate.TextLength > 10)
            {
                MessageBox.Show("発注年月日は10文字以下です");
                txt_HaDate.Focus();
                return false;
            }
            // 備考
            if (txt_Hamemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Hamemo.Focus();
                return false;
            }
            // 非表示理由
            if (txt_HaHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_HaHidden.Focus();
                return false;
            }
            return true;

        }
        //
        //
        // 14.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private T_Hattyu GenerateDataAtUpdate()
        {
            return new T_Hattyu
            {
                HaID = int.Parse(txt_HaID.Text),
                MaID = int.Parse(txt_MaID.Text),
                EmID = int.Parse(txt_EmID.Text),
                HaDate = DateTime.Parse(txt_HaDate.Text),
                Hamemo = txt_Hamemo.Text,
                HaHidden = txt_HaHidden.Text,

            };
        }
        //
        //
        // 14.2.3 発注情報更新
        //
        //
        private bool HattyuUpdate(T_Hattyu regHattyu)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Ha.PutHattyu(regHattyu);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_HaID.Focus();

            return true;
        }
        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Hattyu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Hattyu.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_HaID.Clear();
            txt_MaID.Clear();
            txt_EmID.Clear();
            txt_HaDate.Clear();
            txt_Hamemo.Clear();
            txt_HaHidden.Clear();

            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_HaID.Focus();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Hattyu.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispHattyuPaging = _Ha.GetDispHattyus();
            dataGridView_Hattyu.DataSource = _dispHattyuPaging;

            // 全データ数取得
            _recordCount = _dispHattyuPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Hattyu.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
            // データ取得&表示（データバインド）
            _dispHattyuPaging = _Ha.GetDispHattyus();
            dataGridView_Hattyu.DataSource = _dispHattyuPaging;

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Hattyu WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 7; count++)
            {
                if (txt_HaID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@HaID", SqlDbType.VarChar);
                    command.Parameters["@HaID"].Value = txt_HaID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "HaID LIKE @HaID ";
                    ++andnum;

                }
                else if (txt_MaID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@MaID", SqlDbType.VarChar);
                    command.Parameters["@MaID"].Value = txt_MaID.Text;
                    //if ("@PrID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "MaID LIKE @MaID ";
                    ++andnum;
                }
                else if (txt_EmID.Text != "" && count == 2)
                {
                    command.Parameters.Add("@EmID", SqlDbType.NVarChar);
                    command.Parameters["@EmID"].Value =  txt_EmID.Text;
                    //if ("@PrID" != null || "@MaID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmID LIKE @EmID ";
                    ++andnum;
                }
                else if (txt_HaDate.Text != "" && count == 3)
                {
                    command.Parameters.Add("@HaDate", SqlDbType.VarChar);
                    command.Parameters["@HaDate"].Value = txt_HaDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "HaDate LIKE @HaDate ";
                    ++andnum;
                }
                else if (txt_Hamemo.Text != "" && count == 4)
                {
                    command.Parameters.Add("@Hamemo", SqlDbType.VarChar);
                    command.Parameters["@Hamemo"].Value = "%" + txt_Hamemo.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Hamemo LIKE @Hamemo ";
                    ++andnum;
                }
                else if (txt_HaHidden.Text != "" && count == 5)
                {
                    command.Parameters.Add("@HaHidden", SqlDbType.VarChar);
                    command.Parameters["@HaHidden"].Value = "%" + txt_HaHidden.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "HaHidden LIKE @HaHidden ";
                    ++andnum;
                }
                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 5)
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
                dataGridView_Hattyu.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Hattyu.Rows.Add(rd["HaID"], rd["MaID"], rd["HaDate"], rd["Hamemo"],
                            rd["HaHidden"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }

        }
        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Hattyu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Hattyu.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Hattyu.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Hattyu.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Hattyu.CurrentRow.Cells[3].Value;
            string id5 = (string)dataGridView_Hattyu.CurrentRow.Cells[4].Value;
            string id6 = (string)dataGridView_Hattyu.CurrentRow.Cells[5].Value;

            txt_HaID.Text = Convert.ToString(id);
            txt_MaID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_Hamemo.Text = Convert.ToString(id4);
            txt_HaHidden.Text = Convert.ToString(id5);

        }

    }
}
