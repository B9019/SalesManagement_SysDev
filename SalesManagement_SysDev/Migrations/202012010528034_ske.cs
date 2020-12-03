namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ske : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Warehousing", "WaShelfFlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Warehousing", "WaShelfFlag", c => c.Int());
        }
    }
}
