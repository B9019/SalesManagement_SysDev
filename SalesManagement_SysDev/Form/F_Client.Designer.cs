namespace SalesManagement_SysDev
{
    partial class F_Client
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
            this.lbl_ClFAX = new System.Windows.Forms.Label();
            this.lbl_ClPostal = new System.Windows.Forms.Label();
            this.lbl_ClPhone = new System.Windows.Forms.Label();
            this.lbl_ClAddress = new System.Windows.Forms.Label();
            this.lbl_ClName = new System.Windows.Forms.Label();
            this.txt_ClFAX = new System.Windows.Forms.TextBox();
            this.txt_ClPostal = new System.Windows.Forms.TextBox();
            this.txt_ClPhone = new System.Windows.Forms.TextBox();
            this.txt_ClAddress = new System.Windows.Forms.TextBox();
            this.txt_ClName = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_regist = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ログイン管理toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.受注管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注文管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入荷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出荷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.社員管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.売上管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.発注管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_Client = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ClHidden = new System.Windows.Forms.TextBox();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.lbl_ArHidden = new System.Windows.Forms.Label();
            this.lbl_memo = new System.Windows.Forms.Label();
            this.chk_ClFlag = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_ClID = new System.Windows.Forms.Label();
            this.txt_ClID = new System.Windows.Forms.TextBox();
            this.txt_SoID = new System.Windows.Forms.TextBox();
            this.lbl_SoID = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Client)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ClFAX
            // 
            this.lbl_ClFAX.AutoSize = true;
            this.lbl_ClFAX.ForeColor = System.Drawing.Color.White;
            this.lbl_ClFAX.Location = new System.Drawing.Point(5, 87);
            this.lbl_ClFAX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClFAX.Name = "lbl_ClFAX";
            this.lbl_ClFAX.Size = new System.Drawing.Size(27, 12);
            this.lbl_ClFAX.TabIndex = 74;
            this.lbl_ClFAX.Text = "FAX";
            // 
            // lbl_ClPostal
            // 
            this.lbl_ClPostal.AutoSize = true;
            this.lbl_ClPostal.ForeColor = System.Drawing.Color.White;
            this.lbl_ClPostal.Location = new System.Drawing.Point(274, 63);
            this.lbl_ClPostal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClPostal.Name = "lbl_ClPostal";
            this.lbl_ClPostal.Size = new System.Drawing.Size(53, 12);
            this.lbl_ClPostal.TabIndex = 72;
            this.lbl_ClPostal.Text = "郵便番号";
            // 
            // lbl_ClPhone
            // 
            this.lbl_ClPhone.AutoSize = true;
            this.lbl_ClPhone.ForeColor = System.Drawing.Color.White;
            this.lbl_ClPhone.Location = new System.Drawing.Point(5, 63);
            this.lbl_ClPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClPhone.Name = "lbl_ClPhone";
            this.lbl_ClPhone.Size = new System.Drawing.Size(53, 12);
            this.lbl_ClPhone.TabIndex = 12;
            this.lbl_ClPhone.Text = "電話番号";
            // 
            // lbl_ClAddress
            // 
            this.lbl_ClAddress.AutoSize = true;
            this.lbl_ClAddress.ForeColor = System.Drawing.Color.White;
            this.lbl_ClAddress.Location = new System.Drawing.Point(274, 87);
            this.lbl_ClAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClAddress.Name = "lbl_ClAddress";
            this.lbl_ClAddress.Size = new System.Drawing.Size(29, 12);
            this.lbl_ClAddress.TabIndex = 71;
            this.lbl_ClAddress.Text = "住所";
            // 
            // lbl_ClName
            // 
            this.lbl_ClName.AutoSize = true;
            this.lbl_ClName.ForeColor = System.Drawing.Color.White;
            this.lbl_ClName.Location = new System.Drawing.Point(5, 39);
            this.lbl_ClName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClName.Name = "lbl_ClName";
            this.lbl_ClName.Size = new System.Drawing.Size(41, 12);
            this.lbl_ClName.TabIndex = 70;
            this.lbl_ClName.Text = "顧客名";
            // 
            // txt_ClFAX
            // 
            this.txt_ClFAX.Location = new System.Drawing.Point(73, 85);
            this.txt_ClFAX.Name = "txt_ClFAX";
            this.txt_ClFAX.Size = new System.Drawing.Size(183, 19);
            this.txt_ClFAX.TabIndex = 68;
            // 
            // txt_ClPostal
            // 
            this.txt_ClPostal.Location = new System.Drawing.Point(321, 61);
            this.txt_ClPostal.Name = "txt_ClPostal";
            this.txt_ClPostal.Size = new System.Drawing.Size(183, 19);
            this.txt_ClPostal.TabIndex = 67;
            // 
            // txt_ClPhone
            // 
            this.txt_ClPhone.Location = new System.Drawing.Point(73, 61);
            this.txt_ClPhone.Name = "txt_ClPhone";
            this.txt_ClPhone.Size = new System.Drawing.Size(183, 19);
            this.txt_ClPhone.TabIndex = 66;
            // 
            // txt_ClAddress
            // 
            this.txt_ClAddress.Location = new System.Drawing.Point(321, 85);
            this.txt_ClAddress.Name = "txt_ClAddress";
            this.txt_ClAddress.Size = new System.Drawing.Size(183, 19);
            this.txt_ClAddress.TabIndex = 65;
            // 
            // txt_ClName
            // 
            this.txt_ClName.Location = new System.Drawing.Point(73, 37);
            this.txt_ClName.Name = "txt_ClName";
            this.txt_ClName.Size = new System.Drawing.Size(183, 19);
            this.txt_ClName.TabIndex = 64;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_clear.Location = new System.Drawing.Point(692, 1);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(79, 21);
            this.btn_clear.TabIndex = 167;
            this.btn_clear.Text = "F7 入力クリア";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_delete.Location = new System.Drawing.Point(607, 1);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 21);
            this.btn_delete.TabIndex = 166;
            this.btn_delete.Text = "F6 削除";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_print.Location = new System.Drawing.Point(523, 1);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(79, 21);
            this.btn_print.TabIndex = 165;
            this.btn_print.Text = "F5 印刷";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_all.Location = new System.Drawing.Point(438, 1);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(79, 21);
            this.btn_all.TabIndex = 164;
            this.btn_all.Text = "F4 一覧表示";
            this.btn_all.UseVisualStyleBackColor = false;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_update.Location = new System.Drawing.Point(353, 1);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(79, 21);
            this.btn_update.TabIndex = 163;
            this.btn_update.Text = "F3 更新";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_search.Location = new System.Drawing.Point(185, 1);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(79, 21);
            this.btn_search.TabIndex = 161;
            this.btn_search.Text = "F1　検索";
            this.btn_search.UseVisualStyleBackColor = false;
            // 
            // btn_regist
            // 
            this.btn_regist.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_regist.Location = new System.Drawing.Point(269, 1);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(79, 21);
            this.btn_regist.TabIndex = 162;
            this.btn_regist.Text = "F2 登録";
            this.btn_regist.UseVisualStyleBackColor = false;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(780, 24);
            this.menuStrip2.TabIndex = 160;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ログイン管理toolStripMenuItem1,
            this.顧客管理ToolStripMenuItem,
            this.商品管理ToolStripMenuItem,
            this.受注管理ToolStripMenuItem,
            this.注文管理ToolStripMenuItem,
            this.入荷管理ToolStripMenuItem,
            this.出荷管理ToolStripMenuItem,
            this.在庫管理ToolStripMenuItem,
            this.入庫管理ToolStripMenuItem,
            this.出庫管理ToolStripMenuItem,
            this.社員管理ToolStripMenuItem,
            this.売上管理ToolStripMenuItem,
            this.発注管理ToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.メニューToolStripMenuItem.Text = "管理メニュー";
            // 
            // ログイン管理toolStripMenuItem1
            // 
            this.ログイン管理toolStripMenuItem1.Name = "ログイン管理toolStripMenuItem1";
            this.ログイン管理toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.ログイン管理toolStripMenuItem1.Text = "ログイン管理";
            // 
            // 顧客管理ToolStripMenuItem
            // 
            this.顧客管理ToolStripMenuItem.Name = "顧客管理ToolStripMenuItem";
            this.顧客管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.顧客管理ToolStripMenuItem.Text = "顧客管理";
            // 
            // 商品管理ToolStripMenuItem
            // 
            this.商品管理ToolStripMenuItem.Name = "商品管理ToolStripMenuItem";
            this.商品管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.商品管理ToolStripMenuItem.Text = "商品管理";
            // 
            // 受注管理ToolStripMenuItem
            // 
            this.受注管理ToolStripMenuItem.Name = "受注管理ToolStripMenuItem";
            this.受注管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.受注管理ToolStripMenuItem.Text = "受注管理";
            // 
            // 注文管理ToolStripMenuItem
            // 
            this.注文管理ToolStripMenuItem.Name = "注文管理ToolStripMenuItem";
            this.注文管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.注文管理ToolStripMenuItem.Text = "注文管理";
            // 
            // 入荷管理ToolStripMenuItem
            // 
            this.入荷管理ToolStripMenuItem.Name = "入荷管理ToolStripMenuItem";
            this.入荷管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.入荷管理ToolStripMenuItem.Text = "入荷管理";
            // 
            // 出荷管理ToolStripMenuItem
            // 
            this.出荷管理ToolStripMenuItem.Name = "出荷管理ToolStripMenuItem";
            this.出荷管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.出荷管理ToolStripMenuItem.Text = "出荷管理";
            // 
            // 在庫管理ToolStripMenuItem
            // 
            this.在庫管理ToolStripMenuItem.Name = "在庫管理ToolStripMenuItem";
            this.在庫管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.在庫管理ToolStripMenuItem.Text = "在庫管理";
            // 
            // 入庫管理ToolStripMenuItem
            // 
            this.入庫管理ToolStripMenuItem.Name = "入庫管理ToolStripMenuItem";
            this.入庫管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.入庫管理ToolStripMenuItem.Text = "入庫管理";
            // 
            // 出庫管理ToolStripMenuItem
            // 
            this.出庫管理ToolStripMenuItem.Name = "出庫管理ToolStripMenuItem";
            this.出庫管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.出庫管理ToolStripMenuItem.Text = "出庫管理";
            // 
            // 社員管理ToolStripMenuItem
            // 
            this.社員管理ToolStripMenuItem.Name = "社員管理ToolStripMenuItem";
            this.社員管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.社員管理ToolStripMenuItem.Text = "社員管理";
            // 
            // 売上管理ToolStripMenuItem
            // 
            this.売上管理ToolStripMenuItem.Name = "売上管理ToolStripMenuItem";
            this.売上管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.売上管理ToolStripMenuItem.Text = "売上管理";
            // 
            // 発注管理ToolStripMenuItem
            // 
            this.発注管理ToolStripMenuItem.Name = "発注管理ToolStripMenuItem";
            this.発注管理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.発注管理ToolStripMenuItem.Text = "発注管理";
            // 
            // dataGridView_Client
            // 
            this.dataGridView_Client.Location = new System.Drawing.Point(8, 158);
            this.dataGridView_Client.Name = "dataGridView_Client";
            this.dataGridView_Client.Size = new System.Drawing.Size(763, 442);
            this.dataGridView_Client.TabIndex = 168;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Controls.Add(this.txt_ClHidden);
            this.groupBox2.Controls.Add(this.txt_memo);
            this.groupBox2.Controls.Add(this.lbl_ArHidden);
            this.groupBox2.Controls.Add(this.lbl_memo);
            this.groupBox2.Controls.Add(this.chk_ClFlag);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(521, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(250, 123);
            this.groupBox2.TabIndex = 169;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "追加項目";
            // 
            // txt_ClHidden
            // 
            this.txt_ClHidden.Location = new System.Drawing.Point(8, 101);
            this.txt_ClHidden.Multiline = true;
            this.txt_ClHidden.Name = "txt_ClHidden";
            this.txt_ClHidden.Size = new System.Drawing.Size(238, 19);
            this.txt_ClHidden.TabIndex = 77;
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(8, 35);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(237, 19);
            this.txt_memo.TabIndex = 70;
            // 
            // lbl_ArHidden
            // 
            this.lbl_ArHidden.AutoSize = true;
            this.lbl_ArHidden.ForeColor = System.Drawing.Color.White;
            this.lbl_ArHidden.Location = new System.Drawing.Point(6, 86);
            this.lbl_ArHidden.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ArHidden.Name = "lbl_ArHidden";
            this.lbl_ArHidden.Size = new System.Drawing.Size(77, 12);
            this.lbl_ArHidden.TabIndex = 63;
            this.lbl_ArHidden.Text = "入荷失敗理由";
            // 
            // lbl_memo
            // 
            this.lbl_memo.AutoSize = true;
            this.lbl_memo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_memo.Location = new System.Drawing.Point(5, 15);
            this.lbl_memo.Name = "lbl_memo";
            this.lbl_memo.Size = new System.Drawing.Size(73, 12);
            this.lbl_memo.TabIndex = 70;
            this.lbl_memo.Text = "備考(30文字)";
            // 
            // chk_ClFlag
            // 
            this.chk_ClFlag.AutoSize = true;
            this.chk_ClFlag.ForeColor = System.Drawing.Color.White;
            this.chk_ClFlag.Location = new System.Drawing.Point(8, 62);
            this.chk_ClFlag.Name = "chk_ClFlag";
            this.chk_ClFlag.Size = new System.Drawing.Size(97, 16);
            this.chk_ClFlag.TabIndex = 0;
            this.chk_ClFlag.Text = "入荷失敗フラグ";
            this.chk_ClFlag.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_ClPostal);
            this.groupBox3.Controls.Add(this.lbl_ClPostal);
            this.groupBox3.Controls.Add(this.lbl_ClFAX);
            this.groupBox3.Controls.Add(this.lbl_ClAddress);
            this.groupBox3.Controls.Add(this.txt_ClAddress);
            this.groupBox3.Controls.Add(this.lbl_ClID);
            this.groupBox3.Controls.Add(this.txt_ClFAX);
            this.groupBox3.Controls.Add(this.txt_ClID);
            this.groupBox3.Controls.Add(this.lbl_ClPhone);
            this.groupBox3.Controls.Add(this.txt_ClPhone);
            this.groupBox3.Controls.Add(this.txt_SoID);
            this.groupBox3.Controls.Add(this.lbl_SoID);
            this.groupBox3.Controls.Add(this.txt_ClName);
            this.groupBox3.Controls.Add(this.lbl_ClName);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(10, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(514, 123);
            this.groupBox3.TabIndex = 170;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基礎項目";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lbl_ClID
            // 
            this.lbl_ClID.AutoSize = true;
            this.lbl_ClID.ForeColor = System.Drawing.Color.White;
            this.lbl_ClID.Location = new System.Drawing.Point(274, 39);
            this.lbl_ClID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClID.Name = "lbl_ClID";
            this.lbl_ClID.Size = new System.Drawing.Size(40, 12);
            this.lbl_ClID.TabIndex = 71;
            this.lbl_ClID.Text = "顧客ID";
            // 
            // txt_ClID
            // 
            this.txt_ClID.Location = new System.Drawing.Point(321, 37);
            this.txt_ClID.Name = "txt_ClID";
            this.txt_ClID.Size = new System.Drawing.Size(183, 19);
            this.txt_ClID.TabIndex = 65;
            // 
            // txt_SoID
            // 
            this.txt_SoID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_SoID.Location = new System.Drawing.Point(73, 13);
            this.txt_SoID.Name = "txt_SoID";
            this.txt_SoID.Size = new System.Drawing.Size(183, 19);
            this.txt_SoID.TabIndex = 62;
            // 
            // lbl_SoID
            // 
            this.lbl_SoID.AutoSize = true;
            this.lbl_SoID.ForeColor = System.Drawing.Color.White;
            this.lbl_SoID.Location = new System.Drawing.Point(5, 15);
            this.lbl_SoID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SoID.Name = "lbl_SoID";
            this.lbl_SoID.Size = new System.Drawing.Size(52, 12);
            this.lbl_SoID.TabIndex = 8;
            this.lbl_SoID.Text = "営業所ID";
            // 
            // F_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(780, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.dataGridView_Client);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "F_Client";
            this.Text = "販売在庫管理システム　顧客情報管理画面";
            this.Load += new System.EventHandler(this.F_Client_Load_1);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Client)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_ClFAX;
        private System.Windows.Forms.Label lbl_ClPostal;
        private System.Windows.Forms.Label lbl_ClPhone;
        private System.Windows.Forms.Label lbl_ClAddress;
        private System.Windows.Forms.Label lbl_ClName;
        private System.Windows.Forms.TextBox txt_ClFAX;
        private System.Windows.Forms.TextBox txt_ClPostal;
        private System.Windows.Forms.TextBox txt_ClPhone;
        private System.Windows.Forms.TextBox txt_ClAddress;
        private System.Windows.Forms.TextBox txt_ClName;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ログイン管理toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 顧客管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 受注管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注文管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入荷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出荷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 社員管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 売上管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 発注管理ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_Client;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ClHidden;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label lbl_ArHidden;
        private System.Windows.Forms.Label lbl_memo;

        private System.Windows.Forms.CheckBox chk_ClFlag;
        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.Label lbl_ClID;
        private System.Windows.Forms.TextBox txt_ClID;
        private System.Windows.Forms.TextBox txt_SoID;
        private System.Windows.Forms.Label lbl_SoID;

    }
}