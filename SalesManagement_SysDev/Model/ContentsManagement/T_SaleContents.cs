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
    class T_SaleContents
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
        // in  : SaID
        // out : SaIDデータ
        public T_Sale GetClient(int SaID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Sales.Single(m => m.SaID == SaID);
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

        public IEnumerable<T_DispSale> GetDispSales()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispSale> dispSales = new List<T_DispSale>();
                foreach (T_Sale sale in db.T_Sales)
                {
                    string maker;
                    try
                    {
                        maker = (sale.SaID != -1) ? db.T_Sales.Single(m => m.SaID == sale.SaID).Samemo : string.Empty;

                        // 無効表示
                        if (db.T_Sales.Single(m => m.SaID == sale.SaID).SaFlag != 0) maker = "[" + maker + "]";
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

                    dispSales.Add(new T_DispSale()
                    {
                        SaID = sale.SaID,
                        ClID = sale.ClID,
                        SoID = sale.SoID,
                        EmID = sale.EmID,
                        OrID = sale.OrID,
                        SaDate = sale.SaDate,
                        SaFlag = sale.SaFlag,
                        SaHidden = sale.SaHidden,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispSale> sortableDispSale = new SortableBindingList<T_DispSale>(dispSales);

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

                return sortableDispSale;
            }
        }
        // データ追加
        // in   : T_Saleデータ
        public string PostT_Sale(T_Sale regSale)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Sales.Add(regSale);
                db1.Entry(regSale).State = EntityState.Added;
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
        // in   : T_Saleデータ
        // out  : エラーメッセージ 
        public string PutSale(T_Sale regSale)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Sale sale;
                try
                {
                    sale = db.T_Sales.Single(x => x.SaID == regSale.SaID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                sale.SaID = regSale.SaID;
                sale.ClID = regSale.ClID;
                sale.SoID = regSale.SoID;
                sale.EmID = regSale.EmID;
                sale.OrID = regSale.OrID;
                sale.SaDate = regSale.SaDate;
                sale.SaFlag = regSale.SaFlag;
                sale.SaHidden = regSale.SaHidden;

                db.Entry(sale).State = EntityState.Modified;
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
                    Table = "Sale",
                    Command = "Put",
                    //Data = ProductLogData(regClient),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Sale : 削除する売上ID
        public void DeleteSale(int T_SaID)
        {
            T_Sale sale;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    sale = db.T_Sales.Single(x => x.SaID == T_SaID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSale, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Sales.Remove(sale);
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
                    Table = "Sale",
                    Command = "Delete",
                    Data = sale.SaID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }



    }
}
