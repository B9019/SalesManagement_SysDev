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
    class T_WarehousingContents
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
        public T_Warehousing GetWarehousing(int WaID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Warehousings.Single(m => m.WaID == WaID);
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

        public IEnumerable<T_DispWarehousing> GetDispWarehousing()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispWarehousing> dispWarehousing = new List<T_DispWarehousing>();
                foreach (T_Warehousing warehousing in db.T_Warehousings)
                {
                    string maker;
                    try
                    {
                        maker = (warehousing.WaID != -1) ? db.T_Warehousings.Single(m => m.WaID == warehousing.WaID).WaHidden : string.Empty;

                        // 無効表示
                        if (db.T_Warehousings.Single(m => m.WaID == warehousing.WaID).WaFlag != 0) maker = "[" + warehousing + "]";
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

                    dispWarehousing.Add(new T_DispWarehousing()
                    {

                        WaID = warehousing.WaID,
                        HaID = warehousing.HaID,
                        EmID = warehousing.EmID,
                        WaDate = warehousing.WaDate,
                        WaShelfFlag = warehousing.WaShelfFlag,
                        WaFlag = warehousing.WaFlag,
                        WaHidden = warehousing.WaHidden
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispWarehousing> sortableDispWarehousing = new SortableBindingList<T_DispWarehousing>(dispWarehousing);
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

                return sortableDispWarehousing;
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
        public string PostT_Warehousing(T_Warehousing regWarehousing)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Warehousings.Add(regWarehousing);
                db1.Entry(regWarehousing).State = EntityState.Added;
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
        public string PutWarehousing(T_Warehousing regWarehousing)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Warehousing warehousing;
                try
                {
                    warehousing = db.T_Warehousings.Single(x => x.WaID == regWarehousing.WaID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                warehousing.WaID = regWarehousing.WaID;
                warehousing.HaID = regWarehousing.HaID;
                warehousing.EmID = regWarehousing.EmID;
                warehousing.WaDate = regWarehousing.WaDate;
                warehousing.WaShelfFlag = regWarehousing.WaShelfFlag;
                warehousing.WaFlag = regWarehousing.WaFlag;
                warehousing.WaHidden = regWarehousing.WaHidden;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(warehousing).State = EntityState.Modified;
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
                    Table = "Warehousing",
                    Command = "War",
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Product : 削除する商品ID
        public void DeleteWarehousing(int T_WaID)
        {
            T_Warehousing warehousing;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    warehousing = db.T_Warehousings.Single(x => x.WaID == T_WaID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundWarehousing, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Warehousings.Remove(warehousing);
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
                    Table = "Warehousing",
                    Command = "Delete",
                    Data = warehousing.WaID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_WarehousingLogData(T_Warehousing regT_Warehousing)
        {
            return regT_Warehousing.WaID.ToString() + ", " +
            regT_Warehousing.HaID.ToString() + ", " +
            regT_Warehousing.EmID.ToString() + ", " +
            regT_Warehousing.WaDate.ToString() + ", " +
            regT_Warehousing.WaShelfFlag.ToString() + ", " +
            regT_Warehousing.WaFlag.ToString() + ", " +
            regT_Warehousing.WaHidden;


        }
    }
}
