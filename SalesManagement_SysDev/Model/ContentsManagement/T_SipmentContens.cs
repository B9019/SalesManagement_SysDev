using SalesManagement_SysDev.Model.ContentsManagement.Common;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Model;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagement_SysDev.Model.ContentsManagement;

namespace SalesManagement_SysDev.Model.ContentsManagement
{
    class T_ShipmentContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        // ***** メソッド定義

        // データ取得
        // in  : shopId
        // out : shopデータ
        public T_Shipment GetShipment(int ShID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Shipments.Single(m => m.ShID == ShID);
            }
            catch
            {
                return null;
                // throw new Exception(Messages.errorNotFoundProduct);
            }
        }
        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点

        public IEnumerable<T_DispShipment> GetDispShipment()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispShipment> dispShipment = new List<T_DispShipment>();
                foreach (T_Shipment shipment in db.T_Shipments)
                {
                    string maker;
                    try
                    {
                        maker = (shipment.ShID != -1) ? db.T_Shipments.Single(m => m.ShID == shipment.ShID).ShHidden : string.Empty;

                        // 無効表示
                        if (db.T_Shipments.Single(m => m.ShID == shipment.ShID).ShFlag != 0) maker = "[" + shipment + "]";
                    }
                    catch
                    {
                        maker = string.Empty;
                    }

                    //string category;
                    //try
                    //{
                    //    category = (item.CategoryCD != -1) ? db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).CategoryName : string.Empty;

                    //    // 無効表示
                    //    if (db.M_Categorys.Single(m => m.CategoryCD == item.CategoryCD).DelFLG == true) category = "[" + category + "]";
                    //}
                    //catch
                    //{
                    //    category = string.Empty;
                    //}

                    dispShipment.Add(new T_DispShipment()
                    {
                        ShID = shipment.ShID,
                        SoID = shipment.SoID,
                        EmID = shipment.EmID,
                        ClID = shipment.ClID,
                        OrID = shipment.OrID,
                        ShFlag = shipment.ShFlag,
                        ShHidden = shipment.ShHidden
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispShipment> sortableDispShipment = new SortableBindingList<T_DispShipment>(dispShipment);
                //// ログ出力
                //var operationLog = new OperationLog()
                //{
                //    EventRaisingTime = DateTime.Now,
                //    Operator = _logonUser,
                //    Table = "Product",
                //    Command = "GetAll",
                //    Data = string.Empty,
                //    Comments = string.Empty
                //};
                //StaticCommon.PostOperationLog(operationLog);

                return sortableDispShipment;
            }
        }

        //// データ追加
        //// in   : M_Productデータ
        //public string PostM_Product(M_Product regM_Product)
        //{
        //    using (var db1 = new SalesManagement_DevContext())
        //    {
        //        db1.M_Products.Add(regM_Product);
        //        db1.Entry(regM_Product).State = EntityState.Added;

        //        try
        //        {
        //            db1.SaveChanges();
        //        }
        //        catch
        //        {
        //            // throw new Exception(Messages.errorConflict, ex);
        //            // throw new Exception(_cm.GetMessage(100), ex);
        //            // MessageBox.Show(_msc.GetMessage(100));
        //            return _msc.GetMessage(100);
        //        }
        //    }
        //}

        // データ追加
        // in   : M_Itemデータ
        public string PostT_Shipment(T_Shipment regShipment)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Shipments.Add(regShipment);
                db1.Entry(regShipment).State = EntityState.Added;
                db1.SaveChanges();
            }

            //// ログ出力
            //var operationLog = new OperationLog()
            //{
            //    EventRaisingTime = DateTime.Now,
            //    Operator = _logonUser,
            //    Table = "Product",
            //    Command = "Post",
            //    Data = M_ProductLogData(regProduct),
            //    Comments = string.Empty
            //};
            //StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }
        // データ更新
        // in   : M_Shipmentデータ
        // out  : エラーメッセージ 
        public string PutShipment(T_Shipment regShipment)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Shipment shipment;
                try
                {
                    shipment = db.T_Shipments.Single(x => x.ShID == regShipment.ShID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }

                shipment.ShID = regShipment.ShID;
                shipment.SoID = regShipment.SoID;
                shipment.EmID = regShipment.EmID;
                shipment.ClID = regShipment.ClID;
                shipment.OrID = regShipment.OrID;
                shipment.ShFinishDate = regShipment.ShFinishDate;
                shipment.ShFlag = regShipment.ShFlag;
                shipment.ShStateFlag = regShipment.ShStateFlag;
                shipment.ShHidden = regShipment.ShHidden;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(shipment).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Shipment",
                    Command = "Shi",
                    //Data = ProductLogData(regShipment),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ更新
        // in   : M_ShipmentDetailデータ
        // out  : エラーメッセージ 
        public string PutShipmentDetail(T_ShipmentDetail regShipmentDetail)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_ShipmentDetail shipmentDetail;
                try
                {
                    shipmentDetail = db.T_ShipmentDetails.Single(x => x.ShDetailID == regShipmentDetail.ShDetailID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }

                shipmentDetail.ShDetailID = regShipmentDetail.ShDetailID;
                shipmentDetail.ShID = regShipmentDetail.ShID;
                shipmentDetail.PrID = regShipmentDetail.PrID;
                shipmentDetail.ShDquantity = regShipmentDetail.ShDquantity;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(shipmentDetail).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    return _msc.GetMessage(100);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Shipment",
                    Command = "Shi",
                    //Data = ProductLogData(regShipment),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // データ削除
        // in       Product : 削除する商品ID
        public void DeleteShipment(int T_ShID)
        {
            T_Shipment shipment;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    shipment = db.T_Shipments.Single(x => x.ShID == T_ShID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundShipment, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Shipments.Remove(shipment);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                }

                // ログ出力
                var operationLog = new OperationLog()
                {
                    EventRaisingTime = DateTime.Now,
                    Operator = _logonUser,
                    Table = "Shipment",
                    Command = "Delete",
                    Data = shipment.ShID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_ShipmentLogData(T_Shipment regT_Shipment)
        {
            return regT_Shipment.ShID.ToString() + ", " +
            regT_Shipment.SoID.ToString() + ", " +
            regT_Shipment.EmID.ToString() + ", " +
            regT_Shipment.ClID.ToString() + ", " +
            regT_Shipment.OrID.ToString() + ", " +
            regT_Shipment.ShFinishDate +
            regT_Shipment.ShStateFlag.ToString() + ", " +
            regT_Shipment.ShFlag.ToString() + ", " +
            regT_Shipment.ShHidden;


        }
    }
}