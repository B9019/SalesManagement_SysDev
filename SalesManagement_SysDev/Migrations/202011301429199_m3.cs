namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.M_Employee", "Emmemo", c => c.String());
            AddColumn("dbo.T_Arrival", "Armemo", c => c.String());
            AddColumn("dbo.T_Hattyu", "Hamemo", c => c.String());
            AddColumn("dbo.T_Sale", "OrID", c => c.Int(nullable: false));
            AddColumn("dbo.T_Sale", "Samemo", c => c.String());
            AlterColumn("dbo.T_Syukko", "SyDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_Syukko", "SyStateFlag", c => c.Int(nullable: false));
            DropColumn("dbo.T_Sale", "ChID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Sale", "ChID", c => c.Int(nullable: false));
            AlterColumn("dbo.T_Syukko", "SyStateFlag", c => c.Int());
            AlterColumn("dbo.T_Syukko", "SyDate", c => c.DateTime());
            DropColumn("dbo.T_Sale", "Samemo");
            DropColumn("dbo.T_Sale", "OrID");
            DropColumn("dbo.T_Hattyu", "Hamemo");
            DropColumn("dbo.T_Arrival", "Armemo");
            DropColumn("dbo.M_Employee", "Emmemo");
        }
    }
}
