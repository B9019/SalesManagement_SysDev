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
    public partial class F_Client_Search : Form
    {
        public F_Client_Search()
        {
            InitializeComponent();
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

        // 登録ボタン
        // 4.1顧客情報検索
        private void btn_sertch_Click(object sender, EventArgs e)
        {
           
                // 4.1.1妥当な顧客情報取得
                if (!Get_Product_Data_AtSearch())
                    return;

            // 4.1.2妥当な顧客情報作成
            var regProduct = Generate_Data_AtSearch();

                // 4.1.3顧客情報登録
                if (!Generate_Search(regProduct))
                    return;


            }

            // 
            //
            //4.1.1　妥当な商品データ取得（新規登録）
            //
            //
            private bool Get_Product_Data_AtSearch()
            {
                // 商品データの形式チェック
                string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            // 顧客ID
            if (String.IsNullOrEmpty(txt_ClID.Text))
                {
                    MessageBox.Show("顧客IDは必須項目です");
                    txt_ClID.Focus();
                    return false;
                }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
                {
                    MessageBox.Show("営業所IDは必須項目です");
                    txt_SoID.Focus();
                    return false;
                }
            // 顧客名
            if (String.IsNullOrEmpty(txt_ClName.Text))
                {
                    MessageBox.Show("顧客名は必須項目です");
                    txt_ClName.Focus();
                    return false;
                }


                 ///// 入力内容の形式チェック /////

                //// 数値チェック ////

                // 顧客ID
                if (!_ic.NumericCheck(txt_ClID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_ClID.Focus();
                    return false;
                }
                //　営業所ID
                if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_SoID.Focus();
                    return false;
                }
                

                ////　文字チェック ////

                //　顧客名
                if (!_ic.FullWidthCharCheck(txt_ClName.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    txt_ClName.Focus();
                    return false;
                }


            /////文字数チェック/////
            // 顧客ID
            if (txt_ClID.TextLength > 4)
                {
                    MessageBox.Show("顧客IDは4文字以下です");
                    txt_ClID.Focus();
                    return false;
                }
                // 営業所ID
                if (txt_SoID.TextLength > 2)
                {
                    MessageBox.Show("営業所IDは2文字以下です");
                    txt_SoID.Focus();
                    return false;
                }
                // 顧客名
                if (txt_ClName.TextLength > 50)
                {
                    MessageBox.Show("顧客名は50文字以下です");
                    txt_ClName.Focus();
                    return false;
                }
                
                return true;
            }
            //
            //
            // 4.1.2 商品情報作成
            //
            //
            private M_Product Generate_Data_AtSearch()
            {
                return new M_Client
                {
                    ClID = int.Parse(txt_ClID.Text),
                    SoID = int.Parse(txt_SoID.Text),
                    ClName = txt_ClName.Text,
                    ClAddress = txt_ClAddress.Text,
                    ClPhone = txt_PrJCode.Text,
                    ClPostal = int.Parse(txt_PrSafetyStock.Text),
                    ClFAX = int.Parse(txt_ScID.Text),
                    ClFlag = int.Parse(txt_PrModelNumber.Text),
                    ClHidden = txt_PrColor.Text

                };

            }
            //
            //
            // 4.1.3　商品情報登録
            //
            //
            private bool Generate_Search(M_Product regProduct)
            {
                // 登録可否
                if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return false;
                }
                // 商品情報の登録
                var errorMessage = _Pr.PostM_Division(regProduct);

                if (errorMessage != string.Empty)
                {
                    MessageBox.Show(errorMessage);
                    return false;
                }
                // 画面更新
                RefreshDataGridView();
                txt_MaID.Focus();

                return true;

            }
        }
    }
}
