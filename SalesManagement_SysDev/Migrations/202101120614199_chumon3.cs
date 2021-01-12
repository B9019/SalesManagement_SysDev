namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chumon3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_Chumon", "memo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Chumon", "memo", c => c.String());
        }
    }
}
