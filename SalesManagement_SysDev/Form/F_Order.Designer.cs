namespace SalesManagement_SysDev
{
    partial class F_Order
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.lbl_memo = new System.Windows.Forms.Label();
            this.dataGridView_Product_regist = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_OrDate = new System.Windows.Forms.Label();
            this.lbl_ClID = new System.Windows.Forms.Label();
            this.lbl_ClCharge = new System.Windows.Forms.Label();
            this.lbl_EmID = new System.Windows.Forms.Label();
            this.txt_OrDate = new System.Windows.Forms.TextBox();
            this.txt_ClCharge = new System.Windows.Forms.TextBox();
            this.txt_ClID = new System.Windows.Forms.TextBox();
            this.txt_EmID = new System.Windows.Forms.TextBox();
            this.txt_SoID = new System.Windows.Forms.TextBox();
            this.lbl_SoID = new System.Windows.Forms.Label();
            this.txt_OrID = new System.Windows.Forms.TextBox();
            this.lbl_OrID = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_regist = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product_regist)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_memo);
            this.groupBox1.Controls.Add(this.lbl_memo);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(74, 229);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(968, 74);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任意項目";
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(140, 26);
            this.txt_memo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(379, 22);
            this.txt_memo.TabIndex = 70;
            // 
            // lbl_memo
            // 
            this.lbl_memo.AutoSize = true;
            this.lbl_memo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_memo.Location = new System.Drawing.Point(35, 30);
            this.lbl_memo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_memo.Name = "lbl_memo";
            this.lbl_memo.Size = new System.Drawing.Size(93, 15);
            this.lbl_memo.TabIndex = 70;
            this.lbl_memo.Text = "備考(30文字)";
            // 
            // dataGridView_Product_regist
            // 
            this.dataGridView_Product_regist.Location = new System.Drawing.Point(74, 340);
            this.dataGridView_Product_regist.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Product_regist.Name = "dataGridView_Product_regist";
            this.dataGridView_Product_regist.Size = new System.Drawing.Size(968, 285);
            this.dataGridView_Product_regist.TabIndex = 86;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_OrDate);
            this.groupBox2.Controls.Add(this.lbl_ClID);
            this.groupBox2.Controls.Add(this.lbl_ClCharge);
            this.groupBox2.Controls.Add(this.lbl_EmID);
            this.groupBox2.Controls.Add(this.txt_OrDate);
            this.groupBox2.Controls.Add(this.txt_ClCharge);
            this.groupBox2.Controls.Add(this.txt_ClID);
            this.groupBox2.Controls.Add(this.txt_EmID);
            this.groupBox2.Controls.Add(this.txt_SoID);
            this.groupBox2.Controls.Add(this.lbl_SoID);
            this.groupBox2.Controls.Add(this.txt_OrID);
            this.groupBox2.Controls.Add(this.lbl_OrID);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(74, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(968, 169);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "※必須項目";
            // 
            // lbl_OrDate
            // 
            this.lbl_OrDate.AutoSize = true;
            this.lbl_OrDate.ForeColor = System.Drawing.Color.White;
            this.lbl_OrDate.Location = new System.Drawing.Point(568, 132);
            this.lbl_OrDate.Name = "lbl_OrDate";
            this.lbl_OrDate.Size = new System.Drawing.Size(82, 15);
            this.lbl_OrDate.TabIndex = 75;
            this.lbl_OrDate.Text = "受注年月日";
            // 
            // lbl_ClID
            // 
            this.lbl_ClID.AutoSize = true;
            this.lbl_ClID.ForeColor = System.Drawing.Color.White;
            this.lbl_ClID.Location = new System.Drawing.Point(601, 80);
            this.lbl_ClID.Name = "lbl_ClID";
            this.lbl_ClID.Size = new System.Drawing.Size(51, 15);
            this.lbl_ClID.TabIndex = 74;
            this.lbl_ClID.Text = "顧客ID";
            // 
            // lbl_ClCharge
            // 
            this.lbl_ClCharge.AutoSize = true;
            this.lbl_ClCharge.ForeColor = System.Drawing.Color.White;
            this.lbl_ClCharge.Location = new System.Drawing.Point(7, 132);
            this.lbl_ClCharge.Name = "lbl_ClCharge";
            this.lbl_ClCharge.Size = new System.Drawing.Size(97, 15);
            this.lbl_ClCharge.TabIndex = 72;
            this.lbl_ClCharge.Text = "顧客担当者名";
            // 
            // lbl_EmID
            // 
            this.lbl_EmID.AutoSize = true;
            this.lbl_EmID.ForeColor = System.Drawing.Color.White;
            this.lbl_EmID.Location = new System.Drawing.Point(49, 80);
            this.lbl_EmID.Name = "lbl_EmID";
            this.lbl_EmID.Size = new System.Drawing.Size(51, 15);
            this.lbl_EmID.TabIndex = 71;
            this.lbl_EmID.Text = "社員ID";
            // 
            // txt_OrDate
            // 
            this.txt_OrDate.Location = new System.Drawing.Point(661, 129);
            this.txt_OrDate.Margin = new System.Windows.Forms.Padding(4);
            this.txt_OrDate.Name = "txt_OrDate";
            this.txt_OrDate.Size = new System.Drawing.Size(243, 22);
            this.txt_OrDate.TabIndex = 68;
            // 
            // txt_ClCharge
            // 
            this.txt_ClCharge.Location = new System.Drawing.Point(109, 129);
            this.txt_ClCharge.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClCharge.Name = "txt_ClCharge";
            this.txt_ClCharge.Size = new System.Drawing.Size(243, 22);
            this.txt_ClCharge.TabIndex = 67;
            // 
            // txt_ClID
            // 
            this.txt_ClID.Location = new System.Drawing.Point(661, 76);
            this.txt_ClID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ClID.Name = "txt_ClID";
            this.txt_ClID.Size = new System.Drawing.Size(243, 22);
            this.txt_ClID.TabIndex = 66;
            // 
            // txt_EmID
            // 
            this.txt_EmID.Location = new System.Drawing.Point(109, 76);
            this.txt_EmID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_EmID.Name = "txt_EmID";
            this.txt_EmID.Size = new System.Drawing.Size(243, 22);
            this.txt_EmID.TabIndex = 65;
            // 
            // txt_SoID
            // 
            this.txt_SoID.Location = new System.Drawing.Point(661, 22);
            this.txt_SoID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SoID.Name = "txt_SoID";
            this.txt_SoID.Size = new System.Drawing.Size(243, 22);
            this.txt_SoID.TabIndex = 64;
            // 
            // lbl_SoID
            // 
            this.lbl_SoID.AutoSize = true;
            this.lbl_SoID.ForeColor = System.Drawing.Color.White;
            this.lbl_SoID.Location = new System.Drawing.Point(585, 26);
            this.lbl_SoID.Name = "lbl_SoID";
            this.lbl_SoID.Size = new System.Drawing.Size(66, 15);
            this.lbl_SoID.TabIndex = 63;
            this.lbl_SoID.Text = "営業所ID";
            // 
            // txt_OrID
            // 
            this.txt_OrID.Location = new System.Drawing.Point(109, 22);
            this.txt_OrID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_OrID.Name = "txt_OrID";
            this.txt_OrID.Size = new System.Drawing.Size(243, 22);
            this.txt_OrID.TabIndex = 62;
            // 
            // lbl_OrID
            // 
            this.lbl_OrID.AutoSize = true;
            this.lbl_OrID.ForeColor = System.Drawing.Color.White;
            this.lbl_OrID.Location = new System.Drawing.Point(49, 26);
            this.lbl_OrID.Name = "lbl_OrID";
            this.lbl_OrID.Size = new System.Drawing.Size(51, 15);
            this.lbl_OrID.TabIndex = 8;
            this.lbl_OrID.Text = "受注ID";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clear.Location = new System.Drawing.Point(818, 693);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(115, 29);
            this.btn_clear.TabIndex = 151;
            this.btn_clear.Text = "F7　入力クリア";
            this.btn_clear.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_delete.Location = new System.Drawing.Point(710, 693);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(100, 29);
            this.btn_delete.TabIndex = 150;
            this.btn_delete.Text = "F6　削除";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_print.Location = new System.Drawing.Point(602, 693);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(100, 29);
            this.btn_print.TabIndex = 149;
            this.btn_print.Text = "F5　印刷";
            this.btn_print.UseVisualStyleBackColor = false;
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_all.Location = new System.Drawing.Point(480, 693);
            this.btn_all.Margin = new System.Windows.Forms.Padding(4);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(113, 29);
            this.btn_all.TabIndex = 148;
            this.btn_all.Text = "F4　一覧表示";
            this.btn_all.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_update.Location = new System.Drawing.Point(372, 693);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(100, 29);
            this.btn_update.TabIndex = 147;
            this.btn_update.Text = "F3　更新";
            this.btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_regist
            // 
            this.btn_regist.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_regist.Location = new System.Drawing.Point(264, 693);
            this.btn_regist.Margin = new System.Windows.Forms.Padding(4);
            this.btn_regist.Name = "btn_regist";
            this.btn_regist.Size = new System.Drawing.Size(100, 29);
            this.btn_regist.TabIndex = 146;
            this.btn_regist.Text = "F2　登録";
            this.btn_regist.UseVisualStyleBackColor = false;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_search.Location = new System.Drawing.Point(155, 693);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 29);
            this.btn_search.TabIndex = 145;
            this.btn_search.Text = "F1　検索";
            this.btn_search.UseVisualStyleBackColor = false;
            // 
            // F_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1132, 828);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_regist);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_Product_regist);
            this.Controls.Add(this.groupBox2);
            this.Name = "F_Order";
            this.Text = "販売在庫管理システム　受注情報管理画面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product_regist)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label lbl_memo;
        private System.Windows.Forms.DataGridView dataGridView_Product_regist;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_OrDate;
        private System.Windows.Forms.Label lbl_ClID;
        private System.Windows.Forms.Label lbl_ClCharge;
        private System.Windows.Forms.Label lbl_EmID;
        private System.Windows.Forms.TextBox txt_OrDate;
        private System.Windows.Forms.TextBox txt_ClCharge;
        private System.Windows.Forms.TextBox txt_ClID;
        private System.Windows.Forms.TextBox txt_EmID;
        private System.Windows.Forms.TextBox txt_SoID;
        private System.Windows.Forms.Label lbl_SoID;
        private System.Windows.Forms.TextBox txt_OrID;
        private System.Windows.Forms.Label lbl_OrID;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_regist;
        private System.Windows.Forms.Button btn_search;
    }
}