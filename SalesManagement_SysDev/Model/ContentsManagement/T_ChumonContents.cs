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
    class T_ChumonContents
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
        public T_Chumon GetChumon(int ChID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Chumons.Single(m => m.ChID == ChID);
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

        public IEnumerable<T_DispChumon> GetDispChumon()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispChumon> dispChumon = new List<T_DispChumon>();
                foreach (T_Chumon chumon in db.T_Chumons)
                {
                    string maker;
                    try
                    {
                        maker = (chumon.ChID != -1) ? db.T_Chumons.Single(m => m.ChID == chumon.ChID).ChHidden : string.Empty;

                        // 無効表示
                        if (db.T_Chumons.Single(m => m.ChID == chumon.ChID).ChFlag != 0) maker = "[" + chumon + "]";
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

                    dispChumon.Add(new T_DispChumon()
                    {
                        ChID = chumon.ChID,
                        SoID = chumon.SoID,
                        EmID = chumon.EmID,
                        ClID = chumon.ClID,
                        OrID = chumon.OrID,
                        ChDate = chumon.ChDate,
                        ChStateFlag = chumon.ChStateFlag,
                        ChFlag = chumon.ChFlag,
                        ChHidden = chumon.ChHidden
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispChumon> sortableDispChumon = new SortableBindingList<T_DispChumon>(dispChumon);
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

                return sortableDispChumon;
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
        public string PostT_Chumon(T_Chumon regChumon)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Chumons.Add(regChumon);
                db1.Entry(regChumon).State = EntityState.Added;
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
        public string PutChumon(T_Chumon regChumon)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Chumon chumon;
                try
                {
                    chumon = db.T_Chumons.Single(x => x.ChID == regChumon.ChID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                chumon.ChID = regChumon.ChID;
                chumon.SoID = regChumon.SoID;
                chumon.EmID = regChumon.EmID;
                chumon.ClID = regChumon.ClID;
                chumon.OrID = regChumon.OrID;
                chumon.ChDate = regChumon.ChDate;
                chumon.ChStateFlag = regChumon.ChStateFlag;
                chumon.ChFlag = regChumon.ChFlag;
                chumon.ChHidden = regChumon.ChHidden;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(chumon).State = EntityState.Modified;
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
                    Table = "Chumon",
                    Command = "Chu",
                    //Data = ProductLogData(regChumon),
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Product : 削除する商品ID
        public void DeleteChumon(int T_ChID)
        {
            T_Chumon chumon;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    chumon = db.T_Chumons.Single(x => x.ChID == T_ChID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundProduct, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Chumons.Remove(chumon);
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
                    Table = "Chumon",
                    Command = "Delete",
                    Data = chumon.ChID.ToString(),
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_ChumonLogData(T_Chumon regT_Chumon)
        {
            return regT_Chumon.ChID.ToString() + ", " +
            regT_Chumon.SoID.ToString() + ", " +
            regT_Chumon.EmID.ToString() + ", " +
            regT_Chumon.ClID.ToString() + ", " +
            regT_Chumon.OrID.ToString() + ", " +
            regT_Chumon.ChDate.ToString() + ", " +
            regT_Chumon.ChStateFlag.ToString() + ", " +
            regT_Chumon.ChFlag.ToString() + ", " +
            regT_Chumon.ChHidden;


        }


    }
}

