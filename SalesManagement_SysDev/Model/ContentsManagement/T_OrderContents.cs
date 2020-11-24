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
    class T_OrderContents
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
        public T_Order GetOrder(int OrID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Orders.Single(m => m.OrID == OrID);
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

        public IEnumerable<T_DispOrder> GetDispOrder()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispOrder> dispOrder = new List<T_DispOrder>();
                foreach (T_Order order in db.T_Orders)
                {
                    string maker;
                    try
                    {
                        maker = (order.OrID != -1) ? db.T_Orders.Single(t => t.OrID == order.OrID).ClCharge : string.Empty;

                        // 無効表示
                        if (db.T_Orders.Single(t => t.OrID == order.OrID).OrFlag != 0) maker = "[" + order + "]";
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

                    dispOrder.Add(new T_DispOrder()
                    {
                        OrID = order.OrID,
                        SoID = order.SoID,
                        EmID = order.EmID,
                        ClID = order.ClID,
                        ClCharge = order.ClCharge,
                        OrDate = order.OrDate,
                        OrStateFlag = order.OrStateFlag,
                        OrFlag = order.OrFlag,
                        OrHidden = order.OrHidden,

                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispOrder> sortableDispOrder = new SortableBindingList<T_DispOrder>(dispOrder);

                //// ログ出力
                //var operationLog = new OperationLog()
                //{
                //    EventRaisingTime = DateTime.Now,
                //    Operator = _logonUser,
                //    Table = "Order",
                //    Command = "GetAll",
                //    Data = string.Empty,
                //    Comments = string.Empty
                //};
                //StaticCommon.PostOperationLog(operationLog);

                return sortableDispOrder;
            }
        }

        //// データ追加
        //// in   : T_Productデータ
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
        public string PostT_Order(T_Order regOrder)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Orders.Add(regOrder);
                db1.Entry(regOrder).State = EntityState.Added;
                db1.SaveChanges();
            }

            //// ログ出力
            //var operationLog = new OperationLog()
            //{
            //    EventRaisingTime = DateTime.Now,
            //    Operator = _logonUser,
            //    Table = "Order",
            //    Command = "Post",
            //    Data = T_OrderLogData(regOrder),
            //    Comments = string.Empty
            //};
            //StaticCommon.PostOperationLog(operationLog);

            return string.Empty;
        }
        // データ更新
        // in   : M_Productデータ
        // out  : エラーメッセージ 
        public string PutOrder(T_Order regOrder)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Order order;
                try
                {
                    order = db.T_Orders.Single(x => x.OrID == regOrder.OrID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                order.OrID = regOrder.OrID;
                order.SoID = regOrder.SoID;
                order.EmID = regOrder.EmID;
                order.ClID = regOrder.ClID;
                order.ClCharge = regOrder.ClCharge;
                order.OrDate = regOrder.OrDate;
                order.OrStateFlag = regOrder.OrStateFlag;
                order.OrFlag = regOrder.OrFlag;
                order.OrHidden = regOrder.OrHidden;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(order).State = EntityState.Modified;
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
                    Table = "Order",
                    Command = "Put",
                    //Data = ProductLogData(regProduct),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Product : 削除する商品ID
        public void DeleteOrder(int T_OrID)
        {
            T_Order order;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    order = db.T_Orders.Single(x => x.OrID == T_OrID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundProduct, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Orders.Remove(order);
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
                    Table = "Order",
                    Command = "Delete",
                    Data = order.OrID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_OrderLogData(T_Order regT_Order)
        {
            return regT_Order.OrID.ToString() + ", " +
            regT_Order.SoID.ToString() + ", " +
            regT_Order.EmID.ToString() + ", " +
            regT_Order.ClID.ToString() + ", " +
            regT_Order.ClCharge.ToString() + ", " +
            regT_Order.OrDate.ToString() + ", " +
            regT_Order.OrStateFlag.ToString() + ", " +

            regT_Order.OrFlag.ToString() + ", " +
            regT_Order.OrHidden;

        }
      }
    }
