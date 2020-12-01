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
    public partial class F_Shipment : Form
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
        private T_ShipmentContents _Ch = new T_ShipmentContents();

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
        private IEnumerable<T_DispShipment> _dispShipmentPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispShipment> _dispShipmentPrinting;   // 印刷用データ
        public F_Shipment()
        {
            InitializeComponent();
        }

        private void F_Shipment_Load(object sender, EventArgs e)
        {
            出荷管理ToolStripMenuItem.Enabled = false;
        }

        // 登録ボタン
        // 4.1商品情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {

            // 4.1.1妥当な商品情報取得
            if (!Get_Shipment_Data_AtRegistration())
                return;

            // 4.1.2妥当な商品情報作成
            var regShipment = Generate_Data_AtRegistration();

            // 4.1.3商品情報登録
            if (!Generate_Registration(regShipment))
                return;
        }
        // 
        //
        //4.1.1　妥当な商品データ取得（新規登録）
        //
        //
        private bool Get_Shipment_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 出荷ID
            if (String.IsNullOrEmpty(txt_ShID.Text))
            {
                MessageBox.Show("出荷IDは必須項目です");
                txt_ShID.Focus();
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
            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
                return false;
            }
            //　出荷完了年月日
            if (String.IsNullOrEmpty(txt_ShFinishDate.Text))
            {
                MessageBox.Show("注文年月日は必須項目です");
                txt_ShFinishDate.Focus();
                return false;
            }


            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 出荷ID
            if (!_ic.NumericCheck(txt_ShID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShID.Focus();
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

            ////　文字チェック ////

            //　非表示理由
            if (!_ic.FullWidthCharCheck(txt_ShHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_ShHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_ShHidden.Focus();
                return false;
            }
            ////　日付チェック ////

            //　出荷完了年月日
            if (!_ic.DateFormCheck(txt_ShFinishDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShFinishDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 4.1.2 商品情報作成
        //
        //
        private T_Shipment Generate_Data_AtRegistration()
        {
            return new T_Shipment
            {
                ShID = int.Parse(txt_ShID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                ShFinishDate = DateTime.Parse(txt_ShFinishDate.Text),
                ShHidden = txt_ShHidden.Text

            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(T_Shipment regChumon)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Ch.PostT_Shipment(regChumon);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_ShID.Focus();

            return true;

        }

        // 更新ボタン
        // 4.2 商品情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 4.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate()) return;

            // 4.2.2 商品情報作成
            var regShipment = GenerateDataAtUpdate();

            // 4.2.3 商品情報更新
            ShipmentUpdate(regShipment);

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

            // 出荷ID
            if (String.IsNullOrEmpty(txt_ShID.Text))
            {
                MessageBox.Show("出荷IDは必須項目です");
                txt_ShID.Focus();
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
            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
                return false;
            }
            //　出荷完了年月日
            if (String.IsNullOrEmpty(txt_ShFinishDate.Text))
            {
                MessageBox.Show("注文年月日は必須項目です");
                txt_ShFinishDate.Focus();
                return false;
            }


            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 出荷ID
            if (!_ic.NumericCheck(txt_ShID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShID.Focus();
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

            ////　文字チェック ////

            //　非表示理由
            if (!_ic.FullWidthCharCheck(txt_ShHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_ShHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_ShHidden.Focus();
                return false;
            }
            ////　日付チェック ////

            //　出荷完了年月日
            if (!_ic.DateFormCheck(txt_ShFinishDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ShFinishDate.Focus();
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
        private T_Shipment GenerateDataAtUpdate()
        {
            return new T_Shipment
            {
                ShID = int.Parse(txt_ShID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                ShFinishDate = DateTime.Parse(txt_ShFinishDate.Text),
                ShHidden = txt_ShHidden.Text

            };
        }
        //
        //
        // 4.2.3 商品情報更新
        //
        //
        private bool ShipmentUpdate(T_Shipment regShipment)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Ch.PutShipment(regShipment);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_ShID.Focus();

            return true;
        }

        // 削除ボタン
        // 4.3 商品情報削除
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int ChID = int.Parse(txt_ShID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(ChID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        // 削除処理
        // in      ChID: 削除するChID
        private void Delete(int ShID)
        {

            _Ch.DeleteShipment(ShID);

            // データ取得&表示
            dataGridView_Shipment.DataSource = _Ch.GetDispShipment();
        }




        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Shipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Shipment.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_ShID.Clear();
            txt_SoID.Clear();
            txt_EmID.Clear();
            txt_ClID.Clear();
            txt_OrID.Clear();
            txt_ShFinishDate.Clear();
            txt_ShHidden.Clear();


            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_ShID.Focus();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Shipment.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispShipmentPaging = _Ch.GetDispShipment();
            dataGridView_Shipment.DataSource = _dispShipmentPaging;

            // 全データ数取得
            _recordCount = _dispShipmentPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Shipment.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
        private void dataGridView_Shipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Shipment.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Shipment.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Shipment.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Shipment.CurrentRow.Cells[3].Value;
            int id5 = (int)dataGridView_Shipment.CurrentRow.Cells[4].Value;
            DateTime id6 = (DateTime)dataGridView_Shipment.CurrentRow.Cells[5].Value;
            string id7 = (string)dataGridView_Shipment.CurrentRow.Cells[6].Value;
            string id8 = (string)dataGridView_Shipment.CurrentRow.Cells[7].Value;

            txt_ShID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_ClID.Text = Convert.ToString(id4);
            txt_OrID.Text = Convert.ToString(id5);
            txt_ShFinishDate.Text = Convert.ToString(id6);
            txt_ShHidden.Text = Convert.ToString(id7);
            txt_memo.Text = Convert.ToString(id8);

        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Shipment WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 9; count++)
            {
                if (txt_ShID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@ShID", SqlDbType.VarChar);
                    command.Parameters["@ShID"].Value = txt_ShID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "ShID LIKE @ShID ";
                    ++andnum;

                }
                else if (txt_ClID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@ClID", SqlDbType.VarChar);
                    command.Parameters["@ClID"].Value = txt_ClID.Text;
                    //if ("@SoID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClID LIKE @ClID ";
                    ++andnum;
                }
                else if (txt_EmID.Text != "" && count == 2)
                {
                    command.Parameters.Add("@EmID", SqlDbType.NVarChar);
                    command.Parameters["@EmID"].Value = "%" + txt_EmID.Text + "%";
                    //if ("@EmID" != null || "@EmID != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmID LIKE @PrName ";
                    ++andnum;
                }
                else if (txt_SoID.Text != "" && count == 3)
                {
                    command.Parameters.Add("@SoID", SqlDbType.VarChar);
                    command.Parameters["@SoID"].Value = txt_SoID.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SoID LIKE @SoID ";
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
                else if (txt_ShFinishDate.Text != "" && count == 5)
                {
                    command.Parameters.Add("@ShFinishDate", SqlDbType.VarChar);
                    command.Parameters["@ShFinishDate"].Value = txt_ShFinishDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ShFinishDate LIKE @ShFinishDate ";
                    ++andnum;
                }
                else if (txt_ShHidden.Text != "" && count == 6)
                {
                    command.Parameters.Add("@ShHidden", SqlDbType.VarChar);
                    command.Parameters["@ShHidden"].Value = txt_ShHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ShHidden LIKE @ShHidden ";
                    ++andnum;
                }

                else if (txt_memo.Text != "" && count == 10)
                {
                    command.Parameters.Add("@memo", SqlDbType.NVarChar);
                    command.Parameters["@memo"].Value = "%" + txt_memo.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "memo LIKE @memo ";
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
                dataGridView_Shipment.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Shipment.Rows.Add(rd["ShID"], rd["SoID"], rd["EmID"], rd["ClID"],
                            rd["OrID"], rd["ShFinishDate"], rd["ShHidden"], rd["memo"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_ShID.Text = "";
            txt_SoID.Text = "";
            txt_EmID.Text = "";
            txt_ClID.Text = "";
            txt_OrID.Text = "";
            txt_ShFinishDate.Text = "";
            txt_ShHidden.Text = "";
            txt_memo.Text = "";
        } //接続先DBの情報をセット
       
    }
}