﻿using System;
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
    public partial class F_Stock : MetroForm
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
        private T_StockContents _St = new T_StockContents();

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
        private IEnumerable<T_DispStock> _dispStockPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispChumon> _dispChumonPrinting;   // 印刷用データ
        int HIDEFlag;
        public F_Stock()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void F_Stock_Load(object sender, EventArgs e)
        {
            HIDEFlag = 0;

            F_login f_login = new F_login();
            transfer_int = f_login.transfer_int;

            btn_delete.Enabled = false;

            if (transfer_int == 1 ||
               transfer_int == 5)
            {
                btn_delete.Enabled = true;
            }

            dataGridView_Stock.ColumnCount = 3;

            dataGridView_Stock.Columns[0].HeaderText = "在庫ID ";
            dataGridView_Stock.Columns[1].HeaderText = "商品ID ";
            dataGridView_Stock.Columns[2].HeaderText = "在庫数 ";
            
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 登録ボタン
            // 4.1商品情報登録

            // 4.1.1妥当な商品情報取得
            if (!Get_Stock_Data_AtRegistration())
                return;

            // 4.1.2妥当な商品情報作成
            var regStock= Generate_Data_AtRegistration();

            // 4.1.3商品情報登録
            if (!Generate_Registration(regStock))
                return;
        }
        // 
        //
        //4.1.1　妥当な商品データ取得（新規登録）
        //
        //
        private bool Get_Stock_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 在庫ID
            if (String.IsNullOrEmpty(txt_StID.Text))
            {
                MessageBox.Show("在庫IDは必須項目です");
                txt_StID.Focus();
                return false;
            }
            // 商品ID
            if (String.IsNullOrEmpty(txt_PrID.Text))
            {
                MessageBox.Show("商品IDは必須項目です");
                txt_PrID.Focus();
                return false;
            }
            // 在庫数
            if (String.IsNullOrEmpty(txt_StQuantity.Text))
            {
                MessageBox.Show("在庫数は必須項目です");
                txt_StQuantity.Focus();
                return false;
            }
            //文字数チェック//
            // 在庫ID
            if (txt_StID.TextLength > 6)
            {
                MessageBox.Show("在庫IDは6文字以下です");
                txt_StID.Focus();
                return false;
            }
            // 商品ID
            if (txt_PrID.TextLength > 6)
            {
                MessageBox.Show("商品IDは6文字以下です");
                txt_PrID.Focus();
                return false;
            }
            // 在庫数
            if (txt_StQuantity.TextLength > 4)
            {
                MessageBox.Show("在庫数は4文字以下です");
                txt_StQuantity.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 在庫ID
            if (!_ic.NumericCheck(txt_StID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_StID.Focus();
                return false;
            }
            //　商品ID
            if (!_ic.NumericCheck(txt_PrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }

            // 在庫数
            if (!_ic.NumericCheck(txt_StQuantity.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_StQuantity.Focus();
                return false;
            }

            return true;
        }
        //
        //
        // 4.1.2 商品情報作成
        //
        //
        private T_Stock Generate_Data_AtRegistration()
        {
            if (chk_hide_FLG.Checked == false)
            {
                txt_StHidden.Text = "";
            }
            return new T_Stock
            {
                PrID = int.Parse(txt_PrID.Text),
                StFlag = 0,
                StQuantity = int.Parse(txt_StQuantity.Text)

            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(T_Stock regStock)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _St.PostT_Stock(regStock);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            fncAllSelect();
            txt_StID.Focus();

            return true;
        }
            // 更新ボタン
            // 4.2 商品情報更新
            private void btn_update_Click(object sender, EventArgs e)
            {
                // 4.2.1 妥当な商品データ取得
                if (!GetValidDataAtUpdate()) return;

                // 4.2.2 商品情報作成
                var regStock = GenerateDataAtUpdate();

            // 4.2.3 商品情報更新
            StockUpdate(regStock);

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

            ///// 入力内容の適否 /////

            // 在庫ID
            if (String.IsNullOrEmpty(txt_StID.Text))
            {
                MessageBox.Show("在庫IDは必須項目です");
                txt_StID.Focus();
                return false;
            }
            // 商品ID
            if (String.IsNullOrEmpty(txt_PrID.Text))
            {
                MessageBox.Show("商品IDは必須項目です");
                txt_PrID.Focus();
                return false;
            }
            //// 在庫数
            if (String.IsNullOrEmpty(txt_StQuantity.Text))
            {
                MessageBox.Show("在庫数は必須項目です");
                txt_StQuantity.Focus();
                return false;
            }

            //文字数チェック

            // 在庫ID
            if (txt_StID.TextLength > 6)
            {
                MessageBox.Show("在庫IDは6文字以下です");
                txt_StID.Focus();
                return false;
            }
            // 商品ID
            if (txt_PrID.TextLength > 6)
            {
                MessageBox.Show("商品IDは6文字以下です");
                txt_PrID.Focus();
                return false;
            }
            // 在庫数
            if (txt_StQuantity.TextLength > 4)
            {
                MessageBox.Show("在庫数は4文字以下です");
                txt_StQuantity.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 在庫ID
            if (!_ic.NumericCheck(txt_StID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_StID.Focus();
                return false;
            }
            //　商品ID
            if (!_ic.NumericCheck(txt_PrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PrID.Focus();
                return false;
            }
            // 在庫数
            if (!_ic.NumericCheck(txt_StQuantity.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_StQuantity.Focus();
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
            private T_Stock GenerateDataAtUpdate()
            {
            if (chk_hide_FLG.Checked == false)
            {
                txt_StHidden.Text = "";
            }
            if (chk_hide_FLG.Checked == true)
            {
                HIDEFlag = 1;
            }
            return new T_Stock
                {
                    StID = int.Parse(txt_StID.Text),
                    PrID = int.Parse(txt_PrID.Text),
                StFlag = HIDEFlag,
                //StQuantity = int.Parse(txt_StQuantity.Text)

            };
            }
            //
            //
            // 4.2.3 商品情報更新
            //
            //
            private bool StockUpdate(T_Stock regStock)
            {
                // 更新可否
                if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }

                var errorMessage = _St.PutStock(regStock);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }

            // 表示データ更新 & 入力クリア
            fncAllSelect();
            txt_StID.Focus();

                return true;
            }

            // 削除ボタン
            // 4.3 商品情報削除
            private void btn_delete_Click(object sender, EventArgs e)
            {
                // データ行番号を取得
                int StID = int.Parse(txt_StID.Text);
                using (var dcm = new DeleteConfirmForm())
                {
                    // 確認後、削除実行
                    if (dcm.ShowDialog(this) == DialogResult.OK) Delete(StID);
                }

                // 表示データ更新 & 入力クリア
                RefreshDataGridView();
            }

            // 削除処理
            // in      ChID: 削除するChID
            private void Delete(int StID)
            {
           
            _St.DeleteStock(StID);

            // データ取得&表示
            dataGridView_Stock.DataSource = _St.GetDispStock();
            }
            // 入力クリア
            internal void ClearInput()
            {
            // 表示モード設定
            dataGridView_Stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Stock.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_StID.Clear();
            txt_PrID.Clear();
            //txt_StQuantity.Clear();


            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_StID.Focus();
            }

            // 表示データ更新
            private void RefreshDataGridView()
            {
                // スクロール位置取得
                int ScrollPosition = dataGridView_Stock.FirstDisplayedScrollingRowIndex;

              // データ取得&表示（データバインド）
              _dispStockPaging = _St.GetDispStock();
              dataGridView_Stock.DataSource = _dispStockPaging;

                // 全データ数取得
                _recordCount = _dispStockPaging.Count();

                // スクロール位置セット
                if (0 < ScrollPosition) dataGridView_Stock.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
            command.CommandText = "SELECT * FROM T_Stock;";
            command.Connection = conn;
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            dataGridView_Stock.Rows.Clear();
            while (rd.Read())
            {
                dataGridView_Stock.Rows.Add(rd["StID"], rd["PrID"], rd["StQuantity"], rd["StFlag"]);
            }
        }
        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Stock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                int id = (int)dataGridView_Stock.CurrentRow.Cells[0].Value;
                int id2 = (int)dataGridView_Stock.CurrentRow.Cells[1].Value;
                int id3 = (int)dataGridView_Stock.CurrentRow.Cells[2].Value;
                int id4 = (int)dataGridView_Stock.CurrentRow.Cells[3].Value;

            txt_StID.Text = Convert.ToString(id);
            txt_PrID.Text = Convert.ToString(id2);
            txt_StQuantity.Text = Convert.ToString(id3);
            txt_memo.Text = Convert.ToString(id4);
            }

        

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Stock WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 5; count++)
            {
                if (txt_StID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@StID", SqlDbType.VarChar);
                    command.Parameters["@StID"].Value = txt_StID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "StID LIKE @StID ";
                    ++andnum;

                }
                else if (txt_PrID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@PrID", SqlDbType.VarChar);
                    command.Parameters["@PrID"].Value = txt_PrID.Text;
                    //if ("@SoID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrID LIKE @PrID ";
                    ++andnum;
                }
                else if (txt_StQuantity.Text != "" && count == 2)
                {
                    command.Parameters.Add("@StQuantity", SqlDbType.NVarChar);
                    command.Parameters["@StQuantity"].Value = "%" + txt_StQuantity.Text + "%";
                    //if ("@EmID" != null || "@EmID != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "StQuantity LIKE @StQuantity ";
                    ++andnum;
                }
                else if (txt_memo.Text != "" && count == 3)
                {
                    command.Parameters.Add("@memo", SqlDbType.VarChar);
                    command.Parameters["@memo"].Value = txt_memo.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "memo LIKE @memo ";
                    ++andnum;
                }
                else if (count == 4)
                {
                    command.Parameters.Add("@StFlag", SqlDbType.NVarChar);
                    command.Parameters["@StFlag"].Value = HIDEFlag;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "StFlag LIKE @StFlag ";
                    ++andnum;
                }

                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 4)
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
                dataGridView_Stock.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Stock.Rows.Add(rd["StID"], rd["PrID"], rd["StQuantity"], rd["memo"]);
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
            txt_StID.Text = "";
            txt_PrID.Text = "";
            txt_StQuantity.Text = "";
            txt_memo.Text = "";
        }
        private void Checked_Stock_HideFlag(object sender, EventArgs e)
        {
            if (chk_hide_FLG.Checked == true)
            {
                txt_StHidden.Text = "";
                HIDEFlag = 1;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            else if (chk_hide_FLG.Checked == false)
            {
                txt_StHidden.Text = "非表示理由を入力(50文字)";
                HIDEFlag = 0;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            return;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
    }
    

