namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreinkey3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.M_Product", "MaID");
            AddForeignKey("dbo.M_Product", "MaID", "dbo.M_Maker", "MaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.M_Product", "MaID", "dbo.M_Maker");
            DropIndex("dbo.M_Product", new[] { "MaID" });
        }
    }
}
