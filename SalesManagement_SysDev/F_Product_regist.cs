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
    public partial class F_Product_regist : Form
    {
        public F_Product_regist()
        {
            InitializeComponent();
        }

        private void F_Product_regist_Load(object sender, EventArgs e)
        {

        }
        
        private void F_Product_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:   // 検索
                    if (btnSearch.Enabled == true)
                        btnSearch.PerformClick();
                    break;
                case Keys.F2:
                    btnSearch.PerformClick();
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;
            }
        }
    }
}
