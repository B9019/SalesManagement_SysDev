﻿namespace SalesManagement_SysDev
{
    partial class F_Shipment
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
            this.dataGridView_Shipment = new System.Windows.Forms.DataGridView();
            this.lbl_SaDate = new System.Windows.Forms.Label();
            this.lbl_ShID = new System.Windows.Forms.Label();
            this.lbl_ClID = new System.Windows.Forms.Label();
            this.lbl_EmID = new System.Windows.Forms.Label();
            this.txt_ShFinishDate = new System.Windows.Forms.TextBox();
            this.btn_sertch = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.txt_ShID = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ClID = new System.Windows.Forms.TextBox();
            this.txt_EmID = new System.Windows.Forms.TextBox();
            this.txt_OrID = new System.Windows.Forms.TextBox();
            this.txt_SoID = new System.Windows.Forms.TextBox();
            this.lbl_SoID = new System.Windows.Forms.Label();
            this.lbl_OrID = new System.Windows.Forms.Label();
            this.btn_regist = new System.Windows.Forms.Button();
            this.txt_ShHidden = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Shipment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Shipment
            // 

            this.dataGridView_Shipment.Location = new System.Drawing.Point(8, 158);
            this.dataGridView_Shipment.Name = "dataGridView_Shipment";
            this.dataGridView_Shipment.Size = new System.Drawing.Size(763, 442);
            this.dataGridView_Shipment.TabIndex = 185;

            // 
            // lbl_SaDate
            // 
            this.lbl_SaDate.AutoSize = true;
            this.lbl_SaDate.ForeColor = System.Drawing.Color.White;
            this.lbl_SaDate.Location = new System.Drawing.Point(259, 63);
            this.lbl_SaDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SaDate.Name = "lbl_SaDate";
            this.lbl_SaDate.Size = new System.Drawing.Size(89, 12);
            this.lbl_SaDate.TabIndex = 72;
            this.lbl_SaDate.Text = "出荷完了年月日";
            // 
            // lbl_ShID
            // 
            this.lbl_ShID.AutoSize = true;
            this.lbl_ShID.ForeColor = System.Drawing.Color.White;
            this.lbl_ShID.Location = new System.Drawing.Point(5, 63);
            this.lbl_ShID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ShID.Name = "lbl_ShID";
            this.lbl_ShID.Size = new System.Drawing.Size(40, 12);
            this.lbl_ShID.TabIndex = 12;
            this.lbl_ShID.Text = "出荷ID";
            // 
            // lbl_ClID
            // 
            this.lbl_ClID.AutoSize = true;
            this.lbl_ClID.ForeColor = System.Drawing.Color.White;
            this.lbl_ClID.Location = new System.Drawing.Point(259, 38);
            this.lbl_ClID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ClID.Name = "lbl_ClID";
            this.lbl_ClID.Size = new System.Drawing.Size(40, 12);
            this.lbl_ClID.TabIndex = 71;
            this.lbl_ClID.Text = "顧客ID";
            // 
            // lbl_EmID
            // 
            this.lbl_EmID.AutoSize = true;
            this.lbl_EmID.ForeColor = System.Drawing.Color.White;
            this.lbl_EmID.Location = new System.Drawing.Point(5, 39);
            this.lbl_EmID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_EmID.Name = "lbl_EmID";
            this.lbl_EmID.Size = new System.Drawing.Size(40, 12);
            this.lbl_EmID.TabIndex = 70;
            this.lbl_EmID.Text = "社員ID";
            // 
            // txt_ShFinishDate
            // 

            this.txt_ShFinishDate.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ShFinishDate.Location = new System.Drawing.Point(339, 61);
            this.txt_ShFinishDate.Name = "txt_ShFinishDate";
            this.txt_ShFinishDate.Size = new System.Drawing.Size(165, 19);
            this.txt_ShFinishDate.TabIndex = 67;

            // 
            // btn_sertch
            // 
            this.btn_sertch.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_sertch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_sertch.Location = new System.Drawing.Point(184, 1);
            this.btn_sertch.Name = "btn_sertch";
            this.btn_sertch.Size = new System.Drawing.Size(79, 21);
            this.btn_sertch.TabIndex = 187;
            this.btn_sertch.Text = "F1　検索";
            this.btn_sertch.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_update.Location = new System.Drawing.Point(352, 1);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(79, 21);
            this.btn_update.TabIndex = 189;
            this.btn_update.Text = "F3 更新";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_clear.Location = new System.Drawing.Point(692, 1);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(79, 21);
            this.btn_clear.TabIndex = 193;
            this.btn_clear.Text = "F7 入力クリア";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // txt_ShID
            // 
            this.txt_ShID.Location = new System.Drawing.Point(73, 61);
            this.txt_ShID.Name = "txt_ShID";
            this.txt_ShID.Size = new System.Drawing.Size(183, 19);
            this.txt_ShID.TabIndex = 66;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_delete.Location = new System.Drawing.Point(607, 1);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(79, 21);
            this.btn_delete.TabIndex = 192;
            this.btn_delete.Text = "F6 削除";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_all.Location = new System.Drawing.Point(437, 1);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(79, 21);
            this.btn_all.TabIndex = 190;
            this.btn_all.Text = "F4 一覧表示";
            this.btn_all.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_SaDate);
            this.groupBox1.Controls.Add(this.lbl_ShID);
            this.groupBox1.Controls.Add(this.lbl_ClID);
            this.groupBox1.Controls.Add(this.lbl_EmID);
            this.groupBox1.Controls.Add(this.txt_ShFinishDate);
            this.groupBox1.Controls.Add(this.txt_ShID);
            this.groupBox1.Controls.Add(this.txt_ClID);
            this.groupBox1.Controls.Add(this.txt_EmID);
            this.groupBox1.Controls.Add(this.txt_OrID);
            this.groupBox1.Controls.Add(this.txt_SoID);
            this.groupBox1.Controls.Add(this.lbl_SoID);
            this.groupBox1.Controls.Add(this.lbl_OrID);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 123);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基礎項目";
            // 
            // txt_ClID
            // 
            this.txt_ClID.Location = new System.Drawing.Point(339, 37);
            this.txt_ClID.Name = "txt_ClID";
            this.txt_ClID.Size = new System.Drawing.Size(165, 19);
            this.txt_ClID.TabIndex = 65;
            // 
            // txt_EmID
            // 
            this.txt_EmID.BackColor = System.Drawing.SystemColors.Window;
            this.txt_EmID.Location = new System.Drawing.Point(73, 36);
            this.txt_EmID.Name = "txt_EmID";
            this.txt_EmID.Size = new System.Drawing.Size(183, 19);
            this.txt_EmID.TabIndex = 64;
            // 
            // txt_OrID
            // 
            this.txt_OrID.Location = new System.Drawing.Point(339, 13);
            this.txt_OrID.Name = "txt_OrID";
            this.txt_OrID.Size = new System.Drawing.Size(165, 19);
            this.txt_OrID.TabIndex = 63;
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
            // lbl_OrID
            // 
            this.lbl_OrID.AutoSize = true;
            this.lbl_OrID.ForeColor = System.Drawing.Color.White;
            this.lbl_OrID.Location = new System.Drawing.Point(259, 15);
            this.lbl_OrID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_OrID.Name = "lbl_OrID";
            this.lbl_OrID.Size = new System.Drawing.Size(44, 12);
            this.lbl_OrID.TabIndex = 7;
            this.lbl_OrID.Text = "受注ID ";
            // 
            // btn_regist
            // 
            this.btn_regist.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_regist.Location = new System.Drawing.Point(268, 1);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(79, 21);
            this.btn_regist.TabIndex = 188;
            this.btn_regist.Text = "F2 登録";
            this.btn_regist.UseVisualStyleBackColor = false;
            this.btn_regist.Click += new System.EventHandler(this.btn_regist_Click);
            // 
            // txt_ShHidden
            // 

            this.txt_ShHidden.Location = new System.Drawing.Point(8, 101);
            this.txt_ShHidden.Multiline = true;
            this.txt_ShHidden.Name = "txt_ShHidden";
            this.txt_ShHidden.Size = new System.Drawing.Size(238, 19);
            this.txt_ShHidden.TabIndex = 77;


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
            // chk_hide_FLG
            // 
            this.chk_hide_FLG.AutoSize = true;
            this.chk_hide_FLG.ForeColor = System.Drawing.Color.White;
            this.chk_hide_FLG.Location = new System.Drawing.Point(8, 62);
            this.chk_hide_FLG.Name = "chk_hide_FLG";
            this.chk_hide_FLG.Size = new System.Drawing.Size(97, 16);
            this.chk_hide_FLG.TabIndex = 0;
            this.chk_hide_FLG.Text = "入荷失敗フラグ";
            this.chk_hide_FLG.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_print.Location = new System.Drawing.Point(523, 1);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(79, 21);
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
            this.menuStrip2.Size = new System.Drawing.Size(780, 24);
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
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
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
            this.groupBox2.Controls.Add(this.txt_ShHidden);
            this.groupBox2.Controls.Add(this.txt_memo);
            this.groupBox2.Controls.Add(this.lbl_ArHidden);
            this.groupBox2.Controls.Add(this.lbl_memo);
            this.groupBox2.Controls.Add(this.chk_hide_FLG);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(521, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(250, 123);
            this.groupBox2.TabIndex = 194;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "追加項目";
            // 
            // F_Shipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;

            this.ClientSize = new System.Drawing.Size(780, 499);
            this.Controls.Add(this.dataGridView_Shipment);

            this.Controls.Add(this.btn_sertch);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "F_Shipment";
            this.Text = "販売在庫管理システム　出荷情報管理画面";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Shipment)).EndInit();

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Shipment;
        private System.Windows.Forms.Label lbl_SaDate;
        private System.Windows.Forms.Label lbl_ShID;
        private System.Windows.Forms.Label lbl_ClID;
        private System.Windows.Forms.Label lbl_EmID;
        private System.Windows.Forms.TextBox txt_ShFinishDate;
        private System.Windows.Forms.Button btn_sertch;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox txt_ShID;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ClID;
        private System.Windows.Forms.TextBox txt_EmID;
        private System.Windows.Forms.TextBox txt_OrID;
        private System.Windows.Forms.TextBox txt_SoID;
        private System.Windows.Forms.Label lbl_SoID;
        private System.Windows.Forms.Label lbl_OrID;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.TextBox txt_ShHidden;
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
    }
}