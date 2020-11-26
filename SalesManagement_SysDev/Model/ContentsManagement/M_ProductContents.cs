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
    class M_ProductContents
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
        public M_Product GetProduct(int PrID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.M_Products.Single(m => m.PrID == PrID);
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

        public IEnumerable<M_DispProduct> GetDispProducts()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<M_DispProduct> dispProducts = new List<M_DispProduct>();
                foreach (M_Product product in db.M_Products)
                {
                    string maker;
                    try
                    {
                        maker = (product.PrID != -1) ? db.M_Products.Single(m => m.MaID == product.PrID).PrName: string.Empty;

                        // 無効表示
                        if (db.M_Products.Single(m => m.PrID == product.PrID).PrFlag != 0) maker = "[" + maker + "]";
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

                    dispProducts.Add(new M_DispProduct()
                    {
                        PrID = product.PrID,
                        MaID = product.MaID,
                        PrName = product.PrName,
                        Price = product.Price,
                        PrJCode = product.PrJCode,
                        PrSafetyStock = product.PrSafetyStock,
                        ScID = product.ScID,
                        PrModelNumber = product.PrModelNumber,
                        PrColor = product.PrColor,
                        PrReleaseDate = product.PrReleaseDate,
                        PrFlag = product.PrFlag,
                        PrMemo = product.PrMemo,
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<M_DispProduct> sortableDispProduct = new SortableBindingList<M_DispProduct>(dispProducts);

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

                return sortableDispProduct;
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
        public string PostM_Product(M_Product regProduct)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.M_Products.Add(regProduct);
                db1.Entry(regProduct).State = EntityState.Added;
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
        // in   : M_Productデータ
        // out  : エラーメッセージ 
        public string PutProduct(M_Product regProduct)
        {
            using (var db = new SalesManagement_DevContext())
            {
                M_Product product;
                try
                {
                    product = db.M_Products.Single(x => x.PrID == regProduct.PrID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                product.PrID = regProduct.PrID;
                product.MaID = regProduct.MaID;
                product.PrName = regProduct.PrName;
                product.Price = regProduct.Price;
                product.PrJCode = regProduct.PrJCode;
                product.PrSafetyStock = regProduct.PrSafetyStock;
                product.ScID = regProduct.ScID;
                product.PrModelNumber = regProduct.PrModelNumber;
                product.PrColor = regProduct.PrColor;
                product.PrReleaseDate = regProduct.PrReleaseDate;
                product.PrFlag = regProduct.PrFlag;
                product.PrMemo = regProduct.PrMemo;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(product).State = EntityState.Modified;
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
                    Table = "Product",
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
        public void DeleteProduct(int M_PrID)
        {
            M_Product product;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    product = db.M_Products.Single(x => x.PrID == M_PrID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundProduct, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.M_Products.Remove(product);
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
                    Table = "Product",
                    Command = "Delete",
                    Data = product.PrID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string M_ProductLogData(M_Product regM_Product)
                {
                    return regM_Product.PrID.ToString() + ", " +
                    regM_Product.PrID.ToString() + ", " +
                    regM_Product.MaID.ToString() + ", " +
                    regM_Product.Price.ToString() + ", " +
                    regM_Product.PrSafetyStock.ToString() + ", " +
                    regM_Product.ScID.ToString() + ", " +
                    regM_Product.PrModelNumber.ToString() + ", " +
                    regM_Product.PrColor.ToString() + ", " +
                    regM_Product.PrReleaseDate.ToString() + ", " +
                    regM_Product.PrName + ", " +
                    regM_Product.PrJCode + ", " +
                    regM_Product.PrColor + ", " +

                    regM_Product.PrFlag.ToString() + ", " +
                    regM_Product.PrHidden;


                }
            
        
    }
}

