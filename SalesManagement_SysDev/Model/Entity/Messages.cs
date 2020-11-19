using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity
{
    // メッセージ表示用定数　＆　メッセージデータベース用エンティティ
    public class Messages
    {
        // ***** モジュール実装

        // データベース処理
        // private CommonFunction _cm = new CommonFunction();

        // ***** メッセージ定義

        // ページング
        public const string pagingFirstPage = "ファーストページです!";
        public const string pagingLastPage = "ラストページです!";

        // 共通
        public const string necessaryInput = "必須項目です。";
        public const string nullNotAllowed = "空白は無効です。";

        // Sale
        public const string registStaff = "販売担当者を登録して下さい。";
        public const string registShop = "販売店舗を登録して下さい。";
        public const string registItem = "商品を登録して下さい。";
        public const string selectItem = "商品を選択して下さい。";
        public const string registTax = "消費税を登録して下さい。";
        public const string selectTax = "消費税を選択して下さい。";
        public const string recordLock = "ロックデータのため編集できません。";
        public const string logDirectoryHead = "ログファイルを[";
        public const string logDirectoryTail = "]に作成します。場所を変更するにはコントロールパネルで設定して下さい。";

        // Stock
        public const string notFoundItem = "削除する商品がありません。";
        public const string selectInputMode = "処理モード（入庫/出庫/移動）を選択して下さい。";
        public const string moveItem = "移動元の商品個数が足りません。";
        public const string issueEnd = "処理終了";
        public const string issuedNothing = "処理する商品はありません。";

        // Order
        public const string foundOrderingItem = "発注要求商品が有ります。";
        public const string notFoundOrderingItem = "発注要求商品が有りません。";
        public const string receivingOrderingItem = "発注品を入庫しました。";
        public const string cannotReceivingOrderingItem = "入庫数が発注個数を上回るため入庫できません。";
        public const string cancelReceiving = "発注品の入庫をキャンセルしました。";
        public const string receivingPartialOrderingItem = "部分入庫処理を実行しました。";
        public const string registSupplier = "サプライヤーを登録して下さい。";
        public const string selectSupplier = "サプライヤーを選択して下さい。";

        // Item
        public const string registMaker = "メーカーを登録して下さい。";
        public const string selectMaker = "メーカーを選択して下さい。";
        public const string registCategory = "カテゴリーを登録して下さい。";
        public const string selectCategory = "カテゴリーを選択して下さい。";

        // Sale & Item
        public const string registUnit = "単位を登録して下さい。";
        public const string selectUnit = "単位を選択して下さい。";

        // Category
        public const string ranklimit = "これ以上階層を深くできません。";
        public const string ctDuplication = "このカテゴリー名は既に使用されています。";

        // Shop
        public const string shopRegistStaff = "従業員を登録して下さい。";
        public const string shopSelectStaff = "従業員（店舗責任者）を選択して下さい。";

        // Staff
        public const string staffRegistShop = "店舗を登録して下さい。";
        public const string staffSelectShop = "店舗（所属店舗）を選択して下さい。";
        public const string registDivision = "部署を登録して下さい。";
        public const string selectDivision = "部署（所属部署）を選択して下さい。";
        public const string selectAccessAuth = "アクセス権を選択して下さい。";
        public const string stDuplication = "このユーザー名は既に使用されています。";

        // Control Panel
        public const string locked = "ロックしました。";
        public const string unLocked = "ロック解除しました。";
        public const string faleSet = "終了位置は開始位置より後ろでなくてはなりません。";

        // Salt
        public const string saltSave = "保存しました。";

        // Log
        public const string logSwitching = "ログファイルが満杯になりましたので切り替えます。";

        // ***** ContentsManagement
        public const string errorConflict = "更新の競合が報告されました。";

        public const string errorNotFoundCategory = "カテゴリー情報が見つかりませんでした。";
        public const string errorNotFoundCounter = "カウンターが見つかりませんでした。";
        public const string errorNotFoundControlPanel = "ControlPanelデータが見つかりませんでした。";
        public const string errorNotFoundCryptographicKey = "暗号化キーが見つかりませんでした。";
        public const string errorNotFoundSalt = "Saltが見つかりませんでした。";
        public const string errorNotFoundLog = "ログが見つかりませんでした。";
        public const string errorNotFoundColumn = "項目情報が見つかりませんでした。";
        public const string errorNotFoundAggregation = "集計情報が見つかりませんでした。";
        public const string errorNotFoundDivision = "部署情報が見つかりませんでした。";
        public const string errorNotFoundPosition = "役職情報が見つかりませんでした。";
        public const string errorNotFoundItem = "商品情報が見つかりませんでした。";
        public const string errorNotFoundMaker = "メーカー情報が見つかりませんでした。";
        public const string errorNotFoundSale = "売上情報が見つかりませんでした。";
        public const string errorNotFoundShop = "店舗情報が見つかりませんでした。";
        public const string errorNotFoundStaff = "従業員情報が見つかりませんでした。";
        public const string errorNotFoundTax = "消費税情報が見つかりませんでした。";
        public const string errorNotFoundUnit = "受発注単位情報が見つかりませんでした。";
        public const string errorNotFoundSupplier = "サプライヤー情報が見つかりませんでした。";
        public const string errorNotFoundStock = "在庫情報が見つかりませんでした。";
        public const string errorNotFoundStockList = "在庫リスト情報が見つかりませんでした。";
        public const string errorNotFoundStockDetail = "在庫詳細情報が見つかりませんでした。";
        public const string errorNotFoundOrder = "発注情報が見つかりませんでした。";
        public const string errorNotFoundInventirt = "棚卸情報が見つかりませんでした。";
        public const string errorNotFoundVender = "仕入先情報が見つかりませんでした。";
        public const string errorNotFoundPurchase = "仕入先情報が見つかりませんでした。";

        public int MessagesId { get; set; }
        public int MessagesNo { get; set; }
        public string Message { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }

        // メッセージ作成（Message）
        public IEnumerable<Messages> GenerateMessage()
        {
            List<Messages> messages = new List<Messages>();
            Messages message;

            // ページング
            message = new Messages { MessagesNo = 1, Message = pagingFirstPage }; messages.Add(message);
            message = new Messages { MessagesNo = 2, Message = pagingLastPage }; messages.Add(message);

            // 共通
            message = new Messages { MessagesNo = 10, Message = necessaryInput }; messages.Add(message);

            // Sale
            message = new Messages { MessagesNo = 20, Message = registStaff }; messages.Add(message);
            message = new Messages { MessagesNo = 21, Message = registShop }; messages.Add(message);
            message = new Messages { MessagesNo = 22, Message = registItem }; messages.Add(message);
            message = new Messages { MessagesNo = 23, Message = selectItem }; messages.Add(message);
            message = new Messages { MessagesNo = 24, Message = registTax }; messages.Add(message);
            message = new Messages { MessagesNo = 25, Message = selectTax }; messages.Add(message);
            message = new Messages { MessagesNo = 26, Message = recordLock }; messages.Add(message);
            message = new Messages { MessagesNo = 27, Message = logDirectoryHead }; messages.Add(message);
            message = new Messages { MessagesNo = 28, Message = logDirectoryTail }; messages.Add(message);

            // Stock
            message = new Messages { MessagesNo = 201, Message = notFoundItem }; messages.Add(message);
            message = new Messages { MessagesNo = 202, Message = selectInputMode }; messages.Add(message);
            message = new Messages { MessagesNo = 203, Message = moveItem }; messages.Add(message);
            message = new Messages { MessagesNo = 204, Message = issueEnd }; messages.Add(message);
            message = new Messages { MessagesNo = 205, Message = issuedNothing }; messages.Add(message);

            // Order
            message = new Messages { MessagesNo = 301, Message = foundOrderingItem }; messages.Add(message);
            message = new Messages { MessagesNo = 302, Message = notFoundOrderingItem }; messages.Add(message);
            message = new Messages { MessagesNo = 303, Message = receivingOrderingItem }; messages.Add(message);
            message = new Messages { MessagesNo = 304, Message = cannotReceivingOrderingItem }; messages.Add(message);
            message = new Messages { MessagesNo = 305, Message = cancelReceiving }; messages.Add(message);
            message = new Messages { MessagesNo = 306, Message = receivingPartialOrderingItem }; messages.Add(message);
            message = new Messages { MessagesNo = 307, Message = registSupplier }; messages.Add(message);
            message = new Messages { MessagesNo = 308, Message = selectSupplier }; messages.Add(message);

            // Item
            message = new Messages { MessagesNo = 30, Message = registMaker }; messages.Add(message);
            message = new Messages { MessagesNo = 31, Message = selectMaker }; messages.Add(message);
            message = new Messages { MessagesNo = 32, Message = registCategory }; messages.Add(message);
            message = new Messages { MessagesNo = 33, Message = selectCategory }; messages.Add(message);

            // Sale & Item
            message = new Messages { MessagesNo = 40, Message = registUnit }; messages.Add(message);
            message = new Messages { MessagesNo = 41, Message = selectUnit }; messages.Add(message);

            // Category
            message = new Messages { MessagesNo = 50, Message = ranklimit }; messages.Add(message);
            message = new Messages { MessagesNo = 51, Message = ctDuplication }; messages.Add(message);

            // Shop
            message = new Messages { MessagesNo = 60, Message = shopRegistStaff }; messages.Add(message);
            message = new Messages { MessagesNo = 61, Message = shopSelectStaff }; messages.Add(message);

            // Staff
            message = new Messages { MessagesNo = 70, Message = staffRegistShop }; messages.Add(message);
            message = new Messages { MessagesNo = 71, Message = staffSelectShop }; messages.Add(message);
            message = new Messages { MessagesNo = 72, Message = registDivision }; messages.Add(message);
            message = new Messages { MessagesNo = 73, Message = selectDivision }; messages.Add(message);
            message = new Messages { MessagesNo = 74, Message = selectAccessAuth }; messages.Add(message);
            message = new Messages { MessagesNo = 75, Message = stDuplication }; messages.Add(message);

            // Control Panel
            message = new Messages { MessagesNo = 80, Message = locked }; messages.Add(message);
            message = new Messages { MessagesNo = 81, Message = unLocked }; messages.Add(message);
            message = new Messages { MessagesNo = 82, Message = faleSet }; messages.Add(message);

            // Salt
            message = new Messages { MessagesNo = 90, Message = saltSave }; messages.Add(message);

            // Log
            message = new Messages { MessagesNo = 95, Message = logSwitching }; messages.Add(message);

            // ***** ContentsManagement
            message = new Messages { MessagesNo = 100, Message = errorConflict }; messages.Add(message);

            message = new Messages { MessagesNo = 101, Message = errorNotFoundCategory }; messages.Add(message);
            message = new Messages { MessagesNo = 102, Message = errorNotFoundCounter }; messages.Add(message);
            message = new Messages { MessagesNo = 103, Message = errorNotFoundControlPanel }; messages.Add(message);
            message = new Messages { MessagesNo = 104, Message = errorNotFoundCryptographicKey }; messages.Add(message);
            message = new Messages { MessagesNo = 105, Message = errorNotFoundSalt }; messages.Add(message);
            message = new Messages { MessagesNo = 106, Message = errorNotFoundLog }; messages.Add(message);
            message = new Messages { MessagesNo = 107, Message = errorNotFoundColumn }; messages.Add(message);
            message = new Messages { MessagesNo = 108, Message = errorNotFoundAggregation }; messages.Add(message);
            message = new Messages { MessagesNo = 109, Message = errorNotFoundDivision }; messages.Add(message);
            message = new Messages { MessagesNo = 110, Message = errorNotFoundItem }; messages.Add(message);
            message = new Messages { MessagesNo = 111, Message = errorNotFoundMaker }; messages.Add(message);
            message = new Messages { MessagesNo = 112, Message = errorNotFoundSale }; messages.Add(message);
            message = new Messages { MessagesNo = 113, Message = errorNotFoundShop }; messages.Add(message);
            message = new Messages { MessagesNo = 114, Message = errorNotFoundStaff }; messages.Add(message);
            message = new Messages { MessagesNo = 115, Message = errorNotFoundTax }; messages.Add(message);
            message = new Messages { MessagesNo = 116, Message = errorNotFoundUnit }; messages.Add(message);
            message = new Messages { MessagesNo = 117, Message = errorNotFoundSupplier }; messages.Add(message);
            message = new Messages { MessagesNo = 118, Message = errorNotFoundStock }; messages.Add(message);
            message = new Messages { MessagesNo = 119, Message = errorNotFoundStockList }; messages.Add(message);
            message = new Messages { MessagesNo = 120, Message = errorNotFoundStockDetail }; messages.Add(message);
            message = new Messages { MessagesNo = 121, Message = errorNotFoundOrder }; messages.Add(message);

            return messages;
        }
    }
}
