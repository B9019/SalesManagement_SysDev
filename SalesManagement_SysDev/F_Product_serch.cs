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
    public partial class F_Product_serch : Form
    {
        public F_Product_serch()
        {
            InitializeComponent();
        }

        private void F_Product_serch_Load(object sender, EventArgs e)
        {
            // **** ボタンのロック制御
            btn_search.Enabled = true;
            btn_regist.Enabled = false;
            btn_update.Enabled = false;
            btn_all.Enabled = true;
            btn_print.Enabled = true;
            btn_delete.Enabled = false;
            btn_clear.Enabled = true;

            // ****ロックされたボタンの表示変更
            btn_regist.BackColor = Color.DarkGray;
            btn_update.BackColor = Color.DarkGray;
            btn_delete.BackColor = Color.DarkGray;

        }
    }
}
