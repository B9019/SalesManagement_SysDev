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
    public partial class F_Employee : Form
    {
        // ***** モジュール実装（よく使う他クラスで定義したメソッドが利用できるようあらかじめ実装します。）

        // 共通データベース処理モジュール
        private CommonFunction _cm = new CommonFunction();

        //// データベース処理モジュール（項目処理）
        //private ColumnsManagementCommon _cmc = new ColumnsManagementCommon();

        //// データベース処理モジュール（コードカウンター）
        //private CodeCounterCommon _cc = new CodeCounterCommon();

        // 入力チェックモジュール
        private InputCheck _ic = new InputCheck();

        //// メッセージ処理モジュール
        private Messages _ms = new Messages();

        //// データベース処理モジュール（M_Employee）
        private M_EmployeeContents _Em = new M_EmployeeContents();

        // ***** プロパティ定義

        //// トップフォーム
        public F_home f_home;

        //// 選択行番号
        private int _lineNo;

        // バージョン管理
        // データベースからデータを読み込んだ時の時間を管理します。
        // 後にデータベースに書き込む時、異なるバージョンのデータ（読み込んだデータが既に他者によって書き換えられている）
        // だった場合、書き込みは失敗します。（楽観的同時実行制御）
        private byte[] _timeStamp;

        // ページング関係プロパティ
        private int _pageCountPaging;                                       // 全表示ページ数
        private int _recordCount;                                           // 全表示データ数
        private int _pageSizePaging;                                        // １ページ表示データ行数
        private int _currentPage;                                           // 現在のページ
        private int _recordNo;                                              // ページ先頭位置のデータ（スタートデータ）
        private IEnumerable<M_DispEmployee> _dispEmployeePaging;            // 表示用データ

        // 印刷
        private int _pageCountPrinting;                                     // 全印刷ページ数
        private int _pageNumber = 0;                                        // 印刷ページ番号
        private int _pageSizePrinting;                                      // １ページ印刷データ行数
        private List<M_DispEmployee> _dispEmployeePrinting;                 // 印刷用データ


        public F_Employee()
        {
            InitializeComponent();
        }

        private void F_Employee_Load(object sender, EventArgs e)
        {
            商品管理ToolStripMenuItem.Enabled = false;
            dataGridView_Employee.ColumnCount = 9;

            dataGridView_Employee.Columns[0].HeaderText = "社員ID";
            dataGridView_Employee.Columns[1].HeaderText = "社員名";
            dataGridView_Employee.Columns[2].HeaderText = "営業所ID";
            dataGridView_Employee.Columns[3].HeaderText = "役職ID";
            dataGridView_Employee.Columns[4].HeaderText = "入社年月日";
            dataGridView_Employee.Columns[5].HeaderText = "パスワード ";
            dataGridView_Employee.Columns[6].HeaderText = "電話番号";
            dataGridView_Employee.Columns[7].HeaderText = "社員管理フラグ";
            dataGridView_Employee.Columns[8].HeaderText = "非表示理由";

        }
        // 登録ボタン
        // 6.1社員情報登録
        private void btn_regist_Click(object sender, EventArgs e)
        {
            // 6.1.1妥当な社員情報取得
            if (!Get_Employee_Data_AtRegistration())
                return;

            // 6.1.2妥当な社員情報作成
            var regEmployee = Generate_Data_AtRegistration();

            // 6.1.3社員情報登録
            if (!Generate_Registration(regEmployee))
                return;
        }

        // 
        //
        //6.1.1　妥当な社員データ取得（新規登録）
        //
        //
        private bool Get_Employee_Data_AtRegistration()
        {
            // 商品データの形式チェック
            string errorMessage = string.Empty;

            ///// 入力内容の適否 /////

            //　社員ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("社員IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            // 社員名
            if (String.IsNullOrEmpty(txt_EmName.Text))
            {
                MessageBox.Show("社員名は必須項目です");
                txt_EmName.Focus();
                return false;
            }
            // 営業所ID
            if (String.IsNullOrEmpty(txt_SoID.Text))
            {
                MessageBox.Show("営業所IDは必須項目です");
                txt_SoID.Focus();
                return false;
            }
            ////　JANコード
            //if (String.IsNullOrEmpty(txt_PrJCode.Text))
            //{
            //    MessageBox.Show("JANコードは必須項目です");         //画面デザインでJANコードが必須項目になっているが、JANコードはNULL可なので必要ない。画面の訂正必要。
            //    txt_PrJCode.Focus();
            //    return false;
            //}
            // 入社年月日
            if (String.IsNullOrEmpty(txt_EmHiredate.Text))
            {
                MessageBox.Show("入社年月日は必須項目です");
                txt_EmHiredate.Focus();
                return false;
            }
            //　非表示理由
            if (String.IsNullOrEmpty(txt_EmHidden.Text))
            {
                MessageBox.Show("非表示理由は必須項目です");
                txt_EmHidden.Focus();
                return false;
            }
            ///// 入力内容の形式チェック /////

            //// 数値チェック ////

            // 社員ID
            if (!_ic.NumericCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            //　社員ID
            if (!_ic.NumericCheck(txt_SoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_SoID.Focus();
                return false;
            }
            // 役職ID
            if (!_ic.NumericCheck(txt_PoID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_PoID.Focus();
                return false;
            }
            ////　文字チェック ////

            //　社員名
            if (!_ic.FullWidthCharCheck(txt_EmID.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmID.Focus();
                return false;
            }
            // 　入社年月日の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmHiredate.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmHiredate.Focus();
                return false;
            }
            // 　電話番号の文字チェック
            if (!_ic.FullWidthCharCheck(txt_EmPhone.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage);
                txt_EmPhone.Focus();
                return false;
            }

            /////文字数チェック/////
            // 社員ID
            if (txt_EmID.TextLength > 6)
            {
                MessageBox.Show("社員IDは6文字以下です");
                txt_EmID.Focus();
                return false;
            }
            // 社員名
            if (txt_EmName.TextLength > 50)
            {
                MessageBox.Show("社員名は50文字以下です");
                txt_EmName.Focus();
                return false;
            }
            //　営業所ID
            if (txt_SoID.TextLength > 2)
            {
                MessageBox.Show("営業所IDは2文字以下です");
                txt_SoID.Focus();
                return false;
            }
            //　役職ID
            if (txt_PoID.TextLength > 2)
            {
                MessageBox.Show("役職IDは2文字以下です");
                txt_PoID.Focus();
                return false;
            }
            // 電話番号
            if (txt_EmPhone.TextLength > 13)
            {
                MessageBox.Show("電話番号は13文字以下です");
                txt_EmPhone.Focus();
                return false;
            }
            //　非表示理由
            if (txt_EmHidden.TextLength > 30)
            {
                MessageBox.Show("非表示理由は30文字以下です");
                txt_EmHidden.Focus();
                return false;
            }
            return true;
        }
        //
        //
        // 6.1.2 社員情報作成
        //
        //
        private M_Employee Generate_Data_AtRegistration()
        {
            return new M_Employee
            {
                EmID = int.Parse(txt_EmID.Text),
                EmName = txt_EmName.Text,
                SoID = int.Parse(txt_SoID.Text),
                PoID = int.Parse(txt_PoID.Text),
                EmHiredate = DateTime.Parse(txt_EmHiredate.Text),
                //EmPassword = txt_EmPassword.Text,
                EmPhone = txt_EmPhone.Text,
                EmHidden = txt_EmHidden.Text,

            };

        }
        //
        //
        // 4.1.3　商品情報登録
        //
        //
        private bool Generate_Registration(M_Product regProduct)
        {
            // 登録可否
            if (DialogResult.OK != MessageBox.Show(this, "登録してよろしいですか", "登録可否", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            // 商品情報の登録
            var errorMessage = _Pr.PostM_Product(regProduct);

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
