namespace SalesManagement_SysDev
{
    partial class F_Stock
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
            this.dataGridView_Stock = new System.Windows.Forms.DataGridView();
            this.btn_sertch = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_regist = new System.Windows.Forms.Button();
            this.txt_ChHidden = new System.Windows.Forms.TextBox();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.lbl_ArHidden = new System.Windows.Forms.Label();
            this.lbl_memo = new System.Windows.Forms.Label();
            this.chk_hide_FLG = new System.Windows.Forms.CheckBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_PrID = new System.Windows.Forms.Label();
            this.lbl_StQuantity = new System.Windows.Forms.Label();
            this.txt_PrID = new System.Windows.Forms.TextBox();
            this.txt_StQuantity = new System.Windows.Forms.TextBox();
            this.txt_StID = new System.Windows.Forms.TextBox();
            this.lbl_StID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stock)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Stock
            // 
            this.dataGridView_Stock.Location = new System.Drawing.Point(13, 237);
            this.dataGridView_Stock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView_Stock.Name = "dataGridView_Stock";
            this.dataGridView_Stock.Size = new System.Drawing.Size(1272, 663);
            this.dataGridView_Stock.TabIndex = 185;
            // 
            // btn_sertch
            // 
            this.btn_sertch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_sertch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_sertch.Location = new System.Drawing.Point(306, 2);
            this.btn_sertch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_sertch.Name = "btn_sertch";
            this.btn_sertch.Size = new System.Drawing.Size(132, 32);
            this.btn_sertch.TabIndex = 187;
            this.btn_sertch.Text = "F1　検索";
            this.btn_sertch.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_update.Location = new System.Drawing.Point(586, 2);
            this.btn_update.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(132, 32);
            this.btn_update.TabIndex = 189;
            this.btn_update.Text = "F3 更新";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_clear.Location = new System.Drawing.Point(1153, 2);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(132, 32);
            this.btn_clear.TabIndex = 193;
            this.btn_clear.Text = "F7 入力クリア";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_delete.Location = new System.Drawing.Point(1011, 2);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(132, 32);
            this.btn_delete.TabIndex = 192;
            this.btn_delete.Text = "F6 削除";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_all.Location = new System.Drawing.Point(727, 2);
            this.btn_all.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(132, 32);
            this.btn_all.TabIndex = 190;
            this.btn_all.Text = "F4 一覧表示";
            this.btn_all.UseVisualStyleBackColor = false;
            // 
            // btn_regist
            // 
            this.btn_regist.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_regist.Location = new System.Drawing.Point(446, 2);
            this.btn_regist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(132, 32);
            this.btn_regist.TabIndex = 188;
            this.btn_regist.Text = "F2 登録";
            this.btn_regist.UseVisualStyleBackColor = false;
            // 
            // txt_ChHidden
            // 
            this.txt_ChHidden.Location = new System.Drawing.Point(13, 152);
            this.txt_ChHidden.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ChHidden.Multiline = true;
            this.txt_ChHidden.Name = "txt_ChHidden";
            this.txt_ChHidden.Size = new System.Drawing.Size(394, 26);
            this.txt_ChHidden.TabIndex = 77;
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(13, 52);
            this.txt_memo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(392, 26);
            this.txt_memo.TabIndex = 70;
            // 
            // lbl_ArHidden
            // 
            this.lbl_ArHidden.AutoSize = true;
            this.lbl_ArHidden.ForeColor = System.Drawing.Color.White;
            this.lbl_ArHidden.Location = new System.Drawing.Point(10, 129);
            this.lbl_ArHidden.Name = "lbl_ArHidden";
            this.lbl_ArHidden.Size = new System.Drawing.Size(77, 12);
            this.lbl_ArHidden.TabIndex = 63;
            this.lbl_ArHidden.Text = "入荷失敗理由";
            // 
            // lbl_memo
            // 
            this.lbl_memo.AutoSize = true;
            this.lbl_memo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_memo.Location = new System.Drawing.Point(8, 22);
            this.lbl_memo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_memo.Name = "lbl_memo";
            this.lbl_memo.Size = new System.Drawing.Size(73, 12);
            this.lbl_memo.TabIndex = 70;
            this.lbl_memo.Text = "備考(30文字)";
            // 
            // chk_hide_FLG
            // 
            this.chk_hide_FLG.AutoSize = true;
            this.chk_hide_FLG.ForeColor = System.Drawing.Color.White;
            this.chk_hide_FLG.Location = new System.Drawing.Point(13, 93);
            this.chk_hide_FLG.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chk_hide_FLG.Name = "chk_hide_FLG";
            this.chk_hide_FLG.Size = new System.Drawing.Size(97, 16);
            this.chk_hide_FLG.TabIndex = 0;
            this.chk_hide_FLG.Text = "入荷失敗フラグ";
            this.chk_hide_FLG.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_print.Location = new System.Drawing.Point(871, 2);
            this.btn_print.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(132, 32);
            this.btn_print.TabIndex = 191;
            this.btn_print.Text = "F5 印刷";
            this.btn_print.UseVisualStyleBackColor = false;
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
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1300, 25);
            this.menuStrip2.TabIndex = 186;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
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
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(76, 19);
            this.メニューToolStripMenuItem.Text = "管理メニュー";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem1.Text = "ログイン管理";
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Controls.Add(this.txt_ChHidden);
            this.groupBox2.Controls.Add(this.txt_memo);
            this.groupBox2.Controls.Add(this.lbl_ArHidden);
            this.groupBox2.Controls.Add(this.lbl_memo);
            this.groupBox2.Controls.Add(this.chk_hide_FLG);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(868, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(417, 184);
            this.groupBox2.TabIndex = 194;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "追加項目";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_PrID);
            this.groupBox1.Controls.Add(this.lbl_StQuantity);
            this.groupBox1.Controls.Add(this.txt_PrID);
            this.groupBox1.Controls.Add(this.txt_StQuantity);
            this.groupBox1.Controls.Add(this.txt_StID);
            this.groupBox1.Controls.Add(this.lbl_StID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(856, 184);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基礎項目";
            // 
            // lbl_PrID
            // 
            this.lbl_PrID.AutoSize = true;
            this.lbl_PrID.ForeColor = System.Drawing.Color.White;
            this.lbl_PrID.Location = new System.Drawing.Point(437, 22);
            this.lbl_PrID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PrID.Name = "lbl_PrID";
            this.lbl_PrID.Size = new System.Drawing.Size(40, 12);
            this.lbl_PrID.TabIndex = 71;
            this.lbl_PrID.Text = "商品ID";
            // 
            // lbl_StQuantity
            // 
            this.lbl_StQuantity.AutoSize = true;
            this.lbl_StQuantity.ForeColor = System.Drawing.Color.White;
            this.lbl_StQuantity.Location = new System.Drawing.Point(9, 58);
            this.lbl_StQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StQuantity.Name = "lbl_StQuantity";
            this.lbl_StQuantity.Size = new System.Drawing.Size(41, 12);
            this.lbl_StQuantity.TabIndex = 70;
            this.lbl_StQuantity.Text = "在庫数";
            // 
            // txt_PrID
            // 
            this.txt_PrID.Location = new System.Drawing.Point(535, 19);
            this.txt_PrID.Margin = new System.Windows.Forms.Padding(5);
            this.txt_PrID.Name = "txt_PrID";
            this.txt_PrID.Size = new System.Drawing.Size(303, 19);
            this.txt_PrID.TabIndex = 65;
            // 
            // txt_StQuantity
            // 
            this.txt_StQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.txt_StQuantity.Location = new System.Drawing.Point(121, 54);
            this.txt_StQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.txt_StQuantity.Name = "txt_StQuantity";
            this.txt_StQuantity.Size = new System.Drawing.Size(303, 19);
            this.txt_StQuantity.TabIndex = 64;
            // 
            // txt_StID
            // 
            this.txt_StID.Location = new System.Drawing.Point(121, 18);
            this.txt_StID.Margin = new System.Windows.Forms.Padding(5);
            this.txt_StID.Name = "txt_StID";
            this.txt_StID.Size = new System.Drawing.Size(303, 19);
            this.txt_StID.TabIndex = 63;
            // 
            // lbl_StID
            // 
            this.lbl_StID.AutoSize = true;
            this.lbl_StID.ForeColor = System.Drawing.Color.White;
            this.lbl_StID.Location = new System.Drawing.Point(9, 21);
            this.lbl_StID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StID.Name = "lbl_StID";
            this.lbl_StID.Size = new System.Drawing.Size(44, 12);
            this.lbl_StID.TabIndex = 7;
            this.lbl_StID.Text = "在庫ID ";
            // 
            // F_Stock
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1300, 914);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_Stock);
            this.Controls.Add(this.btn_sertch);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBox2);
            this.Name = "F_Stock";
            this.Text = "販売在庫管理システム　在庫情報管理画面";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stock)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Stock;
        private System.Windows.Forms.Button btn_sertch;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.TextBox txt_ChHidden;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label lbl_ArHidden;
        private System.Windows.Forms.Label lbl_memo;
        private System.Windows.Forms.CheckBox chk_hide_FLG;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_PrID;
        private System.Windows.Forms.Label lbl_StQuantity;
        private System.Windows.Forms.TextBox txt_PrID;
        private System.Windows.Forms.TextBox txt_StQuantity;
        private System.Windows.Forms.TextBox txt_StID;
        private System.Windows.Forms.Label lbl_StID;
    }
}