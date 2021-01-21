namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class syukko1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Arrival", "EmID", c => c.Int());
            AlterColumn("dbo.T_Shipment", "EmID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Shipment", "EmID", c => c.Int(nullable: false));
            AlterColumn("dbo.T_Arrival", "EmID", c => c.Int(nullable: false));
        }
    }
}
