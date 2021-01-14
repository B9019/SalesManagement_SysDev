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
    public partial class F_login : MetroForm

    {
        public int transfer_int ;

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

        //// データベース処理モジュール（M_Login）
        private M_LoginContents _Lo = new M_LoginContents();

        //// スタッフ変数 ////
        private StaffContents _st = new StaffContents();

        // ***** プロパティ定義

        //// トップフォーム
        public F_home f_home;


        //// 選択行番号
        private int _lineNo;

        public F_login()
        {
            InitializeComponent();
        }

        private void btn_CleateDabase_Click(object sender, EventArgs e)
        {
            //データベースの生成を行います．
            //再度実行する場合には，必ずデータベースの削除をしてから実行してください．

            //役職マスタを生成するサンプル（1件目に管理者を追加する例）
            M_Position FirstPosition = new M_Position()
            {
                PoName = "管理者"
            };
            SalesManagement_DevContext context = new SalesManagement_DevContext();
            
            context.SaveChanges();
            context.Dispose();

            MessageBox.Show("テーブル作成完了");
        }

        private void F_login_Load(object sender, EventArgs e)
        {
            transfer_int = 0;
        }

        // ログオン処理
        private void btn_login_Click(object sender, EventArgs e)
        {
            // ユーザーID入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(txt_EmID.Text, out string errorMessage_UserId))
            {
                txt_EmID.Focus();
                return;
            }
            // パスワード入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(txt_EmPassword.Text, out string errorMessage_Password))
            {
                txt_EmPassword.Focus();
                return;
            }

            //transfer_int = int.Parse(txt_EmID.Text);
            //using (SalesManagement_DevContext dbContext = new SalesManagement_DevContext())
            //{
            //    var loresult = dbContext.M_Employees
            //        .Where(e => e.EmID == transfer_int )
            //        .ToArray();
            //    foreach (var item in loresult)
            //    {
            //        txt_loginSoID.Text = (item.SoID).ToString();
            //        txt_loginEmID.Text = (item.EmID).ToString();
            //    }
            //}
            //return ;
            //接続先DBの情報をセット
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesManagement_SysDev.SalesManagement_DevContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //実行するSQL文の指定
            command.CommandText = @"SELECT * FROM M_Employee WHERE EmID = @EmID AND EmPassword = @EmPassword;";
            command.Connection = conn;
            //検索条件をテキストボックスから抽出し、SQL文をセット
            //　日本語可　：SqlDbType.NVarChar
            //　日本語不可：SqlDbType.VarChar
            // パスワードチェック
            if ((txt_EmID.Text != "") && (txt_EmPassword.Text != ""))
            {
                command.Parameters.Add("@EmID", SqlDbType.VarChar);
                command.Parameters["@EmID"].Value = txt_EmID.Text;
                command.Parameters.Add("@EmPassword", SqlDbType.VarChar);
                command.Parameters["@EmPassword"].Value = txt_EmPassword.Text;
                try
                {
                    //データベースに接続
                    conn.Open();
                    //SQL文の実行、データが  readerに格納される
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            transfer_int = Convert.ToInt32(rd["PoID"]);//役職IDを共有変数に格納
                        }
                    }
                }
                finally
                {
                    //データベースを切断
                    conn.Close();
                }
                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = "Administrator",
                    Table = string.Empty,
                    Command = "Logon",
                    Data = string.Empty,
                };
                //StaticCommon.PostOperationLog(operationLog);

                Dispose();
                return;
            }
        }
        // 閉じるボタン
        private void ButtonCansel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // 登録ボタン
        // 1.1ログイン情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 1.1.1妥当なログイン情報取得
            if (!Get_Login_Data_AtRegistration())
                return;

            // 1.1.2妥当なログイン情報作成
            var regLogin = Generate_Data_AtRegistration();

            // 1.1.3ログイン情報登録
            if (!LoginUpdate(regLogin))
                return;

        }
        // 
        //
        //1.1.1　妥当なログインデータ取得（新規登録）
        //
        //
        private bool Get_Login_Data_AtRegistration()
        {
            // ログインデータの形式チェック
            string errorMessage = string.Empty;

            // ユーザーID入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(txt_EmID.Text, out string errorMessage_UserId))
            {
                //labelMessage.Text = errorMessage_UserId;
                txt_EmID.Focus();
                return false;
            }

            // パスワード入力チェック
            if (!_ic.HalfCharSpecialSymbolCheck(txt_EmPassword.Text, out string errorMessage_Password))
            {
                //labelMessage.Text = errorMessage_Password;
                txt_EmPassword.Focus();
                return false;
            }

            return true;

        }
        //
        //
        // 1.1.2 ログイン情報作成
        //
        //
        private M_Employee Generate_Data_AtRegistration()
        {
            return new M_Employee
            {
                EmID = int.Parse(txt_EmID.Text),
                EmPassword = txt_EmPassword.Text,

            };

        }
        //
        //
        // 1.2.3 ログイン情報登録
        //
        //
        private bool LoginUpdate(M_Employee regEmployee)
        {
            // 更新可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            var errorMessage = _Lo.PutLogin(regEmployee);

            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            txt_EmID.Focus();

            return true;
        }


    }
}
