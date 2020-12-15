namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arrival12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.M_Product", "MaID", "dbo.M_Maker");
            DropIndex("dbo.M_Product", new[] { "MaID" });
            AlterColumn("dbo.T_Hattyu", "WaWarehouseFlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Hattyu", "WaWarehouseFlag", c => c.Int());
            CreateIndex("dbo.M_Product", "MaID");
            AddForeignKey("dbo.M_Product", "MaID", "dbo.M_Maker", "MaID", cascadeDelete: true);
        }
    }
}
