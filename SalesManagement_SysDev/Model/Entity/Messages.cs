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

        public int MessagesId { get; set; }
        public int MessagesNo { get; set; }
        public string Message { get; set; }

    }
}
