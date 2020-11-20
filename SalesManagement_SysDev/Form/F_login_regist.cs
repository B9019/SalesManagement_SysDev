using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class F_login_regist : Form
    {
        public F_login_regist()
        {
            InitializeComponent();
        }

        private void F_login_regist_Load(object sender, EventArgs e)
        {

        }
        ///// 画面遷移処理 /////

        private void ログイン_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_login form_login = new F_login();
            form_login.ShowDialog();
            this.Close();

        }

        private void 新規ログイン情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_login_regist form_login_regist = new F_login_regist();
            form_login_regist.ShowDialog();
            this.Close();

        }

        private void ログイン履歴_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_login_log form_login_log = new F_login_log();
            form_login_log.ShowDialog();

        }



        private void 顧客情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Client_regist form_client_regist = new F_Client_regist();
            form_client_regist.ShowDialog();

        }

        private void 顧客情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Client_update form_Client_update = new F_Client_update();
            form_Client_update.ShowDialog();

        }

        private void 顧客情報検索_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Client_Search form_Client_regist = new F_Client_Search();
            form_Client_regist.ShowDialog();

        }

        private void 商品情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Product_regist form_Product_regist = new F_Product_regist();
            form_Product_regist.ShowDialog();

        }

        private void 商品情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Product_update form_Product_update = new F_Product_update();
            form_Product_update.ShowDialog();

        }

        private void 商品情報検索_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Product_search form_Product_search = new F_Product_search();
            form_Product_search.ShowDialog();

        }

        private void 受注情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Order_regist form_Order_regist = new F_Order_regist();
            form_Order_regist.ShowDialog();

        }

        private void 受注情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Order_update form_Order_update = new F_Order_update();
            form_Order_update.ShowDialog();

        }

        private void 受注情報検索_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Order_Search form_Order_search = new F_Order_Search();
            form_Order_search.ShowDialog();

        }

        private void 受注情報削除_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Order_Delete form_Order_delete = new F_Order_Delete();
            form_Order_delete.ShowDialog();

        }

        private void 注文情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Chumon_update form_Chumon_update = new F_Chumon_update();
            form_Chumon_update.ShowDialog();

        }

        private void 注文情報検索_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Chumon_search form_Chumon_search = new F_Chumon_search();
            form_Chumon_search.ShowDialog();

        }

        private void 注文情報削除_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Chumon_delete form_Chumon_delete = new F_Chumon_delete();
            form_Chumon_delete.ShowDialog();

        }

        private void 入荷情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Arrival_regist form_Arrival_regist = new F_Arrival_regist();
            form_Arrival_regist.ShowDialog();

        }

        private void 入荷情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Arrival_update form_Arrival_update = new F_Arrival_update();
            form_Arrival_update.ShowDialog();

        }

        private void 入荷情報削除_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            //F_Arrival_delete form_Arrival_delete = new F_Arrival_delete();
            //form_Arrival_delete.ShowDialog();

        }

        private void 出荷情報登録_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Shipment_regist form_Shipment_regist = new F_Shipment_regist();
            form_Shipment_regist.ShowDialog();

        }

        private void 出荷情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Shipment_update form_Shipment_update = new F_Shipment_update();
            form_Shipment_update.ShowDialog();

        }

        private void 出荷情報削除_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            //F_Shipment_delete form_Shipment_delete = new F_Shipment_delete();
            //form_Shipment_delete.ShowDialog();

        }

        private void 在庫情報更新_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Stock_update form_Stock_update = new F_Stock_update();
            form_Stock_update.ShowDialog();

        }

        private void 在庫情報検索_Click(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_Stock_search form_Stock_search = new F_Stock_search();
            form_Stock_search.ShowDialog();

        }

    }
}
