using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Model.Entity
{
    // メッセージ表示用定数　＆　メッセージデータベース用エンティティ
    class Messages
    {
        // ***** モジュール実装

        // データベース処理
        // private CommonFunction _cm = new CommonFunction();

        // ***** メッセージ定義

        // 共通
        public const string necessaryInput = "必須項目です。";
        public const string nullNotAllowed = "空白は無効です。";

        //Product
        public const string errorNotFoundProduct = "商品情報が見つかりませんでした。";

        //Client
        public const string errorNotFoundClient = "顧客情報が見つかりませんでした。";

        //Stock
        public const string errorNotFoundStock = "在庫情報が見つかりませんでした。";
        //Employee
        public const string errorNotFoundEmployee = "社員情報が見つかりませんでした。";
        //Shipment
        public const string errorNotFoundShipment = "出荷情報が見つかりませんでした。";


        // ***** ContentsManagement
        public const string errorConflict = "更新の競合が報告されました。";



        public int MessagesId { get; set; }
        public int MessagesNo { get; set; }
        public string Message { get; set; }

    }
}
