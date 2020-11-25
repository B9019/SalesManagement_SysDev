namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Chumon", "ChDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Chumon", "ChStateFlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Chumon", "ChStateFlag", c => c.Int());
            AlterColumn("dbo.T_Chumon", "ChDate", c => c.DateTime());
        }
    }
}
