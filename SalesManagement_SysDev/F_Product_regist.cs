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
            // **** ボタンのロック制御
            btn_search.Enabled = false;
            btn_regist.Enabled = true;
            btn_update.Enabled = false;
            btn_all.Enabled = true;
            btn_print.Enabled = true;
            btn_delete.Enabled = false;
            btn_clear.Enabled = true;

            // ****ロックされたボタンの表示変更
            btn_search.BackColor = Color.DarkGray;
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

        // 
        //
        //4.1.1　妥当な商品データ取得（新規登録）
        //
        //
        private bool Get_Product_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            // メーカIDの適否
            if (!String.IsNullOrEmpty(txt_MaID.Text))
            {
                MessageBox.Show("メーカIDは入力できません");
                MaID.Focus();
                return false;
            }

            // 商品IDの適否
            if (String.IsNullOrEmpty(txt_PrID.Text))
            {
                MessageBox.Show("商品IDは必須項目です");
                txt_PrID.Focus();
                return false;
            }

            // 商品名の適否
            if (String.IsNullOrEmpty(txt_PrID.Text))
            {
                MessageBox.Show("商品IDは必須項目です");
                txt_PrID.Focus();
                return false;
            }
            //　JANコードの適否
            if (String.IsNullOrEmpty(txt_PrJCode.Text))
            {
                MessageBox.Show("JANコードは必須項目です");
                txt_PrJCode.Focus();
                return false;
            }
            // 小分類IDの適否
            if (String.IsNullOrEmpty(txt_ScID.Text))
            {
                MessageBox.Show("小分類IDは必須項目です");
                txt_ScID.Focus();
                return false;
            }
            // 型番の適否
            if (String.IsNullOrEmpty(txt_PrModelNumber.Text))
            {
                MessageBox.Show("型番は必須項目です");
                txt_PrModelNumber.Focus();
                return false;
            }
            //　色の適否
            if (String.IsNullOrEmpty(txt_PrColor.Text))
            {
                MessageBox.Show("色は必須項目です");
                txt_PrColor.Focus();
                return false;
            }
            // 発売日の適否
            if (String.IsNullOrEmpty(txt_PrReleaseDate.Text))
            {
                MessageBox.Show("発売日は必須項目です");
                txt_PrReleaseDate.Focus();
                return false;
            }
            //　価格の適否
            if (String.IsNullOrEmpty(txt_Price.Text))
            {
                MessageBox.Show("価格は必須項目です");
                txt_Price.Focus();
                return false;
            }
            //　安全在庫数の適否
            if (String.IsNullOrEmpty(txt_PrSafetyStock.Text))
            {
                MessageBox.Show("安全在庫数は必須項目です");
                txt_PrSafetyStock.Focus();
                return false;
            }

            if (!_ic.FullWidthCharCheck(textBoxDivisionName.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                textBoxDivisionName.Focus();
                return false;
            }

            if (textBoxDivisionName.TextLength > 50)
            {
                MessageBox.Show("部署名は50文字以下です");
                textBoxDivisionName.Focus();
                return false;
            }

            // 削除フラグの適否
            if (checkBoxDelFLG.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("不確定になっています");
                checkBoxDelFLG.Focus();
                return false;
            }

            // 備考の適否
            if (textBoxComments.TextLength > 80)
            {
                MessageBox.Show("備考は80文字以下です");
                textBoxComments.Focus();
                return false;
            }

            return true;

        }



        private void btn_regist_Click(object sender, EventArgs e)
        {
            if (!Get_Product_Data_AtRegistration())
            {
                return;
            }

        }
    }
}
