using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_Product
    {
        [Key]
        public int PrID { get; set; }               //商品ID		
        public int MaID { get; set; }               //メーカID	
        [MaxLength(50)]
        [Required]
        public String PrName { get; set; }           //商品名		
        public int Price { get; set; }              //価格	
        [MaxLength(13)]
        public String PrJCode { get; set; }         //JANコード		
        public int PrSafetyStock { get; set; }      //安全在庫数		
        public int ScID { get; set; }               //小分類ID		
        public int PrModelNumber { get; set; }      //型番
        [MaxLength(20)]
        [Required]
        public String PrColor { get; set; }         //色		
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PrReleaseDate { get; set; } //発売日		
        public int PrFlag { get; set; }             //商品管理フラグ
        public String PrHidden { get; set; }	    //非表示理由		

        public String PrMemo { get; set; }　//備考

        public M_Maker M_Maker { get; set; }//メーカー　外部キー
        public M_SmallClassification M_SmallClassification { get; set; }//小分類ID　外部キー
        public List<T_ArrivalDetail> T_ArrivalDetails { get; set; }//ナビゲーションプロパティ
        public T_ChumonDetail T_ChumonDetail { get; set; }//メーカー　外部キー
        public List<T_HattyuDetail> T_HattyuDetails { get; set; }//ナビゲーションプロパティ
        public List<T_OrderDetail> T_OrderDetails { get; set; }//ナビゲーションプロパティ
        public List<T_SaleDetail> T_SaleDetails { get; set; }//ナビゲーションプロパティ
        public List<T_ShipmentDetail> T_ShipmentDetails { get; set; }//ナビゲーションプロパティ
        public List<T_Stock> T_Stocks { get; set; }//ナビゲーションプロパティ
        public List<T_SyukkoDetail> T_SyukkoDetails { get; set; }//ナビゲーションプロパティ
        public List<T_WarehousingDetail> T_WarehousingDetails { get; set; }//ナビゲーションプロパティ


        //public M_SmallClassification M_SmallClassification { get; set; }　//小分類ID　外部キー


    }
}
