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

namespace SalesManagement_SysDev
{
    public partial class F_Order : Form
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

        //// データベース処理モジュール（T_Division）
        private T_OrderContents _Or = new T_OrderContents();

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
        private IEnumerable<T_DispOrder> _disOrderPaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<T_DispOrder> _dispOrderPrinting;                 // 印刷用データ
        public F_Order()
        {
            InitializeComponent();
        }

        private void txt_OrID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SoID_TextChanged(object sender, EventArgs e)
        {

        }

        private void F_Order_Load(object sender, EventArgs e)
        {
            受注管理ToolStripMenuItem.Enabled = false;
        }

        // 登録ボタン
        // 8.1受注情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 8.1.1妥当な受注情報取得
            if (!Get_Order_Data_AtRegistration())
                return;

            // 8.1.2妥当な受注情報作成
            var regOrder = Generate_Data_AtRegistration();

            // 8.1.3受注情報登録
            if (!Generate_Registration(regOrder))
                return;
        }
        // 
        //
        //8.1.1　妥当な受注データ取得（新規登録）
        //
        //
        private bool Get_Order_Data_AtRegistration()
        {
            // 受注データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 受注ID
            if (String.IsNullOrEmpty(txt_OrID.Text))
            {
                MessageBox.Show("受注IDは必須項目です");
                txt_OrID.Focus();
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
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
            {
                MessageBox.Show("顧客IDは必須項目です");
                txt_ClID.Focus();
                return false;
            }
            // 顧客担当者名
            if (String.IsNullOrEmpty(txt_ClCharge.Text))
            {
                MessageBox.Show("顧客担当者名は必須項目です");
                txt_ClCharge.Focus();
                return false;
            }
            //　受注年月日
            if (String.IsNullOrEmpty(txt_OrDate.Text))
            {
                MessageBox.Show("受注年月日は必須項目です");
                txt_OrDate.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 受注ID
            if (!_ic.NumericCheck(txt_OrID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrID.Focus();
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
            // 顧客担当者名
            if (!_ic.NumericCheck(txt_ClCharge.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClCharge.Focus();
                return false;
            }
            // 受注年月日
            if (!_ic.NumericCheck(txt_OrDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrDate.Focus();
                return false;
            }

            ////　文字チェック ////

            //　顧客担当者名の文字チェック
            if (!_ic.FullWidthCharCheck(txt_ClCharge.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_ClCharge.Focus();
                return false;
            }
            // 　受注年月日の文字チェック
            if (!_ic.FullWidthCharCheck(txt_OrDate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_OrDate.Focus();
                return false;
            }

            /////文字数チェック/////
            // 受注ID
            if (txt_OrID.TextLength > 6)
            {
                MessageBox.Show("受注IDは6文字以下です");
                txt_OrID.Focus();
                return false;
            }
            // 営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2字以下です");
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
            if (txt_ClID.TextLength > 6)
            {
                MessageBox.Show("顧客IDは6文字以下です");
                txt_ClID.Focus();
                return false;
            }
            // 顧客担当者名
            if (txt_ClCharge.TextLength > 50)
            {
                MessageBox.Show("顧客担当者名は50文字以下です");
                txt_ClCharge.Focus();
                return false;
            }
            // 受注年月日
            if (txt_OrDate.TextLength > 10)
            {
                MessageBox.Show("受注年月日は10文字以下です");
                txt_OrDate.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 8.1.2 受注情報作成
        //
        //
        private T_Order Generate_Data_AtRegistration()
        {
            return new T_Order
            {
                OrID = int.Parse(txt_OrID.Text),
                SoID = int.Parse(txt_SoID.Text),
                EmID = int.Parse(txt_EmID.Text),
                ClID = int.Parse(txt_ClID.Text),
                ClCharge = txt_ClCharge.Text,
                OrDate = DateTime.Parse(txt_OrDate.Text),
                OrHidden = OrHidden.Text,
            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(M_Product regProduct)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Pr.PostM_Product(regProduct);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }
            // 画面更新
            RefreshDataGridView();
            txt_MaID.Focus();

            return true;

        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM T_Order WHERE ";
            command.Connection = conn;

            //sql文のwhere句の接続に使う
            string AND = "";
            int andnum = 0;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            for (int count = 0; count < 11; count++)
            {
                if (txt_PrID.Text != "" && count == 0)
                {
                    command.Parameters.Add("@PrID", SqlDbType.VarChar);
                    command.Parameters["@PrID"].Value = txt_PrID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + "PrID LIKE @PrID ";
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
                else if (txt_PrName.Text != "" && count == 2)
                {
                    command.Parameters.Add("@PrName", SqlDbType.NVarChar);
                    command.Parameters["@PrName"].Value = "%" + txt_PrName.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrName LIKE @PrName ";
                    ++andnum;
                }
                else if (txt_Price.Text != "" && count == 3)
                {
                    command.Parameters.Add("@Price", SqlDbType.VarChar);
                    command.Parameters["@Price"].Value = txt_Price.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "Price LIKE @Price ";
                    ++andnum;
                }
                else if (txt_PrJCode.Text != "" && count == 4)
                {
                    command.Parameters.Add("@PrJCode", SqlDbType.VarChar);
                    command.Parameters["@PrJCode"].Value = "%" + txt_PrJCode.Text + "%";
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null)
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrJCode LIKE @PrJCode ";
                    ++andnum;
                }
                else if (txt_PrSafetyStock.Text != "" && count == 5)
                {
                    command.Parameters.Add("@PrSafetyStock", SqlDbType.VarChar);
                    command.Parameters["@PrSafetyStock"].Value = txt_PrSafetyStock.Text;
                    //if ("@PrID" != null || "@MaID" != null || "@Price" != null || "@PrJCode" != null || )
                    //{
                    //    command.CommandText = command + "AND ";
                    //}
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrSafetyStock LIKE @PrSafetyStock ";
                    ++andnum;
                }
                else if (txt_ScID.Text != "" && count == 6)
                {
                    command.Parameters.Add("@ScID", SqlDbType.VarChar);
                    command.Parameters["@ScID"].Value = txt_ScID.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "ScID LIKE @ScID ";
                    ++andnum;
                }
                else if (txt_PrModelNumber.Text != "" && count == 7)
                {
                    command.Parameters.Add("@PrModelNumber", SqlDbType.VarChar);
                    command.Parameters["@PrModelNumber"].Value = txt_PrModelNumber.Text;
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrModelNumber LIKE @PrModelNumber ";
                    ++andnum;
                }
                else if (txt_PrColor.Text != "" && count == 8)
                {
                    command.Parameters.Add("@PrColor", SqlDbType.NVarChar);
                    command.Parameters["@PrColor"].Value = "%" + txt_PrColor.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrColor LIKE @PrColor ";
                    ++andnum;
                }
                else if (txt_PrReleaseDate.Text != "" && count == 9)
                {
                    command.Parameters.Add("@PrReleaseDate", SqlDbType.VarChar);
                    command.Parameters["@PrReleaseDate"].Value = "%" + txt_PrReleaseDate.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrReleaseDate LIKE @PrReleaseDate ";
                    ++andnum;
                }
                else if (txt_PrHidden.Text != "" && count == 10)
                {
                    command.Parameters.Add("@PrHidden", SqlDbType.NVarChar);
                    command.Parameters["@PrHidden"].Value = "%" + txt_PrHidden.Text + "%";
                    //実行するSQL文の条件追加
                    command.CommandText = command.CommandText + AND + "PrHidden LIKE @PrHidden ";
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
                dataGridView_Product.Rows.Clear();


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView_Product.Rows.Add(rd["PrID"], rd["MaID"], rd["PrName"], rd["Price"],
                            rd["PrJCode"], rd["PrSafetyStock"], rd["ScID"], rd["PrModelNumber"],
                            rd["PrColor"], rd["PrReleaseDate"], rd["PrHidden"]);
                    }
                }
            }
            finally
            {
                //データベースを切断
                conn.Close();
            }
        }
    }
    }
}
