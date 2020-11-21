namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_Client",
                c => new
                    {
                        ClID = c.Int(nullable: false, identity: true),
                        SoID = c.Int(nullable: false),
                        ClName = c.String(nullable: false, maxLength: 50),
                        ClAddress = c.String(nullable: false, maxLength: 50),
                        ClPhone = c.String(nullable: false, maxLength: 13),
                        ClPostal = c.Int(nullable: false),
                        ClFAX = c.String(nullable: false, maxLength: 13),
                        ClFlag = c.Int(nullable: false),
                        ClHidden = c.String(),
                    })
                .PrimaryKey(t => t.ClID);
            
            CreateTable(
                "dbo.M_Employee",
                c => new
                    {
                        EmID = c.Int(nullable: false, identity: true),
                        EmName = c.String(nullable: false, maxLength: 50),
                        SoID = c.Int(nullable: false),
                        PoID = c.Int(nullable: false),
                        EmHiredate = c.DateTime(nullable: false),
                        EmPassword = c.String(nullable: false, maxLength: 10),
                        EmPhone = c.String(nullable: false, maxLength: 13),
                        EmFlag = c.Int(nullable: false),
                        EmHidden = c.String(),
                    })
                .PrimaryKey(t => t.EmID);
            
            CreateTable(
                "dbo.M_MajorCassification",
                c => new
                    {
                        McID = c.Int(nullable: false, identity: true),
                        McName = c.String(nullable: false, maxLength: 50),
                        McFlag = c.Int(nullable: false),
                        McHidden = c.String(),
                    })
                .PrimaryKey(t => t.McID);
            
            CreateTable(
                "dbo.M_Maker",
                c => new
                    {
                        MaID = c.Int(nullable: false, identity: true),
                        MaName = c.String(nullable: false, maxLength: 50),
                        MaAdress = c.String(nullable: false, maxLength: 50),
                        MaPhone = c.String(nullable: false, maxLength: 13),
                        MaPostal = c.String(nullable: false, maxLength: 7),
                        MaFAX = c.String(nullable: false, maxLength: 13),
                        MaFlag = c.Int(nullable: false),
                        MaHidden = c.String(),
                    })
                .PrimaryKey(t => t.MaID);
            
            CreateTable(
                "dbo.M_Position",
                c => new
                    {
                        PoID = c.Int(nullable: false, identity: true),
                        PoName = c.String(nullable: false, maxLength: 50),
                        PoFlag = c.Int(nullable: false),
                        PoHidden = c.String(),
                    })
                .PrimaryKey(t => t.PoID);
            
            CreateTable(
                "dbo.M_Product",
                c => new
                    {
                        PrID = c.Int(nullable: false, identity: true),
                        MaID = c.Int(nullable: false),
                        PrName = c.String(nullable: false, maxLength: 50),
                        Price = c.Int(nullable: false),
                        PrJCode = c.String(maxLength: 13),
                        PrSafetyStock = c.Int(nullable: false),
                        ScID = c.Int(nullable: false),
                        PrModelNumber = c.Int(nullable: false),
                        PrColor = c.String(nullable: false, maxLength: 20),
                        PrReleaseDate = c.DateTime(nullable: false),
                        PrFlag = c.Int(nullable: false),
                        PrHidden = c.String(),
                    })
                .PrimaryKey(t => t.PrID);
            
            CreateTable(
                "dbo.M_SalesOffice",
                c => new
                    {
                        SoID = c.Int(nullable: false, identity: true),
                        SoName = c.String(nullable: false, maxLength: 50),
                        SoAddress = c.String(nullable: false, maxLength: 50),
                        SoPhone = c.String(nullable: false, maxLength: 13),
                        SoPostal = c.String(nullable: false, maxLength: 7),
                        SoFAX = c.String(nullable: false, maxLength: 13),
                        SoFlag = c.Int(nullable: false),
                        SoHidden = c.String(),
                    })
                .PrimaryKey(t => t.SoID);
            
            CreateTable(
                "dbo.M_SmallClassification",
                c => new
                    {
                        ScID = c.Int(nullable: false, identity: true),
                        McID = c.Int(nullable: false),
                        ScName = c.String(nullable: false, maxLength: 50),
                        ScFlag = c.Int(nullable: false),
                        ScHidden = c.String(),
                    })
                .PrimaryKey(t => t.ScID);
            
            CreateTable(
                "dbo.T_ArrivalDetail",
                c => new
                    {
                        ArDetailID = c.Int(nullable: false, identity: true),
                        ArID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        ArQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArDetailID);
            
            CreateTable(
                "dbo.T_Arrival",
                c => new
                    {
                        ArID = c.Int(nullable: false, identity: true),
                        SoID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        ClID = c.Int(nullable: false),
                        OrID = c.Int(nullable: false),
                        ArDate = c.DateTime(),
                        ArStateFlag = c.Int(),
                        ArFlag = c.Int(nullable: false),
                        ArHidden = c.String(),
                    })
                .PrimaryKey(t => t.ArID);
            
            CreateTable(
                "dbo.T_ChumonDetail",
                c => new
                    {
                        ChDetailID = c.Int(nullable: false, identity: true),
                        ChID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        ChQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChDetailID);
            
            CreateTable(
                "dbo.T_Chumon",
                c => new
                    {
                        ChID = c.Int(nullable: false, identity: true),
                        SoID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        ClID = c.Int(nullable: false),
                        OrID = c.Int(nullable: false),
                        ChDate = c.DateTime(),
                        ChStateFlag = c.Int(),
                        ChFlag = c.Int(nullable: false),
                        ChHidden = c.String(),
                    })
                .PrimaryKey(t => t.ChID);
            
            CreateTable(
                "dbo.T_HattyuDetail",
                c => new
                    {
                        HaDetailID = c.Int(nullable: false, identity: true),
                        HaID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        HaQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HaDetailID);
            
            CreateTable(
                "dbo.T_Hattyu",
                c => new
                    {
                        HaID = c.Int(nullable: false, identity: true),
                        MaID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        HaDate = c.DateTime(nullable: false),
                        WaWarehouseFlag = c.Int(),
                        HaFlag = c.Int(nullable: false),
                        HaHidden = c.String(),
                    })
                .PrimaryKey(t => t.HaID);
            
            CreateTable(
                "dbo.T_LoginHistory",
                c => new
                    {
                        LoHistoryID = c.Int(nullable: false, identity: true),
                        EmID = c.Int(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        LogoutDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LoHistoryID);
            
            CreateTable(
                "dbo.T_OperationHistory",
                c => new
                    {
                        OpHistoryID = c.Int(nullable: false, identity: true),
                        EmID = c.Int(nullable: false),
                        ItemName = c.String(nullable: false, maxLength: 50),
                        OpStartTime = c.DateTime(nullable: false),
                        OpEndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.OpHistoryID);
            
            CreateTable(
                "dbo.T_OrderDetail",
                c => new
                    {
                        OrDetailID = c.Int(nullable: false, identity: true),
                        OrID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        OrQuantity = c.Int(nullable: false),
                        OrTotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrDetailID);
            
            CreateTable(
                "dbo.T_Order",
                c => new
                    {
                        OrID = c.Int(nullable: false, identity: true),
                        SoID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        ClID = c.Int(nullable: false),
                        ClCharge = c.String(nullable: false, maxLength: 50),
                        OrDate = c.DateTime(nullable: false),
                        OrStateFlag = c.Int(),
                        OrFlag = c.Int(nullable: false),
                        OrHidden = c.String(),
                    })
                .PrimaryKey(t => t.OrID);
            
            CreateTable(
                "dbo.T_Sale",
                c => new
                    {
                        SaID = c.Int(nullable: false, identity: true),
                        ClID = c.Int(nullable: false),
                        SoID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        ChID = c.Int(nullable: false),
                        SaDate = c.DateTime(nullable: false),
                        SaHidden = c.String(),
                        SaFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaID);
            
            CreateTable(
                "dbo.T_SaleDetail",
                c => new
                    {
                        SaDetailID = c.Int(nullable: false, identity: true),
                        SaID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        SaQuantity = c.Int(nullable: false),
                        SaPrTotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaDetailID);
            
            CreateTable(
                "dbo.T_ShipmentDetail",
                c => new
                    {
                        ShDetailID = c.Int(nullable: false, identity: true),
                        ShID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        ShDquantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShDetailID);
            
            CreateTable(
                "dbo.T_Shipment",
                c => new
                    {
                        ShID = c.Int(nullable: false, identity: true),
                        ClID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        SoID = c.Int(nullable: false),
                        OrID = c.Int(nullable: false),
                        ShStateFlag = c.Int(),
                        ShFinishDate = c.DateTime(),
                        ShFlag = c.Int(nullable: false),
                        ShHidden = c.String(),
                    })
                .PrimaryKey(t => t.ShID);
            
            CreateTable(
                "dbo.T_Stock",
                c => new
                    {
                        StID = c.Int(nullable: false, identity: true),
                        PrID = c.Int(nullable: false),
                        StQuantity = c.Int(nullable: false),
                        StFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StID);
            
            CreateTable(
                "dbo.T_SyukkoDetail",
                c => new
                    {
                        SyDetailID = c.Int(nullable: false, identity: true),
                        SyID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        SyQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SyDetailID);
            
            CreateTable(
                "dbo.T_Syukko",
                c => new
                    {
                        SyID = c.Int(nullable: false, identity: true),
                        EmID = c.Int(nullable: false),
                        ClID = c.Int(nullable: false),
                        SoID = c.Int(nullable: false),
                        OrID = c.Int(nullable: false),
                        SyDate = c.DateTime(),
                        SyStateFlag = c.Int(),
                        SyFlag = c.Int(nullable: false),
                        SyHidden = c.String(),
                    })
                .PrimaryKey(t => t.SyID);
            
            CreateTable(
                "dbo.T_WarehousingDetail",
                c => new
                    {
                        WaDetailID = c.Int(nullable: false, identity: true),
                        WaID = c.Int(nullable: false),
                        PrID = c.Int(nullable: false),
                        WaQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WaDetailID);
            
            CreateTable(
                "dbo.T_Warehousing",
                c => new
                    {
                        WaID = c.Int(nullable: false, identity: true),
                        HaID = c.Int(nullable: false),
                        EmID = c.Int(nullable: false),
                        WaDate = c.DateTime(nullable: false),
                        WaShelfFlag = c.Int(),
                        WaHidden = c.String(),
                        WaFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Warehousing");
            DropTable("dbo.T_WarehousingDetail");
            DropTable("dbo.T_Syukko");
            DropTable("dbo.T_SyukkoDetail");
            DropTable("dbo.T_Stock");
            DropTable("dbo.T_Shipment");
            DropTable("dbo.T_ShipmentDetail");
            DropTable("dbo.T_SaleDetail");
            DropTable("dbo.T_Sale");
            DropTable("dbo.T_Order");
            DropTable("dbo.T_OrderDetail");
            DropTable("dbo.T_OperationHistory");
            DropTable("dbo.T_LoginHistory");
            DropTable("dbo.T_Hattyu");
            DropTable("dbo.T_HattyuDetail");
            DropTable("dbo.T_Chumon");
            DropTable("dbo.T_ChumonDetail");
            DropTable("dbo.T_Arrival");
            DropTable("dbo.T_ArrivalDetail");
            DropTable("dbo.M_SmallClassification");
            DropTable("dbo.M_SalesOffice");
            DropTable("dbo.M_Product");
            DropTable("dbo.M_Position");
            DropTable("dbo.M_Maker");
            DropTable("dbo.M_MajorCassification");
            DropTable("dbo.M_Employee");
            DropTable("dbo.M_Client");
        }
    }
}
