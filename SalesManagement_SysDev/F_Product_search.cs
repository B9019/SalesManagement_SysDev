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
    public partial class F_Product_search : Form
    {
        public F_Product_search()
        {
            InitializeComponent();
        }
        private void F_Product_search_Load(object sender, EventArgs e)
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
        private void F_Product_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:   // 検索
                    if (btn_search.Enabled == true)
                        btn_search.PerformClick();
                    break;
                case Keys.F2:   //登録
                    if (btn_regist.Enabled == true)
                        btn_regist.PerformClick();
                    break;
                case Keys.F3:   //更新
                    if (btn_update.Enabled == true)
                        btn_update.PerformClick();
                    break;
                case Keys.F4:   //一覧表示
                    if (btn_all.Enabled == true)
                        btn_all.PerformClick();
                    break;
                case Keys.F5:   //印刷
                    if (btn_print.Enabled == true)
                        btn_print.PerformClick();
                    break;
                case Keys.F6:   //削除
                    if (btn_delete.Enabled == true)
                        btn_delete.PerformClick();
                    break;
                case Keys.F7:   //入力クリア
                    if (btn_clear.Enabled == true)
                        btn_clear.PerformClick();
                    break;
            }
        }

    }
}
