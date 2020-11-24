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
    class M_ClientContents
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
        public M_Client GetClient(int ClID)
        {
            try
            {
                using (var db = new SalesManagement_DevContext()) return db.M_Clients.Single(m => m.ClID == ClID);
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

        public IEnumerable<M_DispClient> GetDispClients()
        {
            using (var db = new SalesManagement_DevContext())
            {
                List<M_DispClient> dispClients = new List<M_DispClient>();
                foreach (M_Client client in db.M_Clients)
                {
                    string maker;
                    try
                    {
                        maker = (client.ClID != -1) ? db.M_Clients.Single(m => m.ClID == client.ClID).ClName : string.Empty;

                        // 無効表示
                        if (db.M_Clients.Single(m => m.ClID == client.ClID).ClFlag != 0) maker = "[" + maker + "]";
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

                    dispClients.Add(new M_DispClient()
                    {
                        ClID = client.ClID,
                        SoID = client.SoID,
                        ClName = client.ClName,
                        ClAddress = client.ClAddress,
                        ClPhone = client.ClPhone,
                        ClPostal = client.ClPostal,
                        ClFAX = client.ClFAX,
                        ClFlag = client.ClFlag,
                        ClHidden = client.ClHidden,
                        //Timestamp = item.Timestamp,
                        //LogData = item.LogData,
                    });
                }
                // ソータブルリスト作成
                SortableBindingList<M_DispClient> sortableDispClient = new SortableBindingList<M_DispClient>(dispClients);

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

                return sortableDispClient;
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
        public string PostM_Client(M_Client regClient)
        {
            using (var db1 = new SalesManagement_DevContext())
            {
                db1.M_Clients.Add(regClient);
                db1.Entry(regClient).State = EntityState.Added;
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
        // in   : M_Clientデータ
        // out  : エラーメッセージ 
        public string PutClient(M_Client regClient)
        {
            using (var db = new SalesManagement_DevContext())
            {
                M_Client client;
                try
                {
                    client = db.M_Clients.Single(x => x.ClID == regClient.ClID);
                }
                catch
                {
                    // throw new Exception(Messages.errorNotFoundItem, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                    return _msc.GetMessage(110);
                }
                client.ClID = regClient.ClID;
                client.SoID = regClient.SoID;
                client.ClName = regClient.ClName;
                client.ClAddress = regClient.ClAddress;
                client.ClPhone = regClient.ClPhone;
                client.ClPostal = regClient.ClPostal;
                client.ClFAX = regClient.ClFAX;
                client.ClFlag = regClient.ClFlag;
                client.ClHidden = regClient.ClHidden;

                db.Entry(client).State = EntityState.Modified;
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
                    Table = "Client",
                    Command = "Put",
                    //Data = ProductLogData(regClient),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);

                return string.Empty;
            }
        }
        // データ削除
        // in       Client : 削除する商品ID
        public void DeleteClient(int M_ClID)
        {
            M_Client client;
            using (var db = new SalesManagement_DevContext())
            {
                try
                {
                    client = db.M_Clients.Single(x => x.ClID == M_ClID);
                }
                catch (Exception ex)
                {
                    throw new Exception(Messages.errorNotFoundClient, ex);
                    // throw new Exception(_cm.GetMessage(110), ex);
                }
                db.M_Clients.Remove(client);
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
                    Table = "Client",
                    Command = "Delete",
                    Data = client.ClID.ToString(),
                    Comments = string.Empty
                };
                //StaticCommon.PostOperationLog(operationLog);
            }
        }




        // ログデータ作成
        // in       regM_Client : ログ対象データ
        // out      string        : ログ文字列
        private string M_ClientLogData(M_Client regM_Client)
        {
            return regM_Client.ClID.ToString() + ", " +
            regM_Client.SoID.ToString() + ", " +
            regM_Client.ClName + ", " +
            regM_Client.ClAddress + ", " +
            regM_Client.ClPhone + ", " +
            regM_Client.ClPostal.ToString() + ", " +
            regM_Client.ClFAX + ", " +
            regM_Client.ClFlag.ToString() + ", " +
            regM_Client.ClHidden ;



        }



    }
}
