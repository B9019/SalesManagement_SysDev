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

    }
}
