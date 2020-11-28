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
    class T_SyukkoContents
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
        public T_Syukko GetSyukko(int SyID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.T_Syukkos.Single(m => m.SyID == SyID);
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

        public IEnumerable<T_DispSyukko> GetDispSyukko()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<T_DispSyukko> dispSyukko = new List<T_DispSyukko>();
                foreach (T_Syukko syukko in db.T_Syukkos)
                {
                    string maker;
                    try
                    {
                        maker = (syukko.SyID != -1) ? db.T_Syukkos.Single(m => m.SyID == syukko.SyID).SyHidden : string.Empty;

                        // 無効表示
                        if (db.T_Syukkos.Single(m => m.SyID == syukko.SyID).SyFlag != 0) maker = "[" + syukko + "]";
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

                    dispSyukko.Add(new T_DispSyukko()
                    {
                        SyID = syukko.SyID,
                        SoID = syukko.SoID,
                        EmID = syukko.EmID,
                        ClID = syukko.ClID,
                        OrID = syukko.OrID,
                        SyDate = syukko.SyDate,
                        SyStateFlag = syukko.SyStateFlag,
                        SyFlag = syukko.SyFlag,
                        SyHidden = syukko.SyHidden
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<T_DispSyukko> sortableDispSyukko = new SortableBindingList<T_DispSyukko>(dispSyukko);
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

                return sortableDispSyukko;
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
        public string PostT_Syukko(T_Syukko regSyukko)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.T_Syukkos.Add(regSyukko);
                db1.Entry(regSyukko).State = EntityState.Added;
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
        public string PutSyukko(T_Syukko regSyukko)
        {
            using (var db = new SalesManagement_DevContext())
            {
                T_Syukko syukko
;
                try
                {
                    syukko = db.T_Syukkos.Single(x => x.SyID == regSyukko.SyID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                syukko.SyID = regSyukko.SyID;
                syukko.SoID = regSyukko.SoID;
                syukko.EmID = regSyukko.EmID;
                syukko.ClID = regSyukko.ClID;
                syukko.OrID = regSyukko.OrID;
                syukko.SyDate = regSyukko.SyDate;
                syukko.SyStateFlag = regSyukko.SyStateFlag;
                syukko.SyFlag = regSyukko.SyFlag;
                syukko.SyHidden = regSyukko.SyHidden;
                //Timestamp = item.Timestamp,
                //LogData = item.LogData,
                db.Entry(syukko).State = EntityState.Modified;
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
                    Table = "Syukko",
                    Command = "Syu",
                    //Data = ProductLogData(regChumon),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Product : 削除する商品ID
        public void DeleteSyukko(int T_SyID)
        {
            T_Syukko syukko;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    syukko = db.T_Syukkos.Single(x => x.SyID == T_SyID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundSyukko, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.T_Syukkos.Remove(syukko);
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
                    Table = "Syukko",
                    Command = "Delete",
                    Data = syukko.SyID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Division : ログ対象データ
        // out      string        : ログ文字列
        private string T_SyukkoLogData(T_Syukko regT_Syukko)
        {
            return regT_Syukko.SyID.ToString() + ", " +
            regT_Syukko.SoID.ToString() + ", " +
            regT_Syukko.EmID.ToString() + ", " +
            regT_Syukko.ClID.ToString() + ", " +
            regT_Syukko.OrID.ToString() + ", " +
            regT_Syukko.SyDate.ToString() + ", " +
            regT_Syukko.SyStateFlag.ToString() + ", " +
            regT_Syukko.SyFlag.ToString() + ", " +
            regT_Syukko.SyHidden;


        }
    }
}
