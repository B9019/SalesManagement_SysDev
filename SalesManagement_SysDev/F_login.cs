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
    public partial class F_Login : Form
    {
        public F_Login()
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
    }
}
