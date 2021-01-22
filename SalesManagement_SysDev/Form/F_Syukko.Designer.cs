namespace SalesManagement_SysDev
{
    partial class F_Syukko
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_SyHidden = new System.Windows.Forms.TextBox();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.lbl_ArHidden = new System.Windows.Forms.Label();
            this.chk_hide_FLG = new System.Windows.Forms.CheckBox();
            this.lbl_memo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_chumon = new System.Windows.Forms.CheckBox();
            this.lbl_SyID = new System.Windows.Forms.Label();
            this.txt_SyID = new System.Windows.Forms.TextBox();
            this.lbl_EnID = new System.Windows.Forms.Label();
            this.txt_EmID = new System.Windows.Forms.TextBox();
            this.lbl_ClID = new System.Windows.Forms.Label();
            this.txt_ClID = new System.Windows.Forms.TextBox();
            this.lbl_SoID = new System.Windows.Forms.Label();
            this.txt_SoID = new System.Windows.Forms.TextBox();
            this.lbl_OrID = new System.Windows.Forms.Label();
            this.txt_OrID = new System.Windows.Forms.TextBox();
            this.lbl_SyDate = new System.Windows.Forms.Label();
            this.txt_SyDate = new System.Windows.Forms.TextBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_chumondetail = new System.Windows.Forms.CheckBox();
            this.lbl_SyID2 = new System.Windows.Forms.Label();
            this.txt_SyQuantity = new System.Windows.Forms.TextBox();
            this.txt_SyID2 = new System.Windows.Forms.TextBox();
            this.lbl_SyDetailID = new System.Windows.Forms.Label();
            this.lbl_ArQuantity = new System.Windows.Forms.Label();
            this.txt_SyDetailID = new System.Windows.Forms.TextBox();
            this.lbl_PrID = new System.Windows.Forms.Label();
            this.txt_PrID = new System.Windows.Forms.TextBox();
            this.dataGridView_Syukko_Detail = new System.Windows.Forms.DataGridView();
            this.btn_commit_FLG = new System.Windows.Forms.Button();
            this.txt_loginSoID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_regist = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_loginEmID = new System.Windows.Forms.TextBox();
            this.dataGridView_Syukko = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Syukko_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Syukko)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_SyHidden
            // 
            this.txt_SyHidden.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SyHidden.Location = new System.Drawing.Point(170, 317);
            this.txt_SyHidden.Multiline = true;
            this.txt_SyHidden.Name = "txt_SyHidden";
            this.txt_SyHidden.Size = new System.Drawing.Size(772, 58);
            this.txt_SyHidden.TabIndex = 10;
            this.txt_SyHidden.Text = "非表示理由を入力(50文字)";
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(170, 277);
            this.txt_memo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(772, 26);
            this.txt_memo.TabIndex = 9;
            // 
            // lbl_ArHidden
            // 
            this.lbl_ArHidden.AutoSize = true;
            this.lbl_ArHidden.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_ArHidden.Location = new System.Drawing.Point(7, 320);
            this.lbl_ArHidden.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ArHidden.Name = "lbl_ArHidden";
            this.lbl_ArHidden.Size = new System.Drawing.Size(118, 19);
            this.lbl_ArHidden.TabIndex = 241;
            this.lbl_ArHidden.Text = "非表示モード";
            // 
            // chk_hide_FLG
            // 
            this.chk_hide_FLG.AutoSize = true;
            this.chk_hide_FLG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk_hide_FLG.Location = new System.Drawing.Point(136, 323);
            this.chk_hide_FLG.Name = "chk_hide_FLG";
            this.chk_hide_FLG.Size = new System.Drawing.Size(15, 14);
            this.chk_hide_FLG.TabIndex = 240;
            this.chk_hide_FLG.UseVisualStyleBackColor = true;
            this.chk_hide_FLG.CheckedChanged += new System.EventHandler(this.Checked_Syukko_HideFlag);
            // 
            // lbl_memo
            // 
            this.lbl_memo.AutoSize = true;
            this.lbl_memo.Location = new System.Drawing.Point(7, 280);
            this.lbl_memo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_memo.Name = "lbl_memo";
            this.lbl_memo.Size = new System.Drawing.Size(47, 19);
            this.lbl_memo.TabIndex = 194;
            this.lbl_memo.Text = "備考";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.chk_chumon);
            this.groupBox3.Controls.Add(this.txt_SyHidden);
            this.groupBox3.Controls.Add(this.txt_memo);
            this.groupBox3.Controls.Add(this.lbl_ArHidden);
            this.groupBox3.Controls.Add(this.lbl_memo);
            this.groupBox3.Controls.Add(this.chk_hide_FLG);
            this.groupBox3.Controls.Add(this.lbl_SyID);
            this.groupBox3.Controls.Add(this.txt_SyID);
            this.groupBox3.Controls.Add(this.lbl_EnID);
            this.groupBox3.Controls.Add(this.txt_EmID);
            this.groupBox3.Controls.Add(this.lbl_ClID);
            this.groupBox3.Controls.Add(this.txt_ClID);
            this.groupBox3.Controls.Add(this.lbl_SoID);
            this.groupBox3.Controls.Add(this.txt_SoID);
            this.groupBox3.Controls.Add(this.lbl_OrID);
            this.groupBox3.Controls.Add(this.txt_OrID);
            this.groupBox3.Controls.Add(this.lbl_SyDate);
            this.groupBox3.Controls.Add(this.txt_SyDate);
            this.groupBox3.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(950, 382);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出庫項目";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // chk_chumon
            // 
            this.chk_chumon.AutoSize = true;
            this.chk_chumon.Location = new System.Drawing.Point(98, 0);
            this.chk_chumon.Name = "chk_chumon";
            this.chk_chumon.Size = new System.Drawing.Size(15, 14);
            this.chk_chumon.TabIndex = 283;
            this.chk_chumon.UseVisualStyleBackColor = true;
            // 
            // lbl_SyID
            // 
            this.lbl_SyID.AutoSize = true;
            this.lbl_SyID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SyID.Location = new System.Drawing.Point(7, 40);
            this.lbl_SyID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SyID.Name = "lbl_SyID";
            this.lbl_SyID.Size = new System.Drawing.Size(71, 19);
            this.lbl_SyID.TabIndex = 77;
            this.lbl_SyID.Text = "出庫ID";
            // 
            // txt_SyID
            // 
            this.txt_SyID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SyID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SyID.Location = new System.Drawing.Point(170, 37);
            this.txt_SyID.Name = "txt_SyID";
            this.txt_SyID.Size = new System.Drawing.Size(773, 26);
            this.txt_SyID.TabIndex = 0;
            // 
            // lbl_EnID
            // 
            this.lbl_EnID.AutoSize = true;
            this.lbl_EnID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EnID.Location = new System.Drawing.Point(7, 80);
            this.lbl_EnID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EnID.Name = "lbl_EnID";
            this.lbl_EnID.Size = new System.Drawing.Size(71, 19);
            this.lbl_EnID.TabIndex = 76;
            this.lbl_EnID.Text = "社員ID";
            // 
            // txt_EmID
            // 
            this.txt_EmID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_EmID.Location = new System.Drawing.Point(170, 77);
            this.txt_EmID.Name = "txt_EmID";
            this.txt_EmID.Size = new System.Drawing.Size(772, 26);
            this.txt_EmID.TabIndex = 1;
            // 
            // lbl_ClID
            // 
            this.lbl_ClID.AutoSize = true;
            this.lbl_ClID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_ClID.Location = new System.Drawing.Point(7, 120);
            this.lbl_ClID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClID.Name = "lbl_ClID";
            this.lbl_ClID.Size = new System.Drawing.Size(71, 19);
            this.lbl_ClID.TabIndex = 82;
            this.lbl_ClID.Text = "顧客ID";
            // 
            // txt_ClID
            // 
            this.txt_ClID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ClID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_ClID.Location = new System.Drawing.Point(170, 117);
            this.txt_ClID.Name = "txt_ClID";
            this.txt_ClID.Size = new System.Drawing.Size(772, 26);
            this.txt_ClID.TabIndex = 2;
            // 
            // lbl_SoID
            // 
            this.lbl_SoID.AutoSize = true;
            this.lbl_SoID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SoID.Location = new System.Drawing.Point(7, 160);
            this.lbl_SoID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SoID.Name = "lbl_SoID";
            this.lbl_SoID.Size = new System.Drawing.Size(90, 19);
            this.lbl_SoID.TabIndex = 83;
            this.lbl_SoID.Text = "営業所ID";
            // 
            // txt_SoID
            // 
            this.txt_SoID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SoID.Location = new System.Drawing.Point(170, 157);
            this.txt_SoID.Name = "txt_SoID";
            this.txt_SoID.Size = new System.Drawing.Size(772, 26);
            this.txt_SoID.TabIndex = 3;
            // 
            // lbl_OrID
            // 
            this.lbl_OrID.AutoSize = true;
            this.lbl_OrID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_OrID.Location = new System.Drawing.Point(7, 200);
            this.lbl_OrID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_OrID.Name = "lbl_OrID";
            this.lbl_OrID.Size = new System.Drawing.Size(71, 19);
            this.lbl_OrID.TabIndex = 84;
            this.lbl_OrID.Text = "受注ID";
            // 
            // txt_OrID
            // 
            this.txt_OrID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_OrID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_OrID.Location = new System.Drawing.Point(170, 197);
            this.txt_OrID.Name = "txt_OrID";
            this.txt_OrID.Size = new System.Drawing.Size(772, 26);
            this.txt_OrID.TabIndex = 4;
            // 
            // lbl_SyDate
            // 
            this.lbl_SyDate.AutoSize = true;
            this.lbl_SyDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SyDate.Location = new System.Drawing.Point(7, 240);
            this.lbl_SyDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SyDate.Name = "lbl_SyDate";
            this.lbl_SyDate.Size = new System.Drawing.Size(104, 19);
            this.lbl_SyDate.TabIndex = 87;
            this.lbl_SyDate.Text = "出庫年月日";
            // 
            // txt_SyDate
            // 
            this.txt_SyDate.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SyDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SyDate.Location = new System.Drawing.Point(170, 237);
            this.txt_SyDate.Name = "txt_SyDate";
            this.txt_SyDate.Size = new System.Drawing.Size(771, 26);
            this.txt_SyDate.TabIndex = 5;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.lbl_title.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_title.Location = new System.Drawing.Point(15, 18);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(183, 32);
            this.lbl_title.TabIndex = 246;
            this.lbl_title.Text = "出庫管理画面";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.chk_chumondetail);
            this.groupBox1.Controls.Add(this.lbl_SyID2);
            this.groupBox1.Controls.Add(this.txt_SyQuantity);
            this.groupBox1.Controls.Add(this.txt_SyID2);
            this.groupBox1.Controls.Add(this.lbl_SyDetailID);
            this.groupBox1.Controls.Add(this.lbl_ArQuantity);
            this.groupBox1.Controls.Add(this.txt_SyDetailID);
            this.groupBox1.Controls.Add(this.lbl_PrID);
            this.groupBox1.Controls.Add(this.txt_PrID);
            this.groupBox1.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(1000, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 382);
            this.groupBox1.TabIndex = 315;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出庫詳細項目";
            // 
            // chk_chumondetail
            // 
            this.chk_chumondetail.AutoSize = true;
            this.chk_chumondetail.Location = new System.Drawing.Point(133, 0);
            this.chk_chumondetail.Name = "chk_chumondetail";
            this.chk_chumondetail.Size = new System.Drawing.Size(15, 14);
            this.chk_chumondetail.TabIndex = 283;
            this.chk_chumondetail.UseVisualStyleBackColor = true;
            // 
            // lbl_SyID2
            // 
            this.lbl_SyID2.AutoSize = true;
            this.lbl_SyID2.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.lbl_SyID2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SyID2.Location = new System.Drawing.Point(5, 115);
            this.lbl_SyID2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SyID2.Name = "lbl_SyID2";
            this.lbl_SyID2.Size = new System.Drawing.Size(74, 20);
            this.lbl_SyID2.TabIndex = 315;
            this.lbl_SyID2.Text = "出庫ID";
            // 
            // txt_SyQuantity
            // 
            this.txt_SyQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SyQuantity.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.txt_SyQuantity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SyQuantity.Location = new System.Drawing.Point(131, 152);
            this.txt_SyQuantity.Name = "txt_SyQuantity";
            this.txt_SyQuantity.Size = new System.Drawing.Size(288, 27);
            this.txt_SyQuantity.TabIndex = 8;
            // 
            // txt_SyID2
            // 
            this.txt_SyID2.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SyID2.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.txt_SyID2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_SyID2.Location = new System.Drawing.Point(131, 108);
            this.txt_SyID2.Name = "txt_SyID2";
            this.txt_SyID2.Size = new System.Drawing.Size(288, 27);
            this.txt_SyID2.TabIndex = 312;
            // 
            // lbl_SyDetailID
            // 
            this.lbl_SyDetailID.AutoSize = true;
            this.lbl_SyDetailID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.lbl_SyDetailID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SyDetailID.Location = new System.Drawing.Point(7, 40);
            this.lbl_SyDetailID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SyDetailID.Name = "lbl_SyDetailID";
            this.lbl_SyDetailID.Size = new System.Drawing.Size(114, 20);
            this.lbl_SyDetailID.TabIndex = 307;
            this.lbl_SyDetailID.Text = "出庫詳細ID";
            // 
            // lbl_ArQuantity
            // 
            this.lbl_ArQuantity.AutoSize = true;
            this.lbl_ArQuantity.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.lbl_ArQuantity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_ArQuantity.Location = new System.Drawing.Point(5, 155);
            this.lbl_ArQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ArQuantity.Name = "lbl_ArQuantity";
            this.lbl_ArQuantity.Size = new System.Drawing.Size(49, 20);
            this.lbl_ArQuantity.TabIndex = 311;
            this.lbl_ArQuantity.Text = "数量";
            // 
            // txt_SyDetailID
            // 
            this.txt_SyDetailID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SyDetailID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.txt_SyDetailID.Location = new System.Drawing.Point(131, 32);
            this.txt_SyDetailID.Name = "txt_SyDetailID";
            this.txt_SyDetailID.Size = new System.Drawing.Size(288, 27);
            this.txt_SyDetailID.TabIndex = 6;
            // 
            // lbl_PrID
            // 
            this.lbl_PrID.AutoSize = true;
            this.lbl_PrID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.lbl_PrID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_PrID.Location = new System.Drawing.Point(5, 75);
            this.lbl_PrID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_PrID.Name = "lbl_PrID";
            this.lbl_PrID.Size = new System.Drawing.Size(74, 20);
            this.lbl_PrID.TabIndex = 309;
            this.lbl_PrID.Text = "商品ID";
            // 
            // txt_PrID
            // 
            this.txt_PrID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PrID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.5F);
            this.txt_PrID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_PrID.Location = new System.Drawing.Point(131, 72);
            this.txt_PrID.Name = "txt_PrID";
            this.txt_PrID.Size = new System.Drawing.Size(288, 27);
            this.txt_PrID.TabIndex = 7;
            // 
            // dataGridView_Syukko_Detail
            // 
            this.dataGridView_Syukko_Detail.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Syukko_Detail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("BIZ UDPゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Syukko_Detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Syukko_Detail.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Syukko_Detail.Location = new System.Drawing.Point(1000, 460);
            this.dataGridView_Syukko_Detail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Syukko_Detail.Name = "dataGridView_Syukko_Detail";
            this.dataGridView_Syukko_Detail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Syukko_Detail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Syukko_Detail.Size = new System.Drawing.Size(423, 412);
            this.dataGridView_Syukko_Detail.TabIndex = 314;
            this.dataGridView_Syukko_Detail.TabStop = false;
            this.dataGridView_Syukko_Detail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Syukko__Detail_CellDoubleClick);
            // 
            // btn_commit_FLG
            // 
            this.btn_commit_FLG.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_commit_FLG.FlatAppearance.BorderSize = 0;
            this.btn_commit_FLG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_commit_FLG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_commit_FLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_commit_FLG.Font = new System.Drawing.Font("BIZ UDPゴシック", 13F);
            this.btn_commit_FLG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_commit_FLG.Location = new System.Drawing.Point(1241, 10);
            this.btn_commit_FLG.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btn_commit_FLG.Name = "btn_commit_FLG";
            this.btn_commit_FLG.Size = new System.Drawing.Size(115, 53);
            this.btn_commit_FLG.TabIndex = 316;
            this.btn_commit_FLG.Text = "確定";
            this.btn_commit_FLG.UseVisualStyleBackColor = false;
            this.btn_commit_FLG.Click += new System.EventHandler(this.btn_commit_FLG_Click);
            // 
            // txt_loginSoID
            // 
            this.txt_loginSoID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_loginSoID.Enabled = false;
            this.txt_loginSoID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_loginSoID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_loginSoID.Location = new System.Drawing.Point(314, 10);
            this.txt_loginSoID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_loginSoID.Name = "txt_loginSoID";
            this.txt_loginSoID.Size = new System.Drawing.Size(87, 26);
            this.txt_loginSoID.TabIndex = 325;
            this.txt_loginSoID.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(219, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 328;
            this.label2.Text = "社員ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(219, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 327;
            this.label1.Text = "営業所ID";
            // 
            // btn_regist
            // 
            this.btn_regist.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_regist.FlatAppearance.BorderSize = 0;
            this.btn_regist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_regist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_regist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_regist.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_regist.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_regist.Location = new System.Drawing.Point(527, 10);
            this.btn_regist.Margin = new System.Windows.Forms.Padding(2);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(115, 53);
            this.btn_regist.TabIndex = 319;
            this.btn_regist.Text = "登録";
            this.btn_regist.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_update.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_update.Location = new System.Drawing.Point(646, 10);
            this.btn_update.Margin = new System.Windows.Forms.Padding(2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(115, 53);
            this.btn_update.TabIndex = 320;
            this.btn_update.Text = "更新";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_all.FlatAppearance.BorderSize = 0;
            this.btn_all.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_all.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_all.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_all.Location = new System.Drawing.Point(765, 10);
            this.btn_all.Margin = new System.Windows.Forms.Padding(2);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(115, 53);
            this.btn_all.TabIndex = 321;
            this.btn_all.Text = "一覧表示";
            this.btn_all.UseVisualStyleBackColor = false;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click_1);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_print.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_print.Location = new System.Drawing.Point(884, 10);
            this.btn_print.Margin = new System.Windows.Forms.Padding(2);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(115, 53);
            this.btn_print.TabIndex = 322;
            this.btn_print.Text = "印刷";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_delete.Location = new System.Drawing.Point(1003, 10);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(115, 53);
            this.btn_delete.TabIndex = 323;
            this.btn_delete.Text = "削除";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_clear.Location = new System.Drawing.Point(1122, 10);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(115, 53);
            this.btn_clear.TabIndex = 324;
            this.btn_clear.Text = "入力クリア";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btn_search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("BIZ UDPゴシック", 15F);
            this.btn_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_search.Location = new System.Drawing.Point(406, 10);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 53);
            this.btn_search.TabIndex = 318;
            this.btn_search.Text = "検索";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_sertch_Click);
            // 
            // txt_loginEmID
            // 
            this.txt_loginEmID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_loginEmID.Enabled = false;
            this.txt_loginEmID.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_loginEmID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_loginEmID.Location = new System.Drawing.Point(314, 37);
            this.txt_loginEmID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_loginEmID.Name = "txt_loginEmID";
            this.txt_loginEmID.Size = new System.Drawing.Size(87, 26);
            this.txt_loginEmID.TabIndex = 326;
            this.txt_loginEmID.Text = "123456";
            // 
            // dataGridView_Syukko
            // 
            this.dataGridView_Syukko.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Syukko.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("BIZ UDPゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Syukko.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Syukko.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Syukko.Location = new System.Drawing.Point(10, 461);
            this.dataGridView_Syukko.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Syukko.Name = "dataGridView_Syukko";
            this.dataGridView_Syukko.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Syukko.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Syukko.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_Syukko.Size = new System.Drawing.Size(950, 412);
            this.dataGridView_Syukko.TabIndex = 329;
            this.dataGridView_Syukko.TabStop = false;
            this.dataGridView_Syukko.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Syukko_CellDoubleClick);
            // 
            // F_Syukko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 888);
            this.Controls.Add(this.dataGridView_Syukko);
            this.Controls.Add(this.btn_commit_FLG);
            this.Controls.Add(this.txt_loginSoID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_loginEmID);
            this.Controls.Add(this.dataGridView_Syukko_Detail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "F_Syukko";
            this.Padding = new System.Windows.Forms.Padding(12, 60, 12, 13);
            this.Load += new System.EventHandler(this.F_Syukko_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Syukko_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Syukko)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_SyHidden;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label lbl_ArHidden;
        private System.Windows.Forms.CheckBox chk_hide_FLG;
        private System.Windows.Forms.Label lbl_memo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_SyID;
        private System.Windows.Forms.TextBox txt_SyID;
        private System.Windows.Forms.Label lbl_EnID;
        private System.Windows.Forms.TextBox txt_EmID;
        private System.Windows.Forms.Label lbl_ClID;
        private System.Windows.Forms.TextBox txt_ClID;
        private System.Windows.Forms.Label lbl_SoID;
        private System.Windows.Forms.TextBox txt_SoID;
        private System.Windows.Forms.Label lbl_OrID;
        private System.Windows.Forms.TextBox txt_OrID;
        private System.Windows.Forms.Label lbl_SyDate;
        private System.Windows.Forms.TextBox txt_SyDate;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_chumondetail;
        private System.Windows.Forms.DataGridView dataGridView_Syukko_Detail;
        private System.Windows.Forms.Button btn_commit_FLG;
        private System.Windows.Forms.TextBox txt_loginSoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_loginEmID;
        private System.Windows.Forms.CheckBox chk_chumon;
        private System.Windows.Forms.Label lbl_SyID2;
        private System.Windows.Forms.TextBox txt_SyDetailID;
        private System.Windows.Forms.Label lbl_SyDetailID;
        private System.Windows.Forms.TextBox txt_SyID2;
        private System.Windows.Forms.TextBox txt_PrID;
        private System.Windows.Forms.Label lbl_PrID;
        private System.Windows.Forms.TextBox txt_SyQuantity;
        private System.Windows.Forms.Label lbl_ArQuantity;
        private System.Windows.Forms.DataGridView dataGridView_Syukko;
    }
}