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
    class T_StockContents
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
        public T_Stock GetStock(int StID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Stocks.Single(m => m.StID == StID);
            }
            catch
            {
                return null;

            }
        }
        // 表示データ取得（始点・終点指定）
        // in   startRec : 配列抜出の始点
        //      endRec   : 配列抜出の終点


        public IEnumerable<T_DispStock> GetDispStock()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispStock> dispStock = new List<T_DispStock>();
                //foreach (T_Stock stock in db.T_Stocks)
                //{
                //    string maker;
                //    try
                //    {
                //        maker = (stock.StID != -1) ? db.T_Stocks.Single(m => m.StID == stock.StID).ChHidden : string.Empty;

                //        // 無効表示
                //        if (db.T_Stocks.Single(m => m.StID == stock.StID).StFlag != 0) maker = "[" + stock + "]";
                //    }
                //    catch
                //    {
                //        maker = string.Empty;
                //    }



                //    dispStock.Add(new T_DispStock()
                //    {
                //        StID = stock.StID,
                //        PrID = stock.PrID,
                //        StQuantity = stock.StQuantity,
                //        StFlag = stock.StFlag
                //        //Timestamp = item.Timestamp,
                //        //LogData = item.LogData,
                //    });
                //}
                // ソータブルリスト作成
                SortableBindingList<T_DispStock> sortableDispStock = new SortableBindingList<T_DispStock>(dispStock);
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

                return sortableDispStock;
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
        public string PostT_Stock(T_Stock regStock)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Stocks.Add(regStock);
                db1.Entry(regStock).State = EntityState.Added;
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
        // in   : M_Chumonデータ
        // out  : エラーメッセージ 
        public string PutStock(T_Stock regStock)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Stock stock;
                try
                {
                    stock = db.T_Stocks.Single(x => x.StID == regStock.StID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                stock.StID = regStock.StID;
                stock.PrID = regStock.PrID;
                stock.StQuantity = regStock.StQuantity;
                stock.StFlag = regStock.StFlag;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(stock).State = EntityState.Modified;
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
                    Table = "Stock",
                    Command = "Sto",
                    //Data = ProductLogData(regStock),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ更新(注文)
        // in   : M_Chumonデータ
        // out  : エラーメッセージ 
        public string PutStockCh(T_Stock regStock)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Stock stock;
                try
                {
                    stock = db.T_Stocks.Single(x => x.StID == regStock.StID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                stock.StID = regStock.StID;
                stock.PrID = regStock.PrID;
                stock.StQuantity = regStock.StQuantity;
                stock.StFlag = regStock.StFlag;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(stock).State = EntityState.Modified;
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
                    Table = "Stock",
                    Command = "Sto",
                    //Data = ProductLogData(regStock),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Stock : 削除する商品ID
        public void DeleteStock(int T_StID)
        {
            T_Stock stock;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    stock = db.T_Stocks.Single(x => x.StID == T_StID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundStock, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Stocks.Remove(stock);
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
                    Table = "Stock",
                    Command = "Delete",
                    Data = stock.StID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_StockLogData(T_Stock regT_Stock)
        {
            return regT_Stock.StID.ToString() + ", " +
            regT_Stock.PrID.ToString() + ", " +
            regT_Stock.StQuantity.ToString() + ", " +
            regT_Stock.StFlag.ToString() + ", ";


        }

    }
}


    

