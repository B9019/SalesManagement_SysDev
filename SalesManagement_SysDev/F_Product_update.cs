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
    public partial class F_Product_update : Form
    {
        public F_Product_update()
        {
            InitializeComponent();
        }

        private void F_Product_update_Load(object sender, EventArgs e)
        {
            // **** ボタンのロック制御
            btn_search.Enabled = false;
            btn_regist.Enabled = false;
            btn_update.Enabled = true;
            btn_all.Enabled = true;
            btn_print.Enabled = true;
            btn_delete.Enabled = true;
            btn_clear.Enabled = true;

            // ****ロックされたボタンの表示変更
            btn_search.BackColor = Color.DarkGray;
            btn_regist.BackColor = Color.DarkGray;



        }
    }
}
