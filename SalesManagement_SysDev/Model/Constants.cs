namespace SalesManagement_SysDev.Model
{
    class Constants
    {
        // Microsoft SQL Server DateTime型初期値
        public const string sqlServerInitialDate = "1973/01/01 0:00:00";

        // アクセス権
        public const int numSales = 0;
        public const int numlogiManager = 1;
        public const int numOffice = 2;
        public const int numClient = 3;
        public const int numManager = 4;
        public const int numMaster = 5;

        public const string strSales = "営業";
        public const string strlogiManager = "物流";
        public const string strOffice = "本社";
        public const string strClient = "顧客";
        public const string strManager = "管理者";
        public const string strMaster = "特権管理者";


        //// メニューコントロール定数定義
        //public const int salesMenu = 0x01;
        //public const int stockMenu = 0x02;
        //public const int orderMenu = 0x04;
        //public const int aggregationMenu = 0x08;
        //public const int masterMenu = 0x10;
        //public const int systemMenu = 0x11;
        //public const int importMenu = 0x12;

        //// コードカウンター管理定数
        //public const int shopCode = 0;
        //public const int divisionCode = 1;
        //public const int positionCode = 2;
        //public const int staffCode = 3;
        //public const int categoryCode = 4;
        //public const int makerCode = 5;
        //public const int taxCode = 6;
        //public const int unitCode = 7;
        //public const int itemCode = 8;
        //public const int supplierCode = 9;

        //public const int columnsManagementCode = 10;
        //public const int logCount = 11;

        //public const int saleNo = 12;
        //public const int saleDetailNo = 13;
        //public const int stockNo = 14;
        //public const int stockListNo = 15;
        //public const int orderNo = 16;
        //public const int orderDetailNo = 17;

        //public const int transactionNo = 18;
        //public const int messagesNo = 19;
        //public const int codeCounts = 20;

        //// コードカウンター最大値定義
        //public const long codeMax = 100000;                         // １データベース最大データ数
        //public const long categoryMax = 10000000000000000;

        //// Entity:下記と対（データベース管理定数）
        //public const int numShop = 0;
        //public const int numDivision = 1;
        //public const int numPosition = 2;
        //public const int numStaff = 3;
        //public const int numCategory = 4;
        //public const int numMaker = 5;
        //public const int numTax = 6;
        //public const int numUnit = 7;
        //public const int numItem = 8;
        //public const int numSupplier = 9;
        //public const int numVender = 9;

        //public const int numColumnsManagement = 10;

        //public const int numSale = 11;

        //public const int numStock = 12;

        //public const int numOrder = 13;

        //public const int numAggregation = 14;

        //public const int numOrdering = 15;

        //public const int numSaleDetail = 16;
        //public const int numStockList = 17;
        //public const int numOrderDetail = 18;



        //public const int numLog = 19;

        //// Entity:上記と対（データベース名）
        //public const string strShop = "店舗";
        //public const string strDivision = "部署";
        //public const string strPosition = "役職";
        //public const string strStaff = "従業員";
        //public const string strCategory = "カテゴリー";
        //public const string strMaker = "メーカー";
        //public const string strTax = "消費税";
        //public const string strUnit = "受発注単位";
        //public const string strItem = "商品";
        //public const string strSupplier = "サプライヤー";

        //public const string strColumnsManagement = "項目管理";

        //public const string strSale = "売上";
        //public const string strStock = "在庫";
        //public const string strOrder = "発注";

        //public const string strAggregation = "集計";

        //public const string strOrdering = "発注明細";

        //public const string strSaleDetail = "売上明細";
        //public const string strStockList = "在庫リスト";
        //public const string strOrderDetail = "発注明細";

        //public const string strTransaction = "トランザクション";
        //public const string strMessages = "メッセージ";

        //public const string strLog = "ログ";

        //// Hash化関係
        //public const int saltSize = 24;
        //public const int pbkdf2Iteration = 10000;

        //// 印刷
        //public const int leftTopX = 10;               // 表左上X座標
        //public const int leftTopY = 100;              // 表左上Y座標
        //public const int strMarginX = 1;              // データ文字と罫線左のマージン
        //public const int strMarginY = 3;              // データ文字と罫線上のマージン
        //public const int defaultColumnLength = 100;   // 項目ボックス長さ
        //public const int defaultColumnHeight = 20;    // 項目ボックス高さ
        //public const int defaultLineHeight = 20;    　// 項目ボックス高さ
        //public const int titleX = 250;                // タイトル表示X座標
        //public const int titleY = 20;                 // タイトル表示Y座標
        //public const int pageX = 800;                 // ページ表示X座標
        //public const int correctionPageX = 100;                 // ページ表示X座標
        //public const int pageY = 10;                  // ページ表示Y座標
        //public const int pageSizePrinting = 20;       // １ページ行数

        //// 発注書
        //public const int orderingMarginleft = 30;     // マージンX座標
        //public const int headerCounts = 100;          // 項目数
        //public const int orderingWidth = 800;         // 発注書幅
        //public const int orderingHeight = 1000;       // 発注書高

        //// ***** ラベル


        //// ステータス
        //public const string strStatus0 = "有効";
        //public const string strStatus1 = "変更1";
        //public const string strStatus2 = "変更2";
        //public const string strStatus3 = "変更3";
        //public const string strStatus4 = "変更4";
        //public const string strStatus5 = "変更5";
        //public const string strStatus6 = "変更6";
        //public const string strStatus7 = "変更7";
        //public const string strStatus8 = "変更8";
        //public const string strStatus9 = "変更9";
        //public const string vfalse = "0";
        //public const string vtrue = "1";


        //// 項目表示管理
        //public const int numDisplay = 0;
        //public const int numPrint = 1;
        //public const string strDisplay = "表示";
        //public const string strPrint = "印刷";
        //public const int numStanderd = 0;
        //public const int numBold = 1;
        //public const string strStanderd = "標準";
        //public const string strBold = "太字";
        //public const string strInVisible = "非表示";
        //public const string strWrap = "ラップ";
        //public const string strLayoutLeft = "左寄せ";
        //public const string strLayoutRight = "右寄せ";
        //public const string strLayoutCenter = "センター";


        //// 背景色
        //public const string clrWhite = "白";
        //public const string clrIvory = "アイボリー";
        //public const string clrLightYellow = "明黄";
        //public const string clrLightGray = "明灰";
        //public const string clrLightPink = "明ピンク";
        //public const string clrLightBlue = "明青";
        //public const string clrAquamarine = "アクアマリン";
        //public const string clrLightSkyBlue = "明スカイブルー";
        //public const string clrSkyBlue = "スカイブルー";
        //public const string clrPaleGreen = "ペールグリーン";
        //public const string clrLightSalmon = "明サーモン";
        //public const string clrLightGreen = "明緑";

        //// 文字色
        //public const string clrBlack = "黒";
        //public const string clrPink = "ピンク";
        //public const string clrViolet = "紫";
        //public const string clrSilver = "銀";
        //public const string clrYellow = "黄";
        //public const string clrGold = "金";
        //public const string clrOrange = "オレンジ";
        //public const string clrGray = "灰";
        //public const string clrOlive = "オリーブ";
        //public const string clrPurple = "パープル";
        //public const string clrBlue = "青";
        //public const string clrLime = "ライム";
        //public const string clrRed = "赤";
        //public const string clrBrown = "茶";
        //public const string clrMaroon = "栗";
        //public const string clrNavy = "ネイビー";
        //public const string clrGreen = "緑";
        //public const string clrDarkGreen = "濃緑";

        //// フォント
        //public const string fontSystem = "システムフォント";
        //public const string fontMsGothic = "ＭＳ ゴシック";
        //public const string fontMsMincho = "ＭＳ 明朝";
        //public const string fontMspGothic = "ＭＳ Ｐゴシック";
        //public const string fontMspMincho = "ＭＳ Ｐ明朝";
        //public const string fontMeirio = "メイリオ";
        //public const string fontSansSerif = "sans-serif";
        //public const string fontArial = "arial";
        //public const string fontCenturyGothic = "Century Gothic";
        //public const string fontSerif = "serif";

        //// ロギング関係
        //public const int numGetAll = 0;
        //public const int numGet = 1;
        //public const int numPost = 2;
        //public const int numPut = 3;
        //public const int numDelete = 4;
        //public const string strGetAll = "GetAll";
        //public const string strGet = "Get";
        //public const string strPost = "Post";
        //public const string strPut = "Put";
        //public const string strDelete = "Delete";

        //public const string defaultPath = @"\log";
        //public const string defaultFileHead = @"\log";
        //public const string defaultFileExtent = ".txt";
        //public const int pageSizeLogging = 1000;

        //// カテゴリー
        //public const string topPath = "トップ";

        //// ボタンラベル
        //public const string lblSelectReturn = "選択決定";
        //public const string lblClose = "画面を閉じる";

        //// 集計
        //public const string modeDay = "日単位";
        //public const string modeMonth = "月単位";
        //public const string mode3Month = "３ヶ月単位";
        //public const string modeYear = "年単位";

        //// 売上
        //public const int numUnlock = 0;
        //public const int numLock = 1;
        //public const int numStockUnManaged = 0;
        //public const int numStockManaged = 1;
        //public const int numNewSales = 0;
        //public const int numNewOrders = 0;
        //public const int numAddDetail = 1;
        //public const string infoUnlock = "未ロック";
        //public const string infoLock = "ロック済";
        //public const string infoStockUnManaged = "在庫未処理";
        //public const string infoStockManaged = "在庫処理済";
        //public const string newSales = "新規売上";
        //public const string newOrders = "新規発注";
        //public const string addDetail = "明細追加";

        //// 在庫
        //public const int numReceiving = 0;
        //public const int numIssuing = 1;
        //public const int numMoving = 2;
        //public const int numInventoryReceiving = 3;
        //public const int numInventoryIssuing = 4;
        //public const string actionReceiving = "入庫";
        //public const string actionIssuing = "出庫";
        //public const string actionMoving = "移動";
        //public const string actionInventoryReceiving = "棚卸入庫";
        //public const string actionInventoryIssuing = "棚卸出庫";

        //// 発注
        //public const int numHanging = 0;
        //public const int numStored = 1;
        //public const string infoHanging = "発注掛";
        //public const string infoStored = "納品済";

        //// 発注伝票

        //// 発注書タイトル
        //public const int numOrderTitleX = 250;
        //public const int numOrderTitleY = -50;

        //// 発注番号
        //public const int numOrderNoX = 600;
        //public const int numOrderNoY = 30;

        //// 支払条件
        //public const int numPaymentTermsX = 100;
        //public const int numPaymentTermsY = 170;

        //// 件名
        //public const int numOrderNameX = 100;
        //public const int numOrderNameY = 130;

        //// 発注先
        //public const int numSupplierX = 100;
        //public const int numSupplierY = 50;

        //// 納期
        //public const int numDeliveryDateTimeNoX = 100;
        //public const int numDeliveryDateTimeNoY = 150;

        //// 発注日
        //public const int numOrderDateTimeNoX = 600;
        //public const int numOrderDateTimeNoY = 50;

        //// 発注担当者
        //public const int numPersonInChargeX = 600;
        //public const int numPersonInChargeY = 230;

        //// 納入店舗
        //public const int numDeliveredShopX = 100;
        //public const int numDeliveredShopY = 210;

        //// 発注者
        //public const int numPurchaserMessageX = 100;
        //public const int numPurchaserMessageY = 110;
        //public const int numPurchaserX = 550;
        //public const int numPurchaserY = 130;
        //public const int numPurchaserPostCodeX = 550;
        //public const int numPurchaserPostCodeY = 150;
        //public const int numPurchaserAddressX = 550;
        //public const int numPurchaserAddressY = 170;
        //public const int numPurchaserTelX = 550;
        //public const int numPurchaserTelY = 190;
        //public const int numPurchaserFaxX = 550;
        //public const int numPurchaserFaxY = 210;
        //public const int numOrderMarkX = 700;
        //public const int numOrderMarkY = 230;

        //// 発注合計
        //public const int numOrderPriceX = 50;
        //public const int numOrderPriceY = 260;

        //// インポート（Excel）
        //public const int ExcelRowTop = 2;

        //// フォームサイズ
        ////public const int topFormWidth = 1100;
        ////public const int topFormHeight = 620;
        ////public const int salesFormWidth = 1100;
        ////public const int salesFormHeight = 620;
        ////public const int stockFormWidth = 1100;
        ////public const int stockFormHeight = 620;
        ////public const int stockListFormWidth = 638;
        ////public const int stockListFormHeight = 562;
        ////public const int orderFormWidth = 1100;
        ////public const int orderFormHeight = 620;
        ////public const int orderingFormWidth = 800;
        ////public const int orderingFormHeight = 562;
        ////public const int staffFormWidth = 1280;
        ////public const int staffFormHeight = 550;
        ////public const int shopFormWidth = 638;
        ////public const int shopFormHeight = 562;
        ////public const int supplierFormWidth = 1280;
        ////public const int supplierFormHeight = 550;
        ////public const int itemFormWidth = 1280;
        ////public const int itemFormHeight = 550;

        //// 入力範囲
        //public const int quantityMax = 1000;

        //// 値段範囲
        //public const int priceMax = 100000000;

        //// 個数範囲
        //public const int unitsMax = 100;

        //// 税範囲
        //public const int taxMax = 100;

        //// 項目長
        //public const int columnMaxLength = 500;

        //// 最大文字長
        //public const int charMaxLength = 30;

        //// ログページサイズ
        //public const int logPageSizeMin = 10;
        //public const int logPageSizeMax = 10000;
    }

}

