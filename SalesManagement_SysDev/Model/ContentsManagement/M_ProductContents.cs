using SalesManagement_SysDev.Model.ContentsManagement.Common;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Model;
using SalesManagement_SysDev.Model.Entity;
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


        // データ追加
        // in   : M_Productデータ
        public string PostM_Product(M_Product regM_Product)
        {
            using (var db = new SalesManagement_DevContext())
            {
                db.M_Products.Add(regM_Product);
                db.Entry(regM_Product).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    // throw new Exception(Messages.errorConflict, ex);
                    // throw new Exception(_cm.GetMessage(100), ex);
                    // MessageBox.Show(_msc.GetMessage(100));
                    return _msc.GetMessage(100);
                }
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
