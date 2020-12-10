using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class M_Client
    {
        [Key]
        public int ClID { get; set; }           //顧客ID		
        public int SoID { get; set; }           //営業所ID
        [MaxLength(50)]
        [Required]
        public String ClName { get; set; }      //顧客名
        [MaxLength(50)]
        [Required]
        public String ClAddress { get; set; }   //住所	 
        [MaxLength(13)]
        [Required]
        public String ClPhone { get; set; }     //電話番号		
        public int ClPostal { get; set; }       //郵便番号
        [MaxLength(13)]
        [Required]
        public String ClFAX { get; set; }       //FAX		
        public int ClFlag { get; set; }         //顧客管理フラグ	
        public String ClHidden { get; set; }    //非表示理由		
        public M_SalesOffice M_SalesOffice { get; set; }//小分類ID　外部キー
        public List<T_Arrival> T_Arrivals { get; set; }//ナビゲーションプロパティ
        public List<T_Chumon> T_Chumons { get; set; }//ナビゲーションプロパティ
        public List<T_Order> T_Orders { get; set; }//ナビゲーションプロパティ
        public List<T_Sale> T_Sales { get; set; }//ナビゲーションプロパティ
        public List<T_Shipment> T_Shipments { get; set; }//ナビゲーションプロパティ
        public List<T_Syukko> T_Syukkos { get; set; }//ナビゲーションプロパティ







    }
}
