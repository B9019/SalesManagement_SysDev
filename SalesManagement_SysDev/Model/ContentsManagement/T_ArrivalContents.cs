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
    class T_ArrivalContents
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
        // in  : ArID
        // out : arrivalデータ
        public T_Arrival GetArrival(int ArID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Arrivals.Single(m => m.ArID == ArID);
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
        
        public IEnumerable<T_DispArrival> GetDispArrivals()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispArrival> dispArrivals = new List<T_DispArrival>();
                foreach (T_Arrival arrival in db.T_Arrivals)
                {
                    string maker;
                    try
                    {
                        maker = (arrival.ArID != -1) ? db.T_Arrivals.Single(m => m.ArID == arrival.ArID).Armemo : string.Empty;

                        // 無効表示
                        if (db.T_Arrivals.Single(m => m.ArID == arrival.ArID).ArStateFlag != 0) maker = "[" + maker + "]";
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

                    dispArrivals.Add(new T_DispArrival()
                    {
                        ArID = arrival.ArID,
                        SoID = arrival.SoID,
                        EmID = arrival.EmID,
                        ClID = arrival.ClID,
                        OrID = arrival.OrID,
                        ArDate = arrival.ArDate,
                        Armemo = arrival.Armemo,
                        ArHidden = arrival.ArHidden,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispArrival> sortableDispArrival = new SortableBindingList<T_DispArrival>(dispArrivals);
            
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

                return sortableDispArrival;
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
        // in   : T_Arrivalデータ
        public string PostT_Arrival(T_Arrival regArrival)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Arrivals.Add(regArrival);
                db1.Entry(regArrival).State = EntityState.Added;
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
        // データ追加
        // in   : T_ArrivalDetailデータ
        public string PostT_ArrivalDetail(T_ArrivalDetail regArrivalDetail)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_ArrivalDetails.Add(regArrivalDetail);
                db1.Entry(regArrivalDetail).State = EntityState.Added;
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
        // in   : T_Arrivalデータ
        // out  : エラーメッセージ 
        public string PutArrival(T_Arrival regArrival)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Arrival arrival;
                try
                {
                    arrival = db.T_Arrivals.Single(x => x.ArID == regArrival.ArID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                arrival.ArID = regArrival.ArID;
                arrival.SoID = regArrival.SoID;
                arrival.EmID = regArrival.EmID;
                arrival.ClID = regArrival.ClID;
                arrival.OrID = regArrival.OrID;
                arrival.ArDate = regArrival.ArDate;
                arrival.Armemo = regArrival.Armemo;
                arrival.ArHidden = regArrival.ArHidden;

                db.Entry(arrival).State = EntityState.Modified;
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
                    Table = "Arrival",
                    Command = "Put",
                    //Data = ArrivalLogData(regArrival),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ更新
        // in   : T_ArrivalDetailデータ
        // out  : エラーメッセージ 
        public string PutArrivalDetail(T_ArrivalDetail regArrivalDetail)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_ArrivalDetail arrivalDetail;
                try
                {
                    arrivalDetail = db.T_ArrivalDetails.Single(x => x.ArID == regArrivalDetail.ArID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                arrivalDetail.ArDetailID = regArrivalDetail.ArDetailID;
                arrivalDetail.ArID = regArrivalDetail.ArID;
                arrivalDetail.PrID = regArrivalDetail.PrID;
                arrivalDetail.ArQuantity = regArrivalDetail.ArQuantity;

                db.Entry(arrivalDetail).State = EntityState.Modified;
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
                    Table = "ArrivalDetail",
                    Command = "Put",
                    //Data = ArrivalLogData(regArrival),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }

        // データ削除
        // in       Arrival : 削除する入荷ID
        public void DeleteArrival(int T_ArID)
        {
            T_Arrival arrival;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    arrival = db.T_Arrivals.Single(x => x.ArID == T_ArID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundArrival, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Arrivals.Remove(arrival);
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
                    Table = "Arrival",
                    Command = "Delete",
                    Data = arrival.ArID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }



    }
}
