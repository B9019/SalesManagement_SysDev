namespace SalesManagement_SysDev.Model.Entity
{
    class Constants
    {
        // Microsoft SQL Server DateTime型初期値
        public const string sqlServerInitialDate = "1753/01/01 0:00:00";

        // アクセス権
        public const int numGeneral = 0;
        public const int numSales = 1;
        public const int numlogiManager = 2;
        public const int numOffice = 3;
        public const int numClient = 4;
        public const int numManager = 5;

        public const string strGeneral = "一般";
        public const string strSales = "営業";
        public const string strlogiManager = "物流";
        public const string strOffice = "本社";
        public const string strClient = "顧客";
        public const string strManager = "管理者";

        // 入力範囲
        public const int quantityMax = 1000;

        // 値段範囲
        public const int priceMax = 100000000;

        // 個数範囲
        public const int unitsMax = 100;

        // 税範囲
        public const int taxMax = 100;

        // 項目長
        public const int columnMaxLength = 500;

        // 最大文字長
        public const int charMaxLength = 30;

        // ログページサイズ
        public const int logPageSizeMin = 10;
        public const int logPageSizeMax = 10000;


    }
}
