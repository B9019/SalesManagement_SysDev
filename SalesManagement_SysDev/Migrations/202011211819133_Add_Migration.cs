namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessagesId = c.Int(nullable: false, identity: true),
                        MessagesNo = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.MessagesId);
            
            AddColumn("dbo.M_Product", "PrMemo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.M_Product", "PrMemo");
            DropTable("dbo.Messages");
        }
    }
}
