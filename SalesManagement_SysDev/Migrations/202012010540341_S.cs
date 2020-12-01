namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class S : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Chumon", "memo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Chumon", "memo");
        }
    }
}
