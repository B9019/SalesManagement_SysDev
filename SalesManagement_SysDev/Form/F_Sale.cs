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
    public partial class F_Sale : MetroForm
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
        private T_SaleContents _Sa = new T_SaleContents();

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
        private IEnumerable<T_DispSale> _dispSalePaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispSale> _dispsalePrinting;                 // 印刷用データ

        public F_Sale()
        {
            InitializeComponent();
        }

        private void F_Sale_Load(object sender, EventArgs e)
        {
            売上管理ToolStripMenuItem.Enabled = false;
            dataGridView_Sale.ColumnCount = 8;

            dataGridView_Sale.Columns[0].HeaderText = "売上ID ";
            dataGridView_Sale.Columns[1].HeaderText = "顧客ID ";
            dataGridView_Sale.Columns[2].HeaderText = "営業所ID ";
            dataGridView_Sale.Columns[3].HeaderText = "受注社員ID";
            dataGridView_Sale.Columns[4].HeaderText = "受注ID";
            dataGridView_Sale.Columns[5].HeaderText = "売上年月日";
            dataGridView_Sale.Columns[6].HeaderText = "備考";
            dataGridView_Sale.Columns[7].HeaderText = "非表示理由";

        }

        // 登録ボタン
        // 7.1売上情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 7.1.1妥当な売上情報取得
            if (!Get_Sale_Data_AtRegistration())
                return;

            // 7.1.2妥当な売上情報作成
            var regSale = Generate_Data_AtRegistration();

            // 7.1.3売上情報登録
            if (!Generate_Registration(regSale))
                return;

        }

        // 
        //
        //7.1.1　妥当な売上データ取得（新規登録）
        //
        //
        private bool Get_Sale_Data_AtRegistration()
        {
            // 売上データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 売上ID
            if (String.IsNullOrEmpty(txt_SaID.Text))
            {
                MessageBox.Show("売上IDは必須項目です");
                txt_SaID.Focus();
                return false;
            }
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
            // 受注社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("受注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
                return false;
            }
            //　売上日時
            if (String.IsNullOrEmpty(txt_SaDate.Text))
            {
                MessageBox.Show("売上日時は必須項目です");
                txt_SaDate.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 売上ID
            if (!_ic.NumericCheck(txt_SaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaID.Focus();
                return false;
            }
            //　顧客ID
            if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            //  受注社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_SaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaHidden.Focus();
                return false;
            }

            // 　備考の文字チェック
            if (!_ic.FullWidthCharCheck(txt_Samemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Samemo.Focus();
                return false;
            }
            ////　日付型チェック　////
            if (!_ic.DateFormCheck(txt_SaDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaDate.Focus();
                return false;
            }

            /////文字数チェック/////
            // 売上ID
            if (txt_SaID.TextLength > 6)
            {
                MessageBox.Show("売上IDは6文字以下です");
                txt_SaID.Focus();
                return false;
            }
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
            //　受注社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("受注社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 売上日時
            if (txt_SaDate.TextLength > 10)
            {
                MessageBox.Show("売上日時は10文字以下です");
                txt_SaDate.Focus();
                return false;
            }
            //　非表示理由
            if (txt_SaDate.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_SaDate.Focus();
                return false;
            }
            //　備考
            if (txt_Samemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Samemo.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 7.1.2 売上情報作成
        //
        //
        private T_Sale Generate_Data_AtRegistration()
        {
            return new T_Sale
            {
                SaID = int.Parse(txt_SaID.Text),
                ClID = int.Parse(txt_ClID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                OrID = int.Parse(txt_OrID.Text),
                SaDate = DateTime.Parse(txt_SaDate.Text),
                SaHidden = txt_SaHidden.Text,
                Samemo = txt_Samemo.Text

            };

        }
        //
        //
        // 7.1.3　売上情報登録
        //
        //
        private bool Generate_Registration(T_Sale regSale)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 売上情報の登録
            var errorMessage = _Sa.PostT_Sale(regSale);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_SaID.Focus();

            return true;

        }
        // 表示データ更新
        private void RefreshDataGridView()
        {
            // スクロール位置取得
            int ScrollPosition = dataGridView_Sale.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispSalePaging = _Sa.GetDispSales();
            dataGridView_Sale.DataSource = _dispSalePaging;

            // 全データ数取得
            _recordCount = _dispSalePaging.Count();

            // スクロール位置セット
            if (0 < ScrollPosition) dataGridView_Sale.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
            dataGridView_Sale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // データグリッド選択解除
            dataGridView_Sale.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_SaID.Clear();
            txt_ClID.Clear();
            txt_SoID.Clear();
            txt_EmID.Clear();
            txt_OrID.Clear();
            txt_SaDate.Clear();
            txt_SaHidden.Clear();
            txt_Samemo.Clear();

            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_SaID.Focus();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // 7.2.1 妥当な売上データ取得
            if (!GetValidDataAtUpdate()) return;

            // 7.2.2 売上情報作成
            var regSale = GenerateDataAtUpdate();

            // 7.2.3 売上情報更新
            SaleUpdate(regSale);

        }

        //
        //
        // 7.3.2.1 妥当な売上データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
        {
            // 売上データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 売上ID
            if (String.IsNullOrEmpty(txt_SaID.Text))
            {
                MessageBox.Show("売上IDは必須項目です");
                txt_SaID.Focus();
                return false;
            }
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
            // 受注社員ID
            if (String.IsNullOrEmpty(txt_EmID.Text))
            {
                MessageBox.Show("受注社員IDは必須項目です");
                txt_EmID.Focus();
                return false;
            }
            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
                return false;
            }
            //　売上日時
            if (String.IsNullOrEmpty(txt_SaDate.Text))
            {
                MessageBox.Show("売上日時は必須項目です");
                txt_SaDate.Focus();
                return false;
            }

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 売上ID
            if (!_ic.NumericCheck(txt_SaID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaID.Focus();
                return false;
            }
            //　顧客ID
            if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClID.Focus();
                return false;
            }
            // 営業所ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            //  受注社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_SaHidden.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaHidden.Focus();
                return false;
            }

            // 　備考の文字チェック
            if (!_ic.FullWidthCharCheck(txt_Samemo.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_Samemo.Focus();
                return false;
            }
            ////　日付型チェック　////
            if (!_ic.DateFormCheck(txt_SaDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SaDate.Focus();
                return false;
            }

            /////文字数チェック/////
            // 売上ID
            if (txt_SaID.TextLength > 6)
            {
                MessageBox.Show("売上IDは6文字以下です");
                txt_SaID.Focus();
                return false;
            }
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
            //　受注社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("受注社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 売上日時
            if (txt_SaDate.TextLength > 10)
            {
                MessageBox.Show("売上日時は10文字以下です");
                txt_SaDate.Focus();
                return false;
            }
            //　非表示理由
            if (txt_SaDate.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_SaDate.Focus();
                return false;
            }
            //　備考
            if (txt_Samemo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_Samemo.Focus();
                return false;
            }
            return true;

        }
        //
        //
        //　7.2.2 カテゴリー情報作成
        //
        //
        // out      Sale : Saleデータ
        private T_Sale GenerateDataAtUpdate()
        {
            return new T_Sale
            {
                SaID = int.Parse(txt_SaID.Text),
                ClID = int.Parse(txt_ClID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                OrID = int.Parse(txt_OrID.Text),
                SaDate = DateTime.Parse(txt_SaDate.Text),
                SaHidden = txt_SaHidden.Text,
                Samemo = txt_Samemo.Text

            };
        }
        //
        //
        // 7.2.3 商品情報更新
        //
        //
        private bool SaleUpdate(T_Sale regSale)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Sa.PutSale(regSale);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();
            txt_SaID.Focus();

            return true;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            fncAllSelect();

        }
        private void fncAllSelect()
        {
            // データ取得&表示（データバインド）
            _dispSalePaging = _Sa.GetDispSales();
            dataGridView_Sale.DataSource = _dispSalePaging;

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
        // 7.3 売上情報削除

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // データ行番号を取得
            int SaID = int.Parse(txt_SaID.Text);
            using (var dcm = new DeleteConfirmForm())
            {
                // 確認後、削除実行
                if (dcm.ShowDialog(this) == DialogResult.OK) Delete(SaID);
            }

            // 表示データ更新 & 入力クリア
            RefreshDataGridView();

        }
        // 削除処理
        // in       SaID : 削除するSaID
        private void Delete(int SaID)
        {
            // _it.DeletePrID(int.Parse(PrID));
            _Sa.DeleteSale(SaID);

            // データ取得&表示
            dataGridView_Sale.DataSource = _Sa.GetDispSales();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Sale WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 8; count++)
            {
                if (txt_SaID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@SaID", SqlDbType.VarChar);
                    command.Parameters["@SaID"].Value = txt_SaID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "SaID LIKE @SaID ";
                    ++andnum;

                }
                else if (txt_ClID.Text != "" && count == 1)
                {
                    command.Parameters.Add("@ClID", SqlDbType.VarChar);
                    command.Parameters["@ClID"].Value = txt_ClID.Text;
                    //if ("@PrID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ClID LIKE @ClID ";
                    ++andnum;
                }
                else if (txt_SoID.Text != "" && count == 2)
                {
                    command.Parameters.Add("@SoID", SqlDbType.NVarChar);
                    command.Parameters["@SoID"].Value = txt_SoID.Text;
                    //if ("@PrID" != null || "@MaID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SoID LIKE @SoID ";
                    ++andnum;
                }
                else if (txt_EmID.Text != "" && count == 3)
                {
                    command.Parameters.Add("@EmID", SqlDbType.VarChar);
                    command.Parameters["@EmID"].Value = txt_EmID.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "EmID LIKE @EmID ";
                    ++andnum;
                }
                else if (txt_OrID.Text != "" && count == 4)
                {
                    command.Parameters.Add("@OrID", SqlDbType.VarChar);
                    command.Parameters["@OrID"].Value = txt_OrID.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "OrID LIKE @OrID ";
                    ++andnum;
                }
                else if (txt_SaDate.Text != "" && count == 5)
                {
                    command.Parameters.Add("@SaDate", SqlDbType.VarChar);
                    command.Parameters["@SaDate"].Value = txt_SaDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SaDate LIKE @SaDate ";
                    ++andnum;
                }
                else if (txt_SaHidden.Text != "" && count == 6)
                {
                    command.Parameters.Add("@SaHidden", SqlDbType.NVarChar);
                    command.Parameters["@SaHidden"].Value = txt_SaHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "SaHidden LIKE @SaHidden ";
                    ++andnum;
                }
                else if (txt_Samemo.Text != "" && count == 7)
                {
                    command.Parameters.Add("@Samemo", SqlDbType.NVarChar);
                    command.Parameters["@Samemo"].Value = txt_SaHidden.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Samemo LIKE @Samemo ";
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
                dataGridView_Sale.Rows.Clear();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Sale.Rows.Add(rd["SaID"], rd["ClID"], rd["SoID"], rd["EmID"],
                            rd["OrID"], rd["SaDate"], rd["SaHidden"], rd["Samemo"]);
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

        }

        private void dataGridView_Sale_CelldoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView_Sale.CurrentRow.Cells[0].Value;
            int id2 = (int)dataGridView_Sale.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Sale.CurrentRow.Cells[2].Value;
            int id4 = (int)dataGridView_Sale.CurrentRow.Cells[3].Value;
            int id5 = (int)dataGridView_Sale.CurrentRow.Cells[4].Value;
            int id6 = (int)dataGridView_Sale.CurrentRow.Cells[5].Value;
            int id7 = (int)dataGridView_Sale.CurrentRow.Cells[6].Value;
            int id8 = (int)dataGridView_Sale.CurrentRow.Cells[7].Value;
            string id9 = (string)dataGridView_Sale.CurrentRow.Cells[8].Value;
            DateTime id10 = (DateTime)dataGridView_Sale.CurrentRow.Cells[9].Value;
            int id11 = (int)dataGridView_Sale.CurrentRow.Cells[10].Value;
            string id12 = (string)dataGridView_Sale.CurrentRow.Cells[11].Value;
            string id13 = (string)dataGridView_Sale.CurrentRow.Cells[12].Value;

            txt_SaID.Text = Convert.ToString(id);
            txt_ClID.Text = Convert.ToString(id2);
            txt_SoID.Text = Convert.ToString(id3);
            txt_EmID.Text = Convert.ToString(id4);
            txt_OrID.Text = Convert.ToString(id5);
            txt_SaDate.Text = Convert.ToString(id6);
            txt_SaHidden.Text = Convert.ToString(id7);
            txt_Samemo.Text = Convert.ToString(id8);

        }
    }
}
