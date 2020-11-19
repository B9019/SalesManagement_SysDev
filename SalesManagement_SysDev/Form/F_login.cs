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

        ///// 画面遷移処理 /////

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

        private void 商品情報登録ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Product_regist form_Product_regist = new F_Product_regist();
            form_Product_regist.ShowDialog();
            this.Close();

        }

        private void 商品情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Product_update form_Product_update = new F_Product_update();
            form_Product_update.ShowDialog();
            this.Close();

        }

        private void 商品情報検索_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Product_search form_Product_search = new F_Product_search();
            form_Product_search.ShowDialog();
            this.Close();

        }

        private void 受注情報登録_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Order_regist form_Order_regist = new F_Order_regist();
            form_Order_regist.ShowDialog();
            this.Close();

        }

        private void 受注情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Order_update form_Order_update = new F_Order_update();
            form_Order_update.ShowDialog();
            this.Close();

        }

        private void 受注情報検索_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Order_search form_Order_search = new F_Order_search();
            form_Order_search.ShowDialog();
            this.Close();

        }

        private void 受注情報削除_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Order_delete form_Order_delete = new F_Order_delete();
            form_Order_delete.ShowDialog();
            this.Close();

        }

        private void 注文情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Chumon_update form_Chumon_update = new F_Chumon_update();
            form_Chumon_update.ShowDialog();
            this.Close();

        }

        private void 注文情報検索_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Chumon_search form_Chumon_search = new F_Chumon_search();
            form_Chumon_search.ShowDialog();
            this.Close();

        }

        private void 注文情報削除_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Chumon_delete form_Chumon_delete = new F_Chumon_delete();
            form_Chumon_delete.ShowDialog();
            this.Close();

        }

        private void 入荷情報登録_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Arrival_regist form_Arrival_regist = new F_Arrival_regist();
            form_Arrival_regist.ShowDialog();
            this.Close();

        }

        private void 入荷情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Arrival_update form_Arrival_update = new F_Arrival_update();
            form_Arrival_update.ShowDialog();
            this.Close();

        }

        private void 入荷情報削除_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Arrival_delete form_Arrival_delete = new F_Arrival_delete();
            form_Arrival_delete.ShowDialog();
            this.Close();

        }

        private void 出荷情報登録_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Shipment_regist form_Shipment_regist = new F_Shipment_regist();
            form_Shipment_regist.ShowDialog();
            this.Close();

        }

        private void 出荷情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Shipment_update form_Shipment_update = new F_Shipment_update();
            form_Shipment_update.ShowDialog();
            this.Close();

        }

        private void 出荷情報削除_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Shipment_delete form_Shipment_delete = new F_Shipment_delete();
            form_Shipment_delete.ShowDialog();
            this.Close();

        }

        private void 在庫情報更新_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Stock_update form_Stock_update = new F_Stock_update();
            form_Stock_update.ShowDialog();
            this.Close();

        }

        private void 在庫情報検索_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            F_Stock_search form_Stock_search = new F_Stock_search();
            form_Stock_search.ShowDialog();
            this.Close();

        }
    }
}
