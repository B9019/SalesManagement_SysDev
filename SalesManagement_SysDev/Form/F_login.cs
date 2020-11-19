using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Model;
using SalesManagement_SysDev.Model.Entity;


namespace SalesManagement_SysDev
{
    public partial class F_login : Form
    {

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
            context.M_Positions.Add(FirstPosition);
            context.SaveChanges();
            context.Dispose();

            MessageBox.Show("テーブル作成完了");
        }

        private void F_login_Load(object sender, EventArgs e)
        {
            ログイン.Enabled = false;
        }
        private void 管理者用メニューtoolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void ログイン_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_login form_login = new F_login();
            form_login.ShowDialog();
            this.Close();
        }

        private void 新規ログイン情報登録_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_login_regist form_login_regist = new F_login_regist();
            form_login_regist.ShowDialog();
            this.Close();

        }

        private void ログイン履歴_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_login_log form_login_log = new F_login_log();
            form_login_log.ShowDialog();
            this.Close();

        }

        private void 顧客情報登録_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Client_regist form_client_regist = new F_Client_regist();
            form_client_regist.ShowDialog();
            this.Close();

        }

        private void 顧客情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Client_update form_Client_update = new F_Client_update();
            form_Client_update.ShowDialog();
            this.Close();

        }

        private void 顧客情報検索_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Client_search form_Client_regist = new F_Client_search();
            form_Client_regist.ShowDialog();
            this.Close();

        }
    }
}
