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


namespace SalesManagement_SysDev
{
    class StaffContents
    {
        // ***** モジュール実装

        // データベース処理モジュール
        private readonly CommonFunction _cm = new CommonFunction();

        // データベース処理モジュール（メッセージ）
        private MessageCommon _msc = new MessageCommon();

        // ***** プロパティ定義

        // ログオンユーザー情報
        public string _logonUser;

        F_home f_home = new F_home();
        F_login f_login = new F_login();
        F_Arrival f_arrival = new F_Arrival();
        F_Chumon f_chumon = new F_Chumon();
        F_Client f_client = new F_Client();
        F_Employee f_employee = new F_Employee();
        F_Hattyu f_hattyu = new F_Hattyu();
        F_Order f_order = new F_Order();
        F_Product f_product = new F_Product();
        F_Sale f_sale = new F_Sale();
        F_Shipment f_shipment = new F_Shipment();
        F_Stock f_stock = new F_Stock();
        F_Syukko f_syukko = new F_Syukko();
        F_Warehousing f_warehousing = new F_Warehousing();

        // ***** メソッド定義

        public void ContloLock(int access,string form)
        {
            switch (access)
            {
                case 0:if(form == f_home)//営業
                    {

                    }
                    break;
                case 1:if()//物流

                    {

                    }
                    break;
                case 2:if()//本社
                    {

                    }
                    break;
                case 3:if()//顧客
                    {

                    }
                    break;
                case 4:if()//管理者
                    {

                    }
                    break;
                case 5:if()//一般管理者
                    {

                    }
                    break;
            }       

        }


    }
}
