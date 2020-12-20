using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.ContentsManagement;
using SalesManagement_SysDev.Model.Entity.Disp;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace SalesManagement_SysDev
{
    public partial class F_Warehousing : MetroForm
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
        private T_WarehousingContents _Wa = new T_WarehousingContents();

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
        private IEnumerable<T_DispWarehousing> _dispWarehousingPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispWarehousing> _dispWarehousingPrinting;   // 印刷用データ

        int HIDEFlag;
        public F_Warehousing()
        {
            InitializeComponent();
        }

        private void F_Warehousing_Load(object sender, EventArgs e)
        {
            HIDEFlag = 0;
            btn_warehousing.Enabled = false;

            F_login f_login = new F_login();
            transfer_int = f_login.transfer_int;

            btn_delete.Enabled = false;

            if (transfer_int == 1 ||
               transfer_int == 5)
            {
                btn_delete.Enabled = true;
            }


            dataGridView_Warehousing.ColumnCount = 6;

            dataGridView_Warehousing.Columns[0].HeaderText = "入庫ID ";
            dataGridView_Warehousing.Columns[1].HeaderText = "発注ID ";
            dataGridView_Warehousing.Columns[2].HeaderText = "入庫確認社員ID";
            dataGridView_Warehousing.Columns[3].HeaderText = "入庫年月日";
            dataGridView_Warehousing.Columns[4].HeaderText = "非表示理由";
            dataGridView_Warehousing.Columns[5].HeaderText = "備考 ";
        }

        // 登録ボタン
        // 4.1商品情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 4.1.1妥当な商品情報取得
            if (!Get_Warehousing_Data_AtRegistration())
                return;

            // 4.1.2妥当な商品情報作成
            var regWarehousing = Generate_Data_AtRegistration();

            // 4.1.3商品情報登録
            if (!Generate_Registration(regWarehousing))
                return;
        }
        // 
        //
        //4.1.1　妥当な商品データ取得（新規登録）
        //
        //
        private bool Get_Warehousing_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 入庫ID
            if (String.IsNullOrEmpty(txt_WaID.Text))
            {
                MessageBox.Show("入庫IDは必須項目です");
                txt_WaID.Focus();
                return false;
            }
            // 発注ID
            if (String.IsNullOrEmpty(txt_HaID.Text))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // 入庫確認社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("入庫確認社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }

            //　入庫年月日
            if (String.IsNullOrEmpty(txt_WaDate.Text))
            {
                MessageBox.Show("入庫年月日は必須項目です");
                txt_WaDate.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 入庫ID
            if (!_ic.NumericCheck(txt_WaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaID.Focus();
                return false;
            }
            //　発注ID
            if (!_ic.NumericCheck(txt_HaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_HaID.Focus();
                return false;
            }
            //入庫確認社員IID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }

            ////　文字チェック ////

            //　非表示理由
            if (!_ic.FullWidthCharCheck(txt_WaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_WaHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_WaHidden.Focus();
                return false;
            }
            ////　文字チェック ////

            //　入庫年月日
            if (!_ic.DateFormCheck(txt_WaDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 4.1.2 商品情報作成
        //
        //
        private T_Warehousing Generate_Data_AtRegistration()
        {
            if(chk_hide_FLG.Checked == false)
            {
                txt_WaHidden.Text = "";
            }
            return new T_Warehousing
            {
                WaID = int.Parse(txt_WaID.Text),
                HaID = int.Parse(txt_HaID.Text),
                EmID = int.Parse(txt_EmID.Text),
                WaFlag = 0,
                WaDate = DateTime.Parse(txt_WaDate.Text)
            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(T_Warehousing regWarehousing)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Wa.PostT_Warehousing(regWarehousing);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            if(chk_hide_FLG.Checked == false)
            {
                txt_WaHidden.Text = "非表示理由を入力(50文字)";
            }
            RefreshDataGridView();
            txt_WaID.Focus();

            return true;

        }

        // 更新ボタン
        // 4.2 商品情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 4.2.1 妥当な商品データ取得
            if (!GetValidDataAtUpdate()) return;

            // 4.2.2 商品情報作成
            var regWarehousing = GenerateDataAtUpdate();

            // 4.2.3 商品情報更新
            WarehousingUpdate(regWarehousing);

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

            // 入庫ID
            if (String.IsNullOrEmpty(txt_WaID.Text))
            {
                MessageBox.Show("入庫IDは必須項目です");
                txt_WaID.Focus();
                return false;
            }
            // 発注ID
            if (String.IsNullOrEmpty(txt_HaID.Text))
            {
                MessageBox.Show("発注IDは必須項目です");
                txt_HaID.Focus();
                return false;
            }
            // 入庫確認社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("入庫確認社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }

            //　入庫年月日
            if (String.IsNullOrEmpty(txt_WaDate.Text))
            {
                MessageBox.Show("入庫年月日は必須項目です");
                txt_WaDate.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 入庫ID
            if (!_ic.NumericCheck(txt_WaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaID.Focus();
                return false;
            }
            //　発注ID
            if (!_ic.NumericCheck(txt_HaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_HaID.Focus();
                return false;
            }
            //入庫確認社員IID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }

            ////　文字チェック ////

            //　非表示理由
            if (!_ic.FullWidthCharCheck(txt_WaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_WaHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_WaHidden.Focus();
                return false;
            }
            ////　文字チェック ////

            //　入庫年月日
            if (!_ic.DateFormCheck(txt_WaDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_WaDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 4.2.2 入庫情報作成
        //
        //
        // out      Category : Categoryデータ
        private T_Warehousing GenerateDataAtUpdate()
        {

            if (chk_hide_FLG.Checked == false)
            {
                txt_WaHidden.Text = "";
            }
            if (chk_hide_FLG.Checked == true)
            {
                HIDEFlag = 1;
            }
            return new T_Warehousing
            {
                WaID = int.Parse(txt_WaID.Text),
                HaID = int.Parse(txt_HaID.Text),
                EmID = int.Parse(txt_EmID.Text),
                WaDate = DateTime.Parse(txt_WaDate.Text),
                WaFlag = HIDEFlag,
                WaHidden = txt_WaHidden.Text

            };
        }
        //
        //
        // 4.2.3 商品情報更新
        //
        //
        private bool WarehousingUpdate(T_Warehousing regWarehousing)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Wa.PutWarehousing(regWarehousing);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            // 画面更新
            if (chk_hide_FLG.Checked == false)
            {
                txt_WaHidden.Text = "非表示理由を入力(50文字)";
            }
            RefreshDataGridView();
            txt_WaID.Focus();

            return true;
        }

        // 削除ボタン
        // 4.3 商品情報削除
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int WaID = int.Parse(txt_WaID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(WaID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
        }

        // 削除処理
        // in      ChID: 削除するChID
        private void Delete(int WaID)
        {
            // _it.DeletePrID(int.Parse(PrID));
            _Wa.DeleteWarehousing(WaID);

            // データ取得&表示
            dataGridView_Warehousing.DataSource = _Wa.GetDispWarehousing();
        }




        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Warehousing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Warehousing.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_WaID.Clear();
            txt_HaID.Clear();
            txt_EmID.Clear();
            txt_WaDate.Clear();
            txt_WaHidden.Clear();


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
            int ScrollPosition = dataGridView_Warehousing.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispWarehousingPaging = _Wa.GetDispWarehousing();
            dataGridView_Warehousing.DataSource = _dispWarehousingPaging;

            // 全データ数取得
            _recordCount = _dispWarehousingPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Warehousing.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
        private void dataGridView_Warehousing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Warehousing.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Warehousing.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Warehousing.CurrentRow.Cells[2].Value;
            DateTime id4 = (DateTime)dataGridView_Warehousing.CurrentRow.Cells[3].Value;
            string id5 = (string)dataGridView_Warehousing.CurrentRow.Cells[4].Value;
            string id6 = (string)dataGridView_Warehousing.CurrentRow.Cells[5].Value;

            txt_WaID.Text = Convert.ToString(id);
            txt_EmID.Text = Convert.ToString(id2);
            txt_HaID.Text = Convert.ToString(id3);
            txt_WaDate.Text = Convert.ToString(id4);
            txt_WaHidden.Text = Convert.ToString(id5);
            txt_memo.Text = Convert.ToString(id6);

        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Warehousing WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 7; count++)
            {
                if (txt_WaID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@WaID", SqlDbType.VarChar);
                    command.Parameters["@WaID"].Value = txt_WaID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "WaID LIKE @WaID ";
                    ++andnum;

                }
                else if (txt_HaID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@HaID", SqlDbType.VarChar);
                    command.Parameters["@HaID"].Value = txt_HaID.Text;
                    //if ("@SoID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "HaID LIKE @HaID ";
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
                
                else if (txt_WaDate.Text != "" && count == 3)
                {
                    command.Parameters.Add("@WaDate", SqlDbType.VarChar);
                    command.Parameters["@WaDate"].Value = txt_WaDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "WaDate LIKE @WaDate ";
                    ++andnum;
                }
                else if (txt_WaHidden.Text != "" && count == 4)
                {
                    command.Parameters.Add("@WaHidden", SqlDbType.VarChar);
                    command.Parameters["@WaHidden"].Value = txt_WaHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "WaHidden LIKE @WaHidden ";
                    ++andnum;
                }

                else if (txt_memo.Text != "" && count == 5)
                {
                    command.Parameters.Add("@memo", SqlDbType.NVarChar);
                    command.Parameters["@memo"].Value = "%" + txt_memo.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "memo LIKE @memo ";
                    ++andnum;
                }
                else if (count == 6)
                {
                    command.Parameters.Add("@PrFlag", SqlDbType.NVarChar);
                    command.Parameters["@PrFlag"].Value = HIDEFlag;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrFlag LIKE @PrFlag ";
                    ++andnum;
                }
                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 6)
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
                dataGridView_Warehousing.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Warehousing.Rows.Add(rd["WaID"], rd["HaID"], rd["EmID"], rd["WaDate"], rd["WaHidden"], rd["memo"]);
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
            txt_WaID.Text = "";
            txt_HaID.Text = "";
            txt_EmID.Text = "";
            txt_WaDate.Text = "";
            txt_WaHidden.Text = "";
            txt_memo.Text = "";
        }

        private void Checked_Warehousing_HideFlag(object sender, EventArgs e)
        {
            if (chk_hide_FLG.Checked == true)
            {
                txt_WaHidden.Text = "";
                HIDEFlag = 1;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            else if (chk_hide_FLG.Checked == false)
            {
                txt_WaHidden.Text = "非表示理由を入力(50文字)";
                HIDEFlag = 0;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            return;

        }
    }
    }

