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
    public partial class F_Chumon : MetroForm
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
        private T_ChumonContents _Ch = new T_ChumonContents();
        private T_StockContents _St = new T_StockContents();
        private T_SyukkoContents _Sy = new T_SyukkoContents();

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
        private IEnumerable<T_DispChumon> _dispChumonPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispChumon> _dispChumonPrinting;   // 印刷用データ
        int HIDEFlag;

        int StockNum;                                   //在庫数変更用の変数

        public F_Chumon()
        {
            InitializeComponent();
        }

        private void F_Chumon_Load(object sender, EventArgs e)
        {
            btn_chumon.Enabled = false;
            dataGridView_Chumon.ColumnCount = 13;

            btn_regist.Enabled = false; //受注処理の時点で注文テーブルに共通項目は登録されているので、この画面では更新処理でデータを追加するべき。
            btn_search.Enabled = false; //検索処理はこの画面には必要ない
            StockNum = 0;

            dataGridView_Chumon.Columns[0].HeaderText = "注文ID ";
            dataGridView_Chumon.Columns[1].HeaderText = "営業所ID ";
            dataGridView_Chumon.Columns[2].HeaderText = "社員ID ";
            dataGridView_Chumon.Columns[3].HeaderText = "顧客ID";
            dataGridView_Chumon.Columns[4].HeaderText = "受注ID";
            dataGridView_Chumon.Columns[5].HeaderText = "注文年月日 ";
            dataGridView_Chumon.Columns[6].HeaderText = "注文状態フラグ";
            dataGridView_Chumon.Columns[7].HeaderText = "注文管理フラグ";
            dataGridView_Chumon.Columns[8].HeaderText = "非表示理由";
            dataGridView_Chumon.Columns[9].HeaderText = "注文詳細ID";
            dataGridView_Chumon.Columns[10].HeaderText = "商品ID";
            dataGridView_Chumon.Columns[11].HeaderText = "数量";
            dataGridView_Chumon.Columns[12].HeaderText = "備考";

            HIDEFlag = 0;

            F_login f_login = new F_login();
            transfer_int = f_login.transfer_int;

            btn_delete.Enabled = false;

            if (transfer_int == 1 ||
               transfer_int == 5)
            {
                btn_delete.Enabled = true;
            }
        }

       



    private void btn_regist_Click(object sender, EventArgs e)
        {
            // 登録ボタン
            // 19.1注文情報登録

            // 19.1.1妥当な注文情報取得
            if (!Get_Chumon_Data_AtRegistration())
                    return;

            // 19.1.2妥当な注文情報作成
            var regChumon = Generate_Data_AtRegistration();

            // 19.1.3注文情報登録
            if (!Generate_Registration(regChumon))
                    return;

        }
        // 
        //
        //19.1.1　妥当な注文データ取得（新規登録）
        //
        //
        private bool Get_Chumon_Data_AtRegistration()
            {
                // 注文データの形式チェック
                string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 注文ID
            if (String.IsNullOrEmpty(txt_ChID.Text))
                {
                    MessageBox.Show("注文IDは必須項目です");
                txt_ChID.Focus();
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
            //　注文年月日
            if (String.IsNullOrEmpty(txt_ChDate.Text))
                {
                    MessageBox.Show("注文年月日は必須項目です");
                txt_ChDate.Focus();
                    return false;
                }
            

            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 注文ID
            if (!_ic.NumericCheck(txt_ChID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                txt_ChID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_ChHidden.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                txt_ChHidden.Focus();
                    return false;
                }

                /////文字数チェック/////
                // 非表示理由
                if (txt_ChHidden.TextLength > 50)
                {
                    MessageBox.Show("メーカIDは50文字以下です");
                txt_ChHidden.Focus();
                    return false;
                }
            ////　文字チェック ////

            //　注文年月日
            if (!_ic.DateFormCheck(txt_ChDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ChDate.Focus();
                return false;
            }
            return true;
            }
        //
        //
        // 19.1.2 注文情報作成
        //
        //
        private T_Chumon Generate_Data_AtRegistration()
            {
            if (chk_hide_FLG.Checked == false)
            {
                txt_ChHidden.Text = "";
            }
            return new T_Chumon
                {
                    ChID = int.Parse(txt_ChID.Text),
                    SoID = int.Parse(txt_SoID.Text),
                    EmID = int.Parse(txt_EmID.Text),
                    ClID = int.Parse(txt_ClID.Text),
                    OrID = int.Parse(txt_OrID.Text),
                    ChDate = DateTime.Parse(txt_ChDate.Text),
                ChFlag = 0,
                ChHidden = txt_ChHidden.Text

                };

            }
        //
        //
        // 19.1.3　注文情報登録
        //
        //
        private bool Generate_Registration(T_Chumon regChumon)
            {
                // 登録可否
                if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }
                // 商品情報の登録
                var errorMessage = _Ch.PostT_Chumon(regChumon);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }
                // 画面更新
                RefreshDataGridView();
                txt_ChID.Focus();

                return true;

            }

        // 更新ボタン
        // 19.2 注文情報更新
        private void btn_update_Click(object sender, EventArgs e)
            {
            // 19.2.1 妥当な注文データ取得
            if (!GetValidDataAtUpdate()) return;

            // 19.2.2 注文情報作成
            var regChumon = GenerateDataAtUpdate();
            var regChumonDetail = GenerateDataAtUpdateDetail();
            var regStock = GenerateDataAtUpdate_Stock();
            var regSyukko = Generate_Registration_Syukko();
            var regSyukkoDetail = Generate_Registration_SyukkoDetail();

            // 19.2.3 注文情報更新
            ChumonUpdate(regChumon);
            ChumonDetailUpdate(regChumonDetail);
            if (chk_commit_FLG.Checked == true)
            {
                StockUpdate(regStock);
                Generate_Registration_Syukko(regSyukko);
                Generate_Registration_SyukkoDetail(regSyukkoDetail);

            }


        }
        //
        //
        // 19.3.2.1 妥当な注文データ取得（更新）
        //
        //
        private bool GetValidDataAtUpdate()
            {
                // 注文データの形式チェック
                string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 注文ID
            if (String.IsNullOrEmpty(txt_ChID.Text))
            {
                MessageBox.Show("注文IDは必須項目です");
                txt_ChID.Focus();
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
            //　注文年月日
            if (String.IsNullOrEmpty(txt_ChDate.Text))
            {
                MessageBox.Show("注文年月日は必須項目です");
                txt_ChDate.Focus();
                return false;
            }
            // 非表示理由
            if (String.IsNullOrEmpty(txt_ChHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_ChHidden.Focus();
                return false;
            } // 注文ID
            if (String.IsNullOrEmpty(txt_ChID.Text))
            {
                MessageBox.Show("注文IDは必須項目です");
                txt_ChID.Focus();
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
            //　注文年月日
            if (String.IsNullOrEmpty(txt_ChDate.Text))
            {
                MessageBox.Show("注文年月日は必須項目です");
                txt_ChDate.Focus();
                return false;
            }
            // 非表示理由
            if (String.IsNullOrEmpty(txt_ChHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_ChHidden.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 注文ID
            if (!_ic.NumericCheck(txt_ChID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                txt_ChID.Focus();
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
            if (!_ic.FullWidthCharCheck(txt_ChHidden.Text, out errorMessage))
            {
                    MessageBox.Show(errorMessage);
                txt_ChHidden.Focus();
                    return false;
                }

                /////文字数チェック/////
                // 非表示理由
                if (txt_ChHidden.TextLength > 50)
                {
                    MessageBox.Show("メーカIDは50文字以下です");
                txt_ChHidden.Focus();
                    return false;
                }

            // 注文ID
            if (txt_ChID.TextLength > 6)
            {
                MessageBox.Show("注文IDは6文字以下です");
                txt_ChID.Focus();
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
            //　受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            //　注文年月日
            if (txt_ChDate.TextLength > 10)
            { 
                MessageBox.Show("注文年月日は10文字以下です");
                txt_ChDate.Focus();
                return false;
            }
            // 備考
            if (txt_memo.TextLength > 30)
            {
                MessageBox.Show("備考は30文字以下です");
                txt_memo.Focus();
                return false;
            }
            // 非表示理由
            if (txt_ChHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_ChHidden.Focus();
                return false;
            }
           
            ////　文字チェック ////

            //　注文年月日
            if (!_ic.DateFormCheck(txt_ChDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ChDate.Focus();
                return false;
            }
            return true;
            }
        //
        //
        // 19.2.2 カテゴリー情報作成
        //
        //
        // out      Category : Categoryデータ
        private T_Chumon GenerateDataAtUpdate()
            {
            if (chk_hide_FLG.Checked == false)
            {
                txt_ChHidden.Text = "";
            }
            if(chk_hide_FLG.Checked == true)
            {
                HIDEFlag = 1;
            }
                return new T_Chumon
                {

                    ChID = int.Parse(txt_ChID.Text),
                    SoID = int.Parse(txt_SoID.Text),
                    EmID = int.Parse(txt_EmID.Text),
                    ClID = int.Parse(txt_ClID.Text),
                    OrID = int.Parse(txt_OrID.Text),
                    ChDate = DateTime.Now,
                    ChFlag = HIDEFlag,
                    ChHidden = txt_ChHidden.Text

                };
            }
        private T_ChumonDetail GenerateDataAtUpdateDetail()
        {
            return new T_ChumonDetail
            {
                ChDetailID = int.Parse(txt_ChDetailID.Text),
                ChID2 = int.Parse(txt_ChID.Text),
                PrID = int.Parse(txt_PrID.Text),
                ChQuantity = int.Parse(txt_ChQuantity.Text)

            };
        }


        private T_Stock GenerateDataAtUpdate_Stock()
        {
            //if (chk_commit_FLG.Checked == true)
            {

            }
            StockNum = 0;
            int StID_L  = 0;
            int PrID_L  = 0;
            int StQuantity_L = 0;
            int StFlag_L = 0;
            int ChQuantity_L = int.Parse(txt_ChQuantity.Text);
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Stock WHERE PrID LIKE @PrID";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            command.Parameters.Add("@PrID", SqlDbType.VarChar);
            command.Parameters["@PrID"].Value = txt_PrID.Text;
                //データベースに接続
                conn.Open();
                //SQL文の実行、データが  readerに格納される
                SqlDataReader rd = command.ExecuteReader();
                if (rd.HasRows)
                {
                    StID_L = (int)rd["StID"];
                    PrID_L = (int)rd["PrID"];
                    StQuantity_L = (int)rd["StQuantity"];
                    StFlag_L = (int)rd["StFlag"];
                    StockNum = StQuantity_L - ChQuantity_L;//在庫数更新用の変数に値を代入

                }

            return new T_Stock
            {
                StID = StID_L,
                PrID = PrID_L,
                StQuantity = StockNum,
                StFlag = StFlag_L
            };

        }
        private T_Syukko Generate_Registration_Syukko()
        {
            return new T_Syukko
            {
                SyID = int.Parse(txt_ChID.Text),
                ClID = int.Parse(txt_ClID.Text),
                SoID = int.Parse(txt_SoID.Text),
                OrID = int.Parse(txt_OrID.Text),
                SyStateFlag = 0
            };
        }
        private T_SyukkoDetail Generate_Registration_SyukkoDetail()
        {
            return new T_SyukkoDetail
            {
                SyDetailID = int.Parse(txt_ChDetailID.Text),
                SyID = int.Parse(txt_ChID.Text),
                PrID = int.Parse(txt_PrID.Text),
                SyQuantity = StockNum
            };
        }
        //
        //
        // 19.2.3 注文情報更新
        //
        //
        private bool ChumonUpdate(T_Chumon regChumon)
            {
                // 更新可否
                if (DialogResult.OK != MessageBox.Show(this, "更新してよろしいですか", "更新可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }

                var errorMessage = _Ch.PutChumon(regChumon);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }


                return true;
            }
        private bool ChumonDetailUpdate(T_ChumonDetail regChumonDetail)
        {
            var errorMessage = _Ch.PutChumonDetail(regChumonDetail);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        private bool StockUpdate(T_Stock regStock)
        {
            var errorMessage = _St.PutStockCh(regStock);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }
        private bool Generate_Registration_Syukko(T_Syukko regSyukko)
        {
            // 出庫情報の登録
            var errorMessage = _Sy.PostT_Syukko(regSyukko);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;

        }
        private bool Generate_Registration_SyukkoDetail(T_SyukkoDetail regSyukkoDetail)
        {
            // 出庫詳細情報の登録
            var errorMessage = _Sy.PostT_SyukkoDetail(regSyukkoDetail);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;

        }

        // 削除ボタン
        // 19.3 注文情報削除
        private void btn_delete_Click(object sender, EventArgs e)
            {
                // データ行番号を取得
                int ChID = int.Parse(txt_ChID.Text);
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
        private void Delete(int ChID)
            {
            // _it.DeletePrID(int.Parse(PrID));
            _Ch.DeleteChumon(ChID);

            // データ取得&表示
            dataGridView_Chumon.DataSource = _Ch.GetDispChumon();
            }




            // 入力クリア
            internal void ClearInput()
            {
                // 表示モード設定
                dataGridView_Chumon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // データグリッド選択解除
                dataGridView_Chumon.ClearSelection();

            // テキストボックス＆コンボボックスクリア
            txt_ChID.Clear();
            txt_SoID.Clear();
            txt_EmID.Clear();
            txt_ClID.Clear();
            txt_OrID.Clear();
            txt_ChDate.Clear();
            txt_ChHidden.Clear();


            //// ボタンリセット
            //btn_regist.Enabled = true;
            //buttonUpdate.Enabled = false;
            //buttonDelete.Enabled = false;

            // コード改変無効処置リセット
            //txt_MaID.Enabled = false;

            // 入力フォーカスリセット
            txt_ChID.Focus();
            }

            // 表示データ更新
            private void RefreshDataGridView()
            {
                // スクロール位置取得
                int ScrollPosition = dataGridView_Chumon.FirstDisplayedScrollingRowIndex;

            // データ取得&表示（データバインド）
            _dispChumonPaging = _Ch.GetDispChumon();
                dataGridView_Chumon.DataSource = _dispChumonPaging;

                // 全データ数取得
                _recordCount = _dispChumonPaging.Count();

                // スクロール位置セット
                if (0 < ScrollPosition) dataGridView_Chumon.FirstDisplayedScrollingRowIndex = ScrollPosition;

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
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";
            //command.Parameters.Add("@PrFlag", SqlDbType.VarChar);
            //command.Parameters["@PrFlag"].Value = "0";
            command.CommandText = "SELECT * FROM T_Chumon WHERE ChFlag = 0;";
            command.Connection = conn;
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            dataGridView_Chumon.Rows.Clear();
            while (rd.Read())
            {
                dataGridView_Chumon.Rows.Add(rd["ChID"], rd["SoID"], rd["EmID"], rd["ClID"],
                    rd["OrID"], rd["ChDate"], rd["ChHidden"],rd["ChStateFlag"],rd["ChFlag"], rd["memo"]);
            }
        }

        //データグリッドビューデータグリッドビューのデータをテキストボックスに表示
        private void dataGridView_Product_regist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                int id = (int)dataGridView_Chumon.CurrentRow.Cells[0].Value;
                int id2 = (int)dataGridView_Chumon.CurrentRow.Cells[1].Value;
            int id3 = (int)dataGridView_Chumon.CurrentRow.Cells[2].Value;
                int id4 = (int)dataGridView_Chumon.CurrentRow.Cells[3].Value;
            int id5 = (int)dataGridView_Chumon.CurrentRow.Cells[4].Value;
            DateTime id6 = (DateTime)dataGridView_Chumon.CurrentRow.Cells[5].Value;
            string id7 = (string)dataGridView_Chumon.CurrentRow.Cells[6].Value;
            string id8 = (string)dataGridView_Chumon.CurrentRow.Cells[7].Value;
               
            txt_ChID.Text = Convert.ToString(id);
            txt_SoID.Text = Convert.ToString(id2);
            txt_EmID.Text = Convert.ToString(id3);
            txt_ClID.Text = Convert.ToString(id4);
            txt_OrID.Text = Convert.ToString(id5);
            txt_ChDate.Text = Convert.ToString(id6);
            txt_ChHidden.Text = Convert.ToString(id7);
                txt_memo.Text = Convert.ToString(id8);

            }
        private void btn_search_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\81807\DESKTOP\SALESMANAGEMENT_SYSDEV\SALESMANAGEMENT_SYSDEV.SALESMANAGEMENT_DEVCONTEXT.MDF;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Chumon WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 9; count++)
            {
                if (txt_ChID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@ChID", SqlDbType.VarChar);
                    command.Parameters["@ChID"].Value = txt_ChID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "ChID LIKE @ChID ";
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
                    command.Parameters.Add("@EmID", SqlDbType.VarChar);
                    command.Parameters["@EmID"].Value =  txt_EmID.Text ;
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
                    command.Parameters["@OrID"].Value = txt_OrID.Text ;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "OrID LIKE @OrID ";
                    ++andnum;
                }
                else if (txt_ChDate.Text != "" && count == 5)
                {
                    command.Parameters.Add("@ChDate", SqlDbType.VarChar);
                    command.Parameters["@ChDate"].Value = txt_ChDate.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ChDate LIKE @ChDate ";
                    ++andnum;
                }
                else if (txt_ChHidden.Text != "" && count == 6)
                {
                    command.Parameters.Add("@ChHidden", SqlDbType.NVarChar);
                    command.Parameters["@ChHidden"].Value = "%"+txt_ChHidden.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ChHidden LIKE @ChHidden ";
                    ++andnum;
                }

                else if (txt_memo.Text != "" && count == 7)
                {
                    command.Parameters.Add("@memo", SqlDbType.NVarChar);
                    command.Parameters["@memo"].Value = "%" + txt_memo.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "memo LIKE @memo ";
                    ++andnum;
                }
                else if (count == 8)
                {
                    command.Parameters.Add("@ChFlag", SqlDbType.NVarChar);
                    command.Parameters["@ChFlag"].Value = HIDEFlag;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ChFlag LIKE @ChFlag ";
                    ++andnum;
                }

                //2つ目以降の条件の前部にANDを接続
                if (andnum != 0)
                {
                    AND = "AND ";
                }
                //最後にセミコロンを接続する
                while (count == 8)
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
                dataGridView_Chumon.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Chumon.Rows.Add(rd["ChID"], rd["SoID"], rd["EmID"], rd["ClID"],
                            rd["OrID"], rd["ChDate"], rd["ChHidden"],rd["memo"]);
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
            txt_ChID.Text = "";
            txt_SoID.Text = "";
            txt_EmID.Text = "";
            txt_ClID.Text = "";
            txt_OrID.Text = "";
            txt_ChDate.Text = "";
            txt_ChHidden.Text = "";
            txt_memo.Text = "";
        }

        private void Checked_Chumon_HideFlag(object sender, EventArgs e)
        {
            if (chk_hide_FLG.Checked == true)
            {
                txt_ChHidden.Text = "";
                HIDEFlag = 1;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            else if (chk_hide_FLG.Checked == false)
            {
                txt_ChHidden.Text = "非表示理由を入力(50文字)";
                HIDEFlag = 0;   //検索する際の非表示フラグの非表示状態を保存(0：表示　1：非表示)
            }
            return;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
   

       
}
