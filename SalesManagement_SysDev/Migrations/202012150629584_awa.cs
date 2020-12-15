namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Shipment", "memo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Shipment", "memo");
        }
    }
}
