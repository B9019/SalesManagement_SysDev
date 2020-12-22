namespace SalesManagement_SysDev
{
    partial class F_login
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_CleateDabase = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_EmPassword = new System.Windows.Forms.Label();
            this.lbl_EmID = new System.Windows.Forms.Label();
            this.txt_EmPassword = new System.Windows.Forms.TextBox();
            this.txt_EmID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_CleateDabase
            // 
            this.btn_CleateDabase.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.btn_CleateDabase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_CleateDabase.Location = new System.Drawing.Point(158, 302);
            this.btn_CleateDabase.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_CleateDabase.Name = "btn_CleateDabase";
            this.btn_CleateDabase.Size = new System.Drawing.Size(142, 62);
            this.btn_CleateDabase.TabIndex = 3;
            this.btn_CleateDabase.Text = "データベース生成";
            this.btn_CleateDabase.UseVisualStyleBackColor = true;
            this.btn_CleateDabase.Click += new System.EventHandler(this.btn_CleateDabase_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_login.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.btn_login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_login.Location = new System.Drawing.Point(143, 202);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(166, 40);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "ログインする";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(85, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "社員IDとパスワードを入力してください";
            // 
            // lbl_EmPassword
            // 
            this.lbl_EmPassword.AutoSize = true;
            this.lbl_EmPassword.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.lbl_EmPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EmPassword.Location = new System.Drawing.Point(24, 152);
            this.lbl_EmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_EmPassword.Name = "lbl_EmPassword";
            this.lbl_EmPassword.Size = new System.Drawing.Size(87, 17);
            this.lbl_EmPassword.TabIndex = 15;
            this.lbl_EmPassword.Text = "パスワード";
            // 
            // lbl_EmID
            // 
            this.lbl_EmID.AutoSize = true;
            this.lbl_EmID.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.lbl_EmID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_EmID.Location = new System.Drawing.Point(24, 100);
            this.lbl_EmID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_EmID.Name = "lbl_EmID";
            this.lbl_EmID.Size = new System.Drawing.Size(63, 17);
            this.lbl_EmID.TabIndex = 14;
            this.lbl_EmID.Text = "社員ID";
            // 
            // txt_EmPassword
            // 
            this.txt_EmPassword.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.txt_EmPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_EmPassword.Location = new System.Drawing.Point(190, 149);
            this.txt_EmPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_EmPassword.Name = "txt_EmPassword";
            this.txt_EmPassword.Size = new System.Drawing.Size(242, 24);
            this.txt_EmPassword.TabIndex = 1;
            // 
            // txt_EmID
            // 
            this.txt_EmID.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F);
            this.txt_EmID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_EmID.Location = new System.Drawing.Point(190, 97);
            this.txt_EmID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_EmID.Name = "txt_EmID";
            this.txt_EmID.Size = new System.Drawing.Size(242, 24);
            this.txt_EmID.TabIndex = 0;
            // 
            // F_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 418);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_EmPassword);
            this.Controls.Add(this.lbl_EmID);
            this.Controls.Add(this.txt_EmPassword);
            this.Controls.Add(this.txt_EmID);
            this.Controls.Add(this.btn_CleateDabase);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "F_login";
            this.Load += new System.EventHandler(this.F_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CleateDabase;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_EmPassword;
        private System.Windows.Forms.Label lbl_EmID;
        private System.Windows.Forms.TextBox txt_EmPassword;
        private System.Windows.Forms.TextBox txt_EmID;
    }
}

