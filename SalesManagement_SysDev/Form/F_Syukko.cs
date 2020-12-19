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
    public partial class F_Syukko : MetroForm
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
        private T_SyukkoContents _Sy = new T_SyukkoContents();
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
        private IEnumerable<T_DispSyukko> _dispSyukkoPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispSyukko> _dispSyukkoPrinting;   // 印刷用データ
        public F_Syukko()
        {
            InitializeComponent();
        }

        private void F_Syukko_Load(object sender, EventArgs e)
        {
            btn_regist.Enabled = false;
            dataGridView_Syukko.ColumnCount = 12;

            dataGridView_Syukko.Columns[0].HeaderText = "出庫ID";
            dataGridView_Syukko.Columns[1].HeaderText = "社員ID";
            dataGridView_Syukko.Columns[2].HeaderText = "顧客ID";
            dataGridView_Syukko.Columns[3].HeaderText = "営業所ID";
            dataGridView_Syukko.Columns[4].HeaderText = "受注ID";
            dataGridView_Syukko.Columns[5].HeaderText = "出庫年月日";
            dataGridView_Syukko.Columns[6].HeaderText = "出庫状態フラグ";
            dataGridView_Syukko.Columns[7].HeaderText = "出庫管理フラグ";
            dataGridView_Syukko.Columns[8].HeaderText = "非表示理由";
            dataGridView_Syukko.Columns[9].HeaderText = "出庫詳細ID";
            dataGridView_Syukko.Columns[10].HeaderText = "商品ID";
            dataGridView_Syukko.Columns[11].HeaderText = "数量";
        }

        // 登録ボタン
        // 10.1出庫情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 10.1.1妥当な商品情報取得
            if (!Get_Syukko_Data_AtRegistration())
                return;

            // 10.1.2妥当な商品情報作成
            var regSyukko = Generate_Data_AtRegistration();

            // 10.1.3商品情報登録
            if (!Generate_Registration(regSyukko))
                return;
        }
        // 
        //
        //10.1.1　妥当な出庫データ取得（新規登録）
        //
        //
        private bool Get_Syukko_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 出庫ID
            if (String.IsNullOrEmpty(txt_SyID.Text))
            {
                MessageBox.Show("出庫IDは必須項目です");
                txt_SyID.Focus();
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
            //　出庫年月日
            if (String.IsNullOrEmpty(txt_SyDate.Text))
            {
                MessageBox.Show("出庫年月日は必須項目です");
                txt_SyDate.Focus();
                return false;
            }


            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 出庫ID
            if (!_ic.NumericCheck(txt_SyID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_SyHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_SyHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_SyHidden.Focus();
                return false;
            }
            ////　文字チェック ////

            //　出庫年月日
            if (!_ic.DateFormCheck(txt_SyDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 10.1.2 商品情報作成
        //
        //
        private T_Syukko Generate_Data_AtRegistration()
        {
            return new T_Syukko
            {
                SyID = int.Parse(txt_SyID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                SyDate = DateTime.Parse(txt_SyDate.Text),
                SyHidden = txt_SyHidden.Text

            };

        }
        //
        //
        // 10.1.3　出庫情報登録
        //
        //
        private bool Generate_Registration(T_Syukko regSyukko)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Sy.PostT_Syukko(regSyukko);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_SyID.Focus();

            return true;

        }

        // 更新ボタン
        // 10.2 出庫情報更新
        private void btn_update_Click(object sender, EventArgs e)
        {
            // 10.2.1 妥当な出庫データ取得
            if (!GetValidDataAtUpdate()) return;

            // 10.2.2 出庫情報作成
            var regSyukko = GenerateDataAtUpdate();
            var regSyukkoDetail = GenerateDataAtUpdateDetail();
            var regArrival = GenerateDataAtUpdateArrival();
            var regArrivalDetail = GenerateDataAtUpdateArrivalDetail();

            // 10.2.3 出庫情報更新
            SyukkoUpdate(regSyukko);
            SyukkoDetailUpdate(regSyukkoDetail);
            if(chk_commit_FLG.Checked == true)
            {
                Generate_RegistrationArrival(regArrival);
                Generate_RegistrationArrivalDetail(regArrivalDetail);
            }

        }
        //
        //
        //10.3.2.1 妥当な出庫データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 出庫ID
            if (String.IsNullOrEmpty(txt_SyID.Text))
            {
                MessageBox.Show("出庫IDは必須項目です");
                txt_SyID.Focus();
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
            //　出庫年月日
            if (String.IsNullOrEmpty(txt_SyDate.Text))
            {
                MessageBox.Show("出庫年月日は必須項目です");
                txt_SyDate.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 出庫ID
            if (!_ic.NumericCheck(txt_SyID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_SyHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyHidden.Focus();
                return false;
            }

            /////文字数チェック/////
            // 非表示理由
            if (txt_SyHidden.TextLength > 50)
            {
                MessageBox.Show("非表示理由は50文字以下です");
                txt_SyHidden.Focus();
                return false;
            }
            ////　文字チェック ////

            //　出庫年月日
            if (!_ic.DateFormCheck(txt_SyDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SyDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 10.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private T_Syukko GenerateDataAtUpdate()
        {
            int Flag = 0;                   //確定処理をフラグで判定
            if(chk_commit_FLG.Checked == true)
            {
                Flag = 1;
            }
            return new T_Syukko
            {
                SyID = int.Parse(txt_SyID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                SyDate = DateTime.Now,
                SyStateFlag = Flag,
                //SyFlag = HIDEFlag,
                SyHidden = txt_SyHidden.Text

            };
        }
        private T_SyukkoDetail GenerateDataAtUpdateDetail()
        {
            return new T_SyukkoDetail
            {
                SyDetailID = int.Parse(txt_SyDetailID.Text),
                SyID = int.Parse(txt_SyID.Text),
                PrID = int.Parse(txt_PrID.Text),
                SyQuantity = int.Parse(txt_ArQuantity.Text),

            };
        }
        private T_Arrival GenerateDataAtUpdateArrival()
        {
            return new T_Arrival
            {
                ArID = int.Parse(txt_SyID.Text),
                SoID = int.Parse(txt_SoID.Text),
                ClID = int.Parse(txt_ClID.Text),
                OrID = int.Parse(txt_OrID.Text),
                ArStateFlag = 0

            };
        }
        private T_ArrivalDetail GenerateDataAtUpdateArrivalDetail()
        {
            return new T_ArrivalDetail
            {
                ArDetailID = int.Parse(txt_SyDetailID.Text),
                ArID = int.Parse(txt_SyID.Text),
                PrID = int.Parse(txt_PrID.Text),
                ArQuantity = int.Parse(txt_ArQuantity.Text)

            };
        }
        //
        //
        // 10.2.3 出庫情報更新
        //
        //
        private bool SyukkoUpdate(T_Syukko regSyukko)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Sy.PutSyukko(regSyukko);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_SyID.Focus();

            return true;
        }
        private bool SyukkoDetailUpdate(T_SyukkoDetail regSyukkoDetail)
        {
            var errorMessage = _Sy.PutSyukkoDetail(regSyukkoDetail);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            txt_SyID.Focus();

            return true;
        }
        private bool Generate_RegistrationArrival(T_Arrival regArrival)
        {
            // 入荷情報の登録
            var errorMessage = _Ar.PostT_Arrival(regArrival);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;

        }
        private bool Generate_RegistrationArrivalDetail(T_ArrivalDetail regArrivalDetail)
        {
            // 入荷情報の登録
            var errorMessage = _Ar.PostT_ArrivalDetail(regArrivalDetail);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;

        }



        // 削除ボタン
        // 10.3 出庫情報削除
        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int ChID = int.Parse(txt_SyID.Text);
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
        private void Delete(int SyID)
        {
            // _it.DeletePrID(int.Parse(PrID));
            _Sy.DeleteSyukko(SyID);

            // データ取得&表示
            dataGridView_Syukko.DataSource = _Sy.GetDispSyukko();
        }




        // 入力クリア
        internal void ClearInput()
        {
            // 表示モード設定
            dataGridView_Syukko.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Syukko.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_SyID.Clear();
            txt_SoID.Clear();
            txt_EmID.Clear();
            txt_ClID.Clear();
            txt_OrID.Clear();
            txt_SyDate.Clear();
            txt_SyHidden.Clear();


            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_SyID.Focus();
        }

        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Syukko.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispSyukkoPaging = _Sy.GetDispSyukko();
            dataGridView_Syukko.DataSource = _dispSyukkoPaging;

            // 全データ数取得
            _recordCount = _dispSyukkoPaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Syukko.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
        private void dataGridView_Syukko_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Syukko.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Syukko.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Syukko.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Syukko.CurrentRow.Cells[3].Value;
            int id5 = (int)dataGridView_Syukko.CurrentRow.Cells[4].Value;
            DateTime id6 = (DateTime)dataGridView_Syukko.CurrentRow.Cells[5].Value;
            string id7 = (string)dataGridView_Syukko.CurrentRow.Cells[6].Value;
            string id8 = (string)dataGridView_Syukko.CurrentRow.Cells[7].Value;

            txt_SyID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_ClID.Text = Convert.ToString(id4);
            txt_OrID.Text = Convert.ToString(id5);
            txt_SyDate.Text = Convert.ToString(id6);
            txt_SyHidden.Text = Convert.ToString(id7);
            txt_memo.Text = Convert.ToString(id8);

        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Syukko WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 9; count++)
            {
                if (txt_SyID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@SyID", SqlDbType.VarChar);
                    command.Parameters["@SyID"].Value = txt_SyID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "SyID LIKE @SyID";
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
                    //if ("@EmID" != null || "@EmID != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmID LIKE @PrName ";
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
                else if (txt_SyDate.Text != "" && count == 5)
                {
                    command.Parameters.Add("@SyDate", SqlDbType.VarChar);
                    command.Parameters["@SyDate"].Value = txt_SyDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SyDate LIKE @SyDate ";
                    ++andnum;
                }
                else if (txt_SyHidden.Text != "" && count == 6)
                {
                    command.Parameters.Add("@SyHidden", SqlDbType.VarChar);
                    command.Parameters["@SyHidden"].Value = txt_SyHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SyHidden LIKE @SyHidden ";
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
                dataGridView_Syukko.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Syukko.Rows.Add(rd["SyID"], rd["SoID"], rd["EmID"], rd["ClID"],
                            rd["OrID"], rd["SyDate"], rd["SyHidden"], rd["memo"]);
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
            txt_SyID.Text = "";
            txt_SoID.Text = "";
            txt_EmID.Text = "";
            txt_ClID.Text = "";
            txt_OrID.Text = "";
            txt_SyDate.Text = "";
            txt_SyHidden.Text = "";
            txt_memo.Text = "";
        }

        private void lbl_memo_Click(object sender, EventArgs e)
        {

        }
    }
   
}

