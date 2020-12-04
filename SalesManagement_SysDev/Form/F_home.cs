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

namespace SalesManagement_SysDev
{
    public partial class F_home : Form
    {
        //// ***** モジュール実装（よく使う他クラスで定義したメソッドが利用できるようあらかじめ実装します。）

        //// 共通データベース処理モジュール
        //private CommonFunction _cm = new CommonFunction();

        ////// データベース処理モジュール（項目処理）
        ////private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        ////// データベース処理モジュール（コードカウンター）
        ////private CodeCounterCommon _cc = new CodeCounterCommon();

        //// 入力チェックモジュール
        //private InputCheck _ic = new InputCheck();

        ////// メッセージ処理モジュール
        //private Messages _ms = new Messages();

        ////// データベース処理モジュール（M_Login）
        //private M_LoginContents _Lo = new M_LoginContents();

        ////// スタッフ変数 ////
        //private StaffContents _st = new StaffContents();


        // ***** プロパティ定義


        //public SalesDataSet _sds= new SalesDataSet();

        ////フォーム名の定義//
        //F_Client f_client = new F_Client();
        //F_Employee f_employee = new F_Employee();
        //F_Arrival f_arrival = new F_Arrival();
        //F_Chumon f_chumon = new F_Chumon();
        //F_Hattyu f_hattyu = new F_Hattyu();
        //F_Order f_order = new F_Order();
        //F_Product f_product = new F_Product();
        //F_Sale f_sale = new F_Sale();
        //F_Shipment f_shipment = new F_Shipment();
        //F_Stock f_stock = new F_Stock();
        //F_Syukko f_syukko = new F_Syukko();
        //F_Warehousing f_warehousing = new F_Warehousing();


        ////// 選択行番号
        //private int _lineNo;

        int transfer_int ;

        //エントリポイント
        [STAThread]
        static void Main()
        {
            Application.Run(new F_home());
        }

        public F_home()
        {
            InitializeComponent();
        }

        private void F_home_Load(object sender, EventArgs e)
        {
            F_home f_home = new F_home();
            F_login f_login = new F_login();
            f_home.Visible = false;
            f_login.ShowDialog();



        }
        ///// 画面遷移処理 /////

        private void ログイン管理toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_login form_login = new F_login();
            form_login.transfer_int = transfer_int;
            form_login.ShowDialog();

        }

        private void 顧客管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Client form_client = new F_Client();
            form_client.transfer_int = transfer_int;
            form_client.ShowDialog();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Product form_product = new F_Product();
            form_product.transfer_int = transfer_int;
            form_product.ShowDialog();

        }

        private void 受注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Order form_order = new F_Order();
            form_order.transfer_int = transfer_int;
            form_order.ShowDialog();

        }

        private void 注文管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Chumon form_chumon = new F_Chumon();
            form_chumon.transfer_int = transfer_int;
            form_chumon.ShowDialog();

        }

        private void 入荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Arrival form_arrival = new F_Arrival();
            form_arrival.transfer_int = transfer_int;
            form_arrival.ShowDialog();

        }

        private void 出荷管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Shipment form_shipment = new F_Shipment();
            form_shipment.transfer_int = transfer_int;
            form_shipment.ShowDialog();

        }

        private void 在庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Stock form_stock = new F_Stock();
            form_stock.transfer_int = transfer_int;
            form_stock.ShowDialog();

        }

        private void 入庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Warehousing form_warehousing = new F_Warehousing();
            form_warehousing.transfer_int = transfer_int;
            form_warehousing.ShowDialog();
        }

        private void 出庫管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Syukko form_syukko = new F_Syukko();
            form_syukko.transfer_int = transfer_int;
            form_syukko.ShowDialog();

        }

        private void 社員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Employee form_employee = new F_Employee();
            form_employee.transfer_int = transfer_int;
            form_employee.ShowDialog();

        }

        private void 売上管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Sale form_sale = new F_Sale();
            form_sale.transfer_int = transfer_int;
            form_sale.ShowDialog();

        }

        private void 発注管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Hattyu form_hattyu = new F_Hattyu();
            form_hattyu.transfer_int = transfer_int;
            form_hattyu.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_sertch_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }

    }

