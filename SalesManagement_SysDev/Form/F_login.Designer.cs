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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ログイン = new System.Windows.Forms.ToolStripMenuItem();
            this.新規ログイン情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.ログイン履歴 = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.商品管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.商品情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.商品情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.受注管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.受注情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.受注情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.受注情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.受注情報削除 = new System.Windows.Forms.ToolStripMenuItem();
            this.注文管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注文情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.注文情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.注文情報削除 = new System.Windows.Forms.ToolStripMenuItem();
            this.入荷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入荷情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.入荷情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.入荷情報削除 = new System.Windows.Forms.ToolStripMenuItem();
            this.出荷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出荷情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.出荷情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.出荷情報削除 = new System.Windows.Forms.ToolStripMenuItem();
            this.在庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在庫情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.在庫情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.入庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入庫情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.入庫情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.出庫管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出庫情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.社員管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.社員情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.社員情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.社員情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.売上管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.売上情報更新 = new System.Windows.Forms.ToolStripMenuItem();
            this.売上情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.検品 = new System.Windows.Forms.ToolStripMenuItem();
            this.発注管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.発注情報登録 = new System.Windows.Forms.ToolStripMenuItem();
            this.発注情報検索 = new System.Windows.Forms.ToolStripMenuItem();
            this.発注情報削除 = new System.Windows.Forms.ToolStripMenuItem();
            this.バーコード管理 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.入力クリアToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_form_name_login = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_EmPassword = new System.Windows.Forms.Label();
            this.lbl_EmID = new System.Windows.Forms.Label();
            this.txt_EmPassword = new System.Windows.Forms.TextBox();
            this.txt_EmID = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CleateDabase
            // 
            this.btn_CleateDabase.Location = new System.Drawing.Point(661, 389);
            this.btn_CleateDabase.Name = "btn_CleateDabase";
            this.btn_CleateDabase.Size = new System.Drawing.Size(106, 49);
            this.btn_CleateDabase.TabIndex = 0;
            this.btn_CleateDabase.Text = "データベース生成";
            this.btn_CleateDabase.UseVisualStyleBackColor = true;
            this.btn_CleateDabase.Click += new System.EventHandler(this.btn_CleateDabase_Click);
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
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 3;
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
            this.検品,
            this.発注管理ToolStripMenuItem,
            this.バーコード管理});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.メニューToolStripMenuItem.Text = "管理メニュー";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ログイン,
            this.新規ログイン情報登録,
            this.ログイン履歴});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "ログイン管理";
            // 
            // ログイン
            // 
            this.ログイン.Name = "ログイン";
            this.ログイン.Size = new System.Drawing.Size(182, 22);
            this.ログイン.Text = "ログイン";
            this.ログイン.Click += new System.EventHandler(this.ログイン_Click);
            // 
            // 新規ログイン情報登録
            // 
            this.新規ログイン情報登録.Name = "新規ログイン情報登録";
            this.新規ログイン情報登録.Size = new System.Drawing.Size(182, 22);
            this.新規ログイン情報登録.Text = "新規ログイン情報登録";
            this.新規ログイン情報登録.Click += new System.EventHandler(this.新規ログイン情報登録_Click);
            // 
            // ログイン履歴
            // 
            this.ログイン履歴.Name = "ログイン履歴";
            this.ログイン履歴.Size = new System.Drawing.Size(182, 22);
            this.ログイン履歴.Text = "ログイン履歴";
            this.ログイン履歴.Click += new System.EventHandler(this.ログイン履歴_Click);
            // 
            // 顧客管理ToolStripMenuItem
            // 
            this.顧客管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顧客情報登録,
            this.顧客情報更新,
            this.顧客情報検索});
            this.顧客管理ToolStripMenuItem.Name = "顧客管理ToolStripMenuItem";
            this.顧客管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.顧客管理ToolStripMenuItem.Text = "顧客管理";
            // 
            // 顧客情報登録
            // 
            this.顧客情報登録.Name = "顧客情報登録";
            this.顧客情報登録.Size = new System.Drawing.Size(180, 22);
            this.顧客情報登録.Text = "顧客情報登録";
            this.顧客情報登録.Click += new System.EventHandler(this.顧客情報登録_Click);
            // 
            // 顧客情報更新
            // 
            this.顧客情報更新.Name = "顧客情報更新";
            this.顧客情報更新.Size = new System.Drawing.Size(180, 22);
            this.顧客情報更新.Text = "顧客情報更新";
            this.顧客情報更新.Click += new System.EventHandler(this.顧客情報更新_Click);
            // 
            // 顧客情報検索
            // 
            this.顧客情報検索.Name = "顧客情報検索";
            this.顧客情報検索.Size = new System.Drawing.Size(180, 22);
            this.顧客情報検索.Text = "顧客情報検索";
            this.顧客情報検索.Click += new System.EventHandler(this.顧客情報検索_Click);
            // 
            // 商品管理ToolStripMenuItem
            // 
            this.商品管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品情報登録,
            this.商品情報更新,
            this.商品情報検索});
            this.商品管理ToolStripMenuItem.Name = "商品管理ToolStripMenuItem";
            this.商品管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.商品管理ToolStripMenuItem.Text = "商品管理";
            // 
            // 商品情報登録
            // 
            this.商品情報登録.Name = "商品情報登録";
            this.商品情報登録.Size = new System.Drawing.Size(180, 22);
            this.商品情報登録.Text = "商品情報登録";
            this.商品情報登録.Click += new System.EventHandler(this.商品情報登録_Click);
            // 
            // 商品情報更新
            // 
            this.商品情報更新.Name = "商品情報更新";
            this.商品情報更新.Size = new System.Drawing.Size(180, 22);
            this.商品情報更新.Text = "商品情報更新";
            this.商品情報更新.Click += new System.EventHandler(this.商品情報更新_Click);
            // 
            // 商品情報検索
            // 
            this.商品情報検索.Name = "商品情報検索";
            this.商品情報検索.Size = new System.Drawing.Size(180, 22);
            this.商品情報検索.Text = "商品情報検索";
            this.商品情報検索.Click += new System.EventHandler(this.商品情報検索_Click);
            // 
            // 受注管理ToolStripMenuItem
            // 
            this.受注管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.受注情報登録,
            this.受注情報更新,
            this.受注情報検索,
            this.受注情報削除});
            this.受注管理ToolStripMenuItem.Name = "受注管理ToolStripMenuItem";
            this.受注管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.受注管理ToolStripMenuItem.Text = "受注管理";
            // 
            // 受注情報登録
            // 
            this.受注情報登録.Name = "受注情報登録";
            this.受注情報登録.Size = new System.Drawing.Size(180, 22);
            this.受注情報登録.Text = "受注情報登録";
            this.受注情報登録.Click += new System.EventHandler(this.受注情報登録_Click);
            // 
            // 受注情報更新
            // 
            this.受注情報更新.Name = "受注情報更新";
            this.受注情報更新.Size = new System.Drawing.Size(180, 22);
            this.受注情報更新.Text = "受注情報更新";
            this.受注情報更新.Click += new System.EventHandler(this.受注情報更新_Click);
            // 
            // 受注情報検索
            // 
            this.受注情報検索.Name = "受注情報検索";
            this.受注情報検索.Size = new System.Drawing.Size(180, 22);
            this.受注情報検索.Text = "受注情報検索";
            this.受注情報検索.Click += new System.EventHandler(this.受注情報検索_Click);
            // 
            // 受注情報削除
            // 
            this.受注情報削除.Name = "受注情報削除";
            this.受注情報削除.Size = new System.Drawing.Size(180, 22);
            this.受注情報削除.Text = "受注情報削除";
            this.受注情報削除.Click += new System.EventHandler(this.受注情報削除_Click);
            // 
            // 注文管理ToolStripMenuItem
            // 
            this.注文管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注文情報更新,
            this.注文情報検索,
            this.注文情報削除});
            this.注文管理ToolStripMenuItem.Name = "注文管理ToolStripMenuItem";
            this.注文管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.注文管理ToolStripMenuItem.Text = "注文管理";
            // 
            // 注文情報更新
            // 
            this.注文情報更新.Name = "注文情報更新";
            this.注文情報更新.Size = new System.Drawing.Size(180, 22);
            this.注文情報更新.Text = "注文情報更新";
            this.注文情報更新.Click += new System.EventHandler(this.注文情報更新_Click);
            // 
            // 注文情報検索
            // 
            this.注文情報検索.Name = "注文情報検索";
            this.注文情報検索.Size = new System.Drawing.Size(180, 22);
            this.注文情報検索.Text = "注文情報検索";
            this.注文情報検索.Click += new System.EventHandler(this.注文情報検索_Click);
            // 
            // 注文情報削除
            // 
            this.注文情報削除.Name = "注文情報削除";
            this.注文情報削除.Size = new System.Drawing.Size(180, 22);
            this.注文情報削除.Text = "注文情報削除";
            this.注文情報削除.Click += new System.EventHandler(this.注文情報削除_Click);
            // 
            // 入荷管理ToolStripMenuItem
            // 
            this.入荷管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入荷情報登録,
            this.入荷情報更新,
            this.入荷情報削除});
            this.入荷管理ToolStripMenuItem.Name = "入荷管理ToolStripMenuItem";
            this.入荷管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.入荷管理ToolStripMenuItem.Text = "入荷管理";
            // 
            // 入荷情報登録
            // 
            this.入荷情報登録.Name = "入荷情報登録";
            this.入荷情報登録.Size = new System.Drawing.Size(180, 22);
            this.入荷情報登録.Text = "入荷情報登録";
            this.入荷情報登録.Click += new System.EventHandler(this.入荷情報登録_Click);
            // 
            // 入荷情報更新
            // 
            this.入荷情報更新.Name = "入荷情報更新";
            this.入荷情報更新.Size = new System.Drawing.Size(180, 22);
            this.入荷情報更新.Text = "入荷情報更新";
            this.入荷情報更新.Click += new System.EventHandler(this.入荷情報更新_Click);
            // 
            // 入荷情報削除
            // 
            this.入荷情報削除.Name = "入荷情報削除";
            this.入荷情報削除.Size = new System.Drawing.Size(180, 22);
            this.入荷情報削除.Text = "入荷情報削除";
            this.入荷情報削除.Click += new System.EventHandler(this.入荷情報削除_Click);
            // 
            // 出荷管理ToolStripMenuItem
            // 
            this.出荷管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出荷情報登録,
            this.出荷情報更新,
            this.出荷情報削除});
            this.出荷管理ToolStripMenuItem.Name = "出荷管理ToolStripMenuItem";
            this.出荷管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.出荷管理ToolStripMenuItem.Text = "出荷管理";
            // 
            // 出荷情報登録
            // 
            this.出荷情報登録.Name = "出荷情報登録";
            this.出荷情報登録.Size = new System.Drawing.Size(180, 22);
            this.出荷情報登録.Text = "出荷情報登録";
            this.出荷情報登録.Click += new System.EventHandler(this.出荷情報登録_Click);
            // 
            // 出荷情報更新
            // 
            this.出荷情報更新.Name = "出荷情報更新";
            this.出荷情報更新.Size = new System.Drawing.Size(180, 22);
            this.出荷情報更新.Text = "出荷情報更新";
            this.出荷情報更新.Click += new System.EventHandler(this.出荷情報更新_Click);
            // 
            // 出荷情報削除
            // 
            this.出荷情報削除.Name = "出荷情報削除";
            this.出荷情報削除.Size = new System.Drawing.Size(180, 22);
            this.出荷情報削除.Text = "出荷情報削除";
            this.出荷情報削除.Click += new System.EventHandler(this.出荷情報削除_Click);
            // 
            // 在庫管理ToolStripMenuItem
            // 
            this.在庫管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在庫情報更新,
            this.在庫情報検索});
            this.在庫管理ToolStripMenuItem.Name = "在庫管理ToolStripMenuItem";
            this.在庫管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.在庫管理ToolStripMenuItem.Text = "在庫管理";
            // 
            // 在庫情報更新
            // 
            this.在庫情報更新.Name = "在庫情報更新";
            this.在庫情報更新.Size = new System.Drawing.Size(180, 22);
            this.在庫情報更新.Text = "在庫情報更新";
            this.在庫情報更新.Click += new System.EventHandler(this.在庫情報更新_Click);
            // 
            // 在庫情報検索
            // 
            this.在庫情報検索.Name = "在庫情報検索";
            this.在庫情報検索.Size = new System.Drawing.Size(180, 22);
            this.在庫情報検索.Text = "在庫情報検索";
            this.在庫情報検索.Click += new System.EventHandler(this.在庫情報検索_Click);
            // 
            // 入庫管理ToolStripMenuItem
            // 
            this.入庫管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入庫情報登録,
            this.入庫情報更新});
            this.入庫管理ToolStripMenuItem.Name = "入庫管理ToolStripMenuItem";
            this.入庫管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.入庫管理ToolStripMenuItem.Text = "入庫管理";
            // 
            // 入庫情報登録
            // 
            this.入庫情報登録.Name = "入庫情報登録";
            this.入庫情報登録.Size = new System.Drawing.Size(146, 22);
            this.入庫情報登録.Text = "入庫情報登録";
            // 
            // 入庫情報更新
            // 
            this.入庫情報更新.Name = "入庫情報更新";
            this.入庫情報更新.Size = new System.Drawing.Size(146, 22);
            this.入庫情報更新.Text = "入庫情報更新";
            // 
            // 出庫管理ToolStripMenuItem
            // 
            this.出庫管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.出庫情報登録});
            this.出庫管理ToolStripMenuItem.Name = "出庫管理ToolStripMenuItem";
            this.出庫管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.出庫管理ToolStripMenuItem.Text = "出庫管理";
            // 
            // 出庫情報登録
            // 
            this.出庫情報登録.Name = "出庫情報登録";
            this.出庫情報登録.Size = new System.Drawing.Size(146, 22);
            this.出庫情報登録.Text = "出庫情報登録";
            // 
            // 社員管理ToolStripMenuItem
            // 
            this.社員管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.社員情報登録,
            this.社員情報更新,
            this.社員情報検索});
            this.社員管理ToolStripMenuItem.Name = "社員管理ToolStripMenuItem";
            this.社員管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.社員管理ToolStripMenuItem.Text = "社員管理";
            // 
            // 社員情報登録
            // 
            this.社員情報登録.Name = "社員情報登録";
            this.社員情報登録.Size = new System.Drawing.Size(146, 22);
            this.社員情報登録.Text = "社員情報登録";
            // 
            // 社員情報更新
            // 
            this.社員情報更新.Name = "社員情報更新";
            this.社員情報更新.Size = new System.Drawing.Size(146, 22);
            this.社員情報更新.Text = "社員情報更新";
            // 
            // 社員情報検索
            // 
            this.社員情報検索.Name = "社員情報検索";
            this.社員情報検索.Size = new System.Drawing.Size(146, 22);
            this.社員情報検索.Text = "社員情報検索";
            // 
            // 売上管理ToolStripMenuItem
            // 
            this.売上管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.売上情報更新,
            this.売上情報検索});
            this.売上管理ToolStripMenuItem.Name = "売上管理ToolStripMenuItem";
            this.売上管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.売上管理ToolStripMenuItem.Text = "売上管理";
            // 
            // 売上情報更新
            // 
            this.売上情報更新.Name = "売上情報更新";
            this.売上情報更新.Size = new System.Drawing.Size(146, 22);
            this.売上情報更新.Text = "売上情報更新";
            // 
            // 売上情報検索
            // 
            this.売上情報検索.Name = "売上情報検索";
            this.売上情報検索.Size = new System.Drawing.Size(146, 22);
            this.売上情報検索.Text = "売上情報検索";
            // 
            // 検品
            // 
            this.検品.Name = "検品";
            this.検品.Size = new System.Drawing.Size(180, 22);
            this.検品.Text = "検品管理";
            // 
            // 発注管理ToolStripMenuItem
            // 
            this.発注管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.発注情報登録,
            this.発注情報検索,
            this.発注情報削除});
            this.発注管理ToolStripMenuItem.Name = "発注管理ToolStripMenuItem";
            this.発注管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.発注管理ToolStripMenuItem.Text = "発注管理";
            // 
            // 発注情報登録
            // 
            this.発注情報登録.Name = "発注情報登録";
            this.発注情報登録.Size = new System.Drawing.Size(146, 22);
            this.発注情報登録.Text = "発注情報登録";
            // 
            // 発注情報検索
            // 
            this.発注情報検索.Name = "発注情報検索";
            this.発注情報検索.Size = new System.Drawing.Size(146, 22);
            this.発注情報検索.Text = "発注情報検索";
            // 
            // 発注情報削除
            // 
            this.発注情報削除.Name = "発注情報削除";
            this.発注情報削除.Size = new System.Drawing.Size(146, 22);
            this.発注情報削除.Text = "発注情報削除";
            // 
            // バーコード管理
            // 
            this.バーコード管理.Name = "バーコード管理";
            this.バーコード管理.Size = new System.Drawing.Size(180, 22);
            this.バーコード管理.Text = "バーコード管理";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入力クリアToolStripMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(620, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 入力クリアToolStripMenuItem
            // 
            this.入力クリアToolStripMenuItem.Name = "入力クリアToolStripMenuItem";
            this.入力クリアToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.入力クリアToolStripMenuItem.Text = "入力クリア";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_login.Location = new System.Drawing.Point(328, 305);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(124, 32);
            this.btn_login.TabIndex = 18;
            this.btn_login.Text = "ログインする";
            this.btn_login.UseVisualStyleBackColor = false;
            // 
            // lbl_form_name_login
            // 
            this.lbl_form_name_login.AutoSize = true;
            this.lbl_form_name_login.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_form_name_login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_form_name_login.Location = new System.Drawing.Point(338, 45);
            this.lbl_form_name_login.Name = "lbl_form_name_login";
            this.lbl_form_name_login.Size = new System.Drawing.Size(93, 27);
            this.lbl_form_name_login.TabIndex = 17;
            this.lbl_form_name_login.Text = "ログイン";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(302, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "社員IDとパスワードを入力してください";
            // 
            // lbl_EmPassword
            // 
            this.lbl_EmPassword.AutoSize = true;
            this.lbl_EmPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_EmPassword.Location = new System.Drawing.Point(233, 233);
            this.lbl_EmPassword.Name = "lbl_EmPassword";
            this.lbl_EmPassword.Size = new System.Drawing.Size(52, 12);
            this.lbl_EmPassword.TabIndex = 15;
            this.lbl_EmPassword.Text = "パスワード";
            // 
            // lbl_EmID
            // 
            this.lbl_EmID.AutoSize = true;
            this.lbl_EmID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_EmID.Location = new System.Drawing.Point(233, 173);
            this.lbl_EmID.Name = "lbl_EmID";
            this.lbl_EmID.Size = new System.Drawing.Size(40, 12);
            this.lbl_EmID.TabIndex = 14;
            this.lbl_EmID.Text = "社員ID";
            // 
            // txt_EmPassword
            // 
            this.txt_EmPassword.Location = new System.Drawing.Point(298, 230);
            this.txt_EmPassword.Name = "txt_EmPassword";
            this.txt_EmPassword.Size = new System.Drawing.Size(183, 19);
            this.txt_EmPassword.TabIndex = 13;
            // 
            // txt_EmID
            // 
            this.txt_EmID.Location = new System.Drawing.Point(298, 170);
            this.txt_EmID.Name = "txt_EmID";
            this.txt_EmID.Size = new System.Drawing.Size(183, 19);
            this.txt_EmID.TabIndex = 12;
            // 
            // F_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_form_name_login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_EmPassword);
            this.Controls.Add(this.lbl_EmID);
            this.Controls.Add(this.txt_EmPassword);
            this.Controls.Add(this.txt_EmID);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.btn_CleateDabase);
            this.Name = "F_login";
            this.Text = "販売在庫管理システム　ログイン画面";
            this.Load += new System.EventHandler(this.F_login_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CleateDabase;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ログイン;
        private System.Windows.Forms.ToolStripMenuItem 新規ログイン情報登録;
        private System.Windows.Forms.ToolStripMenuItem ログイン履歴;
        private System.Windows.Forms.ToolStripMenuItem 顧客管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 顧客情報登録;
        private System.Windows.Forms.ToolStripMenuItem 顧客情報更新;
        private System.Windows.Forms.ToolStripMenuItem 顧客情報検索;
        private System.Windows.Forms.ToolStripMenuItem 商品管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品情報登録;
        private System.Windows.Forms.ToolStripMenuItem 商品情報更新;
        private System.Windows.Forms.ToolStripMenuItem 商品情報検索;
        private System.Windows.Forms.ToolStripMenuItem 受注管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 受注情報登録;
        private System.Windows.Forms.ToolStripMenuItem 受注情報更新;
        private System.Windows.Forms.ToolStripMenuItem 受注情報検索;
        private System.Windows.Forms.ToolStripMenuItem 受注情報削除;
        private System.Windows.Forms.ToolStripMenuItem 注文管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注文情報更新;
        private System.Windows.Forms.ToolStripMenuItem 注文情報検索;
        private System.Windows.Forms.ToolStripMenuItem 注文情報削除;
        private System.Windows.Forms.ToolStripMenuItem 入荷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入荷情報登録;
        private System.Windows.Forms.ToolStripMenuItem 入荷情報更新;
        private System.Windows.Forms.ToolStripMenuItem 入荷情報削除;
        private System.Windows.Forms.ToolStripMenuItem 出荷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出荷情報登録;
        private System.Windows.Forms.ToolStripMenuItem 出荷情報更新;
        private System.Windows.Forms.ToolStripMenuItem 出荷情報削除;
        private System.Windows.Forms.ToolStripMenuItem 在庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在庫情報更新;
        private System.Windows.Forms.ToolStripMenuItem 在庫情報検索;
        private System.Windows.Forms.ToolStripMenuItem 入庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入庫情報登録;
        private System.Windows.Forms.ToolStripMenuItem 入庫情報更新;
        private System.Windows.Forms.ToolStripMenuItem 出庫管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出庫情報登録;
        private System.Windows.Forms.ToolStripMenuItem 社員管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 社員情報登録;
        private System.Windows.Forms.ToolStripMenuItem 社員情報更新;
        private System.Windows.Forms.ToolStripMenuItem 社員情報検索;
        private System.Windows.Forms.ToolStripMenuItem 売上管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 売上情報更新;
        private System.Windows.Forms.ToolStripMenuItem 売上情報検索;
        private System.Windows.Forms.ToolStripMenuItem 検品;
        private System.Windows.Forms.ToolStripMenuItem 発注管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 発注情報登録;
        private System.Windows.Forms.ToolStripMenuItem 発注情報検索;
        private System.Windows.Forms.ToolStripMenuItem 発注情報削除;
        private System.Windows.Forms.ToolStripMenuItem バーコード管理;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 入力クリアToolStripMenuItem;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_form_name_login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_EmPassword;
        private System.Windows.Forms.Label lbl_EmID;
        private System.Windows.Forms.TextBox txt_EmPassword;
        private System.Windows.Forms.TextBox txt_EmID;
    }
}

