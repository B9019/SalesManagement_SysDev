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
    class T_HattyuContents
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
        // in  : hattyuID
        // out : hattyuデータ
        public T_Hattyu GetHattyu(int HaID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Hattyus.Single(m => m.HaID == HaID);
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

        public IEnumerable<T_DispHattyu> GetDispHattyus()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispHattyu> dispHattyus = new List<T_DispHattyu>();
                foreach (T_Hattyu hattyu in db.T_Hattyus)
                {
                    string maker;
                    try
                    {
                        maker = (hattyu.HaID != -1) ? db.T_Hattyus.Single(m => m.HaID == hattyu.HaID).HaHidden : string.Empty;

                        // 無効表示
                        if (db.T_Hattyus.Single(m => m.HaID == hattyu.HaID).HaFlag != 0) maker = "[" + maker + "]";
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

                    dispHattyus.Add(new T_DispHattyu()
                    {
                        HaID = hattyu.HaID,
                        MaID = hattyu.MaID,
                        EmID = hattyu.EmID,
                        HaDate = hattyu.HaDate,
                        Hamemo = hattyu.Hamemo,
                        HaHidden = hattyu.HaHidden,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispHattyu> sortableDispHattyu = new SortableBindingList<T_DispHattyu>(dispHattyus);

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

                return sortableDispHattyu;
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
        // in   : T_Hattyuデータ
        public string PostT_Hattyu(T_Hattyu regHattyu)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Hattyus.Add(regHattyu);
                db1.Entry(regHattyu).State = EntityState.Added;
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
        // in   : T_Hattyuデータ
        // out  : エラーメッセージ 
        public string PutHattyu(T_Hattyu regHattyu)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Hattyu hattyu;
                try
                {
                    hattyu = db.T_Hattyus.Single(x => x.HaID == regHattyu.HaID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                hattyu.HaID = regHattyu.HaID;
                hattyu.MaID = regHattyu.MaID;
                hattyu.EmID = regHattyu.EmID;
                hattyu.HaDate = regHattyu.HaDate;
                hattyu.Hamemo = regHattyu.Hamemo;
                hattyu.HaHidden = regHattyu.HaHidden;

                db.Entry(hattyu).State = EntityState.Modified;
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
                    Table = "Hattyu",
                    Command = "Put",
                    //Data = HattyuLogData(regHattyu),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Hattyu : 削除する発注ID
        public void DeleteHattyu(int T_HaID)
        {
            T_Hattyu hattyu;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    hattyu = db.T_Hattyus.Single(x => x.HaID == T_HaID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundHattyu, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Hattyus.Remove(hattyu);
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
                    Table = "Hattyu",
                    Command = "Delete",
                    Data = hattyu.HaID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }


    }
}
