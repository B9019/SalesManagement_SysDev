namespace SalesManagement_SysDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoreinkey6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_MajorCassificationM_SmallClassification",
                c => new
                    {
                        M_MajorCassification_McID = c.Int(nullable: false),
                        M_SmallClassification_ScID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.M_MajorCassification_McID, t.M_SmallClassification_ScID })
                .ForeignKey("dbo.M_MajorCassification", t => t.M_MajorCassification_McID, cascadeDelete: true)
                .ForeignKey("dbo.M_SmallClassification", t => t.M_SmallClassification_ScID, cascadeDelete: true)
                .Index(t => t.M_MajorCassification_McID)
                .Index(t => t.M_SmallClassification_ScID);
            
            AddColumn("dbo.M_Employee", "M_SmallClassification_ScID", c => c.Int());
            AddColumn("dbo.M_Product", "T_ChumonDetail_ChDetailID", c => c.Int());
            AddColumn("dbo.T_Chumon", "T_ChumonDetail_ChDetailID", c => c.Int());
            CreateIndex("dbo.M_Client", "SoID");
            CreateIndex("dbo.M_Employee", "SoID");
            CreateIndex("dbo.M_Employee", "PoID");
            CreateIndex("dbo.M_Employee", "M_SmallClassification_ScID");
            CreateIndex("dbo.T_Arrival", "SoID");
            CreateIndex("dbo.T_Arrival", "EmID");
            CreateIndex("dbo.T_Arrival", "ClID");
            CreateIndex("dbo.T_Arrival", "OrID");
            CreateIndex("dbo.T_ArrivalDetail", "ArID");
            CreateIndex("dbo.T_ArrivalDetail", "PrID");
            CreateIndex("dbo.M_Product", "ScID");
            CreateIndex("dbo.M_Product", "T_ChumonDetail_ChDetailID");
            CreateIndex("dbo.T_Hattyu", "MaID");
            CreateIndex("dbo.T_Hattyu", "EmID");
            CreateIndex("dbo.T_HattyuDetail", "HaID");
            CreateIndex("dbo.T_HattyuDetail", "PrID");
            CreateIndex("dbo.T_Warehousing", "HaID");
            CreateIndex("dbo.T_Warehousing", "EmID");
            CreateIndex("dbo.T_WarehousingDetail", "WaID");
            CreateIndex("dbo.T_WarehousingDetail", "PrID");
            CreateIndex("dbo.T_Chumon", "SoID");
            CreateIndex("dbo.T_Chumon", "EmID");
            CreateIndex("dbo.T_Chumon", "ClID");
            CreateIndex("dbo.T_Chumon", "OrID");
            CreateIndex("dbo.T_Chumon", "T_ChumonDetail_ChDetailID");
            CreateIndex("dbo.T_Order", "SoID");
            CreateIndex("dbo.T_Order", "EmID");
            CreateIndex("dbo.T_Order", "ClID");
            CreateIndex("dbo.T_OrderDetail", "OrID");
            CreateIndex("dbo.T_OrderDetail", "PrID");
            CreateIndex("dbo.T_Sale", "ClID");
            CreateIndex("dbo.T_Sale", "SoID");
            CreateIndex("dbo.T_Sale", "EmID");
            CreateIndex("dbo.T_Sale", "OrID");
            CreateIndex("dbo.T_SaleDetail", "SaID");
            CreateIndex("dbo.T_SaleDetail", "PrID");
            CreateIndex("dbo.T_Shipment", "ClID");
            CreateIndex("dbo.T_Shipment", "EmID");
            CreateIndex("dbo.T_Shipment", "SoID");
            CreateIndex("dbo.T_Shipment", "OrID");
            CreateIndex("dbo.T_Syukko", "EmID");
            CreateIndex("dbo.T_Syukko", "ClID");
            CreateIndex("dbo.T_Syukko", "SoID");
            CreateIndex("dbo.T_Syukko", "OrID");
            CreateIndex("dbo.T_SyukkoDetail", "SyID");
            CreateIndex("dbo.T_SyukkoDetail", "PrID");
            CreateIndex("dbo.T_ShipmentDetail", "PrID");
            CreateIndex("dbo.T_Stock", "PrID");
            CreateIndex("dbo.T_LoginHistory", "EmID");
            CreateIndex("dbo.T_OperationHistory", "EmID");
            AddForeignKey("dbo.M_Employee", "PoID", "dbo.M_Position", "PoID", cascadeDelete: true);
            AddForeignKey("dbo.M_Employee", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Arrival", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Arrival", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Arrival", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Hattyu", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Hattyu", "MaID", "dbo.M_Maker", "MaID", cascadeDelete: true);
            AddForeignKey("dbo.T_HattyuDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_HattyuDetail", "HaID", "dbo.T_Hattyu", "HaID", cascadeDelete: true);
            AddForeignKey("dbo.T_Warehousing", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Warehousing", "HaID", "dbo.T_Hattyu", "HaID", cascadeDelete: true);
            AddForeignKey("dbo.T_WarehousingDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_WarehousingDetail", "WaID", "dbo.T_Warehousing", "WaID", cascadeDelete: true);
            AddForeignKey("dbo.M_Employee", "M_SmallClassification_ScID", "dbo.M_SmallClassification", "ScID");
            AddForeignKey("dbo.M_Product", "ScID", "dbo.M_SmallClassification", "ScID", cascadeDelete: true);
            AddForeignKey("dbo.T_ArrivalDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.M_Product", "T_ChumonDetail_ChDetailID", "dbo.T_ChumonDetail", "ChDetailID");
            AddForeignKey("dbo.T_Chumon", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Chumon", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Chumon", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Chumon", "T_ChumonDetail_ChDetailID", "dbo.T_ChumonDetail", "ChDetailID");
            AddForeignKey("dbo.T_Order", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Order", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Order", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Arrival", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_Chumon", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_OrderDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_OrderDetail", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_Sale", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Sale", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Sale", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Sale", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_SaleDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_SaleDetail", "SaID", "dbo.T_Sale", "SaID", cascadeDelete: true);
            AddForeignKey("dbo.T_Shipment", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Shipment", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Shipment", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Shipment", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_Syukko", "ClID", "dbo.M_Client", "ClID", cascadeDelete: true);
            AddForeignKey("dbo.T_Syukko", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_Syukko", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
            AddForeignKey("dbo.T_Syukko", "OrID", "dbo.T_Order", "OrID", cascadeDelete: true);
            AddForeignKey("dbo.T_SyukkoDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_SyukkoDetail", "SyID", "dbo.T_Syukko", "SyID", cascadeDelete: true);
            AddForeignKey("dbo.T_ShipmentDetail", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_Stock", "PrID", "dbo.M_Product", "PrID", cascadeDelete: true);
            AddForeignKey("dbo.T_ArrivalDetail", "ArID", "dbo.T_Arrival", "ArID", cascadeDelete: true);
            AddForeignKey("dbo.T_LoginHistory", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.T_OperationHistory", "EmID", "dbo.M_Employee", "EmID", cascadeDelete: true);
            AddForeignKey("dbo.M_Client", "SoID", "dbo.M_SalesOffice", "SoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.M_Client", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_OperationHistory", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_LoginHistory", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_ArrivalDetail", "ArID", "dbo.T_Arrival");
            DropForeignKey("dbo.T_Stock", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_ShipmentDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_SyukkoDetail", "SyID", "dbo.T_Syukko");
            DropForeignKey("dbo.T_SyukkoDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_Syukko", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_Syukko", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Syukko", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Syukko", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.T_Shipment", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_Shipment", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Shipment", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Shipment", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.T_SaleDetail", "SaID", "dbo.T_Sale");
            DropForeignKey("dbo.T_SaleDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_Sale", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_Sale", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Sale", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Sale", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.T_OrderDetail", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_OrderDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_Chumon", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_Arrival", "OrID", "dbo.T_Order");
            DropForeignKey("dbo.T_Order", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Order", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Order", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.T_Chumon", "T_ChumonDetail_ChDetailID", "dbo.T_ChumonDetail");
            DropForeignKey("dbo.T_Chumon", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Chumon", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Chumon", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.M_Product", "T_ChumonDetail_ChDetailID", "dbo.T_ChumonDetail");
            DropForeignKey("dbo.T_ArrivalDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.M_Product", "ScID", "dbo.M_SmallClassification");
            DropForeignKey("dbo.M_MajorCassificationM_SmallClassification", "M_SmallClassification_ScID", "dbo.M_SmallClassification");
            DropForeignKey("dbo.M_MajorCassificationM_SmallClassification", "M_MajorCassification_McID", "dbo.M_MajorCassification");
            DropForeignKey("dbo.M_Employee", "M_SmallClassification_ScID", "dbo.M_SmallClassification");
            DropForeignKey("dbo.T_WarehousingDetail", "WaID", "dbo.T_Warehousing");
            DropForeignKey("dbo.T_WarehousingDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_Warehousing", "HaID", "dbo.T_Hattyu");
            DropForeignKey("dbo.T_Warehousing", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_HattyuDetail", "HaID", "dbo.T_Hattyu");
            DropForeignKey("dbo.T_HattyuDetail", "PrID", "dbo.M_Product");
            DropForeignKey("dbo.T_Hattyu", "MaID", "dbo.M_Maker");
            DropForeignKey("dbo.T_Hattyu", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Arrival", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.T_Arrival", "EmID", "dbo.M_Employee");
            DropForeignKey("dbo.T_Arrival", "ClID", "dbo.M_Client");
            DropForeignKey("dbo.M_Employee", "SoID", "dbo.M_SalesOffice");
            DropForeignKey("dbo.M_Employee", "PoID", "dbo.M_Position");
            DropIndex("dbo.M_MajorCassificationM_SmallClassification", new[] { "M_SmallClassification_ScID" });
            DropIndex("dbo.M_MajorCassificationM_SmallClassification", new[] { "M_MajorCassification_McID" });
            DropIndex("dbo.T_OperationHistory", new[] { "EmID" });
            DropIndex("dbo.T_LoginHistory", new[] { "EmID" });
            DropIndex("dbo.T_Stock", new[] { "PrID" });
            DropIndex("dbo.T_ShipmentDetail", new[] { "PrID" });
            DropIndex("dbo.T_SyukkoDetail", new[] { "PrID" });
            DropIndex("dbo.T_SyukkoDetail", new[] { "SyID" });
            DropIndex("dbo.T_Syukko", new[] { "OrID" });
            DropIndex("dbo.T_Syukko", new[] { "SoID" });
            DropIndex("dbo.T_Syukko", new[] { "ClID" });
            DropIndex("dbo.T_Syukko", new[] { "EmID" });
            DropIndex("dbo.T_Shipment", new[] { "OrID" });
            DropIndex("dbo.T_Shipment", new[] { "SoID" });
            DropIndex("dbo.T_Shipment", new[] { "EmID" });
            DropIndex("dbo.T_Shipment", new[] { "ClID" });
            DropIndex("dbo.T_SaleDetail", new[] { "PrID" });
            DropIndex("dbo.T_SaleDetail", new[] { "SaID" });
            DropIndex("dbo.T_Sale", new[] { "OrID" });
            DropIndex("dbo.T_Sale", new[] { "EmID" });
            DropIndex("dbo.T_Sale", new[] { "SoID" });
            DropIndex("dbo.T_Sale", new[] { "ClID" });
            DropIndex("dbo.T_OrderDetail", new[] { "PrID" });
            DropIndex("dbo.T_OrderDetail", new[] { "OrID" });
            DropIndex("dbo.T_Order", new[] { "ClID" });
            DropIndex("dbo.T_Order", new[] { "EmID" });
            DropIndex("dbo.T_Order", new[] { "SoID" });
            DropIndex("dbo.T_Chumon", new[] { "T_ChumonDetail_ChDetailID" });
            DropIndex("dbo.T_Chumon", new[] { "OrID" });
            DropIndex("dbo.T_Chumon", new[] { "ClID" });
            DropIndex("dbo.T_Chumon", new[] { "EmID" });
            DropIndex("dbo.T_Chumon", new[] { "SoID" });
            DropIndex("dbo.T_WarehousingDetail", new[] { "PrID" });
            DropIndex("dbo.T_WarehousingDetail", new[] { "WaID" });
            DropIndex("dbo.T_Warehousing", new[] { "EmID" });
            DropIndex("dbo.T_Warehousing", new[] { "HaID" });
            DropIndex("dbo.T_HattyuDetail", new[] { "PrID" });
            DropIndex("dbo.T_HattyuDetail", new[] { "HaID" });
            DropIndex("dbo.T_Hattyu", new[] { "EmID" });
            DropIndex("dbo.T_Hattyu", new[] { "MaID" });
            DropIndex("dbo.M_Product", new[] { "T_ChumonDetail_ChDetailID" });
            DropIndex("dbo.M_Product", new[] { "ScID" });
            DropIndex("dbo.T_ArrivalDetail", new[] { "PrID" });
            DropIndex("dbo.T_ArrivalDetail", new[] { "ArID" });
            DropIndex("dbo.T_Arrival", new[] { "OrID" });
            DropIndex("dbo.T_Arrival", new[] { "ClID" });
            DropIndex("dbo.T_Arrival", new[] { "EmID" });
            DropIndex("dbo.T_Arrival", new[] { "SoID" });
            DropIndex("dbo.M_Employee", new[] { "M_SmallClassification_ScID" });
            DropIndex("dbo.M_Employee", new[] { "PoID" });
            DropIndex("dbo.M_Employee", new[] { "SoID" });
            DropIndex("dbo.M_Client", new[] { "SoID" });
            DropColumn("dbo.T_Chumon", "T_ChumonDetail_ChDetailID");
            DropColumn("dbo.M_Product", "T_ChumonDetail_ChDetailID");
            DropColumn("dbo.M_Employee", "M_SmallClassification_ScID");
            DropTable("dbo.M_MajorCassificationM_SmallClassification");
        }
    }
}
