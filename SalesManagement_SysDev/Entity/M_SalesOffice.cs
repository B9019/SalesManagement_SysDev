using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_SalesOffice
    {
        [Key]
        public int SoID { get; set; }           //営業所ID
        [MaxLength(50)]
        [Required]
        public String SoName { get; set; }      //営業所名	
        [MaxLength(50)]
        [Required]
        public String SoAddress { get; set; }   //住所
        [MaxLength(13)]
        [Required]
        public String SoPhone { get; set; }     //電話番号
        [MaxLength(7)]
        [Required]
        public String SoPostal { get; set; }    //郵便番号	
        [MaxLength(13)]
        [Required]
        public String SoFAX { get; set; }       //FAX		
        public int SoFlag { get; set; }         //営業所管理フラグ	 
        public String SoHidden { get; set; }    //非表示理由		
        public List<M_Employee> M_Employees { get; set; }//ナビゲーションプロパティ
        public List<T_Arrival> T_Arrivals { get; set; }//ナビゲーションプロパティ
        public List<T_Chumon> T_Chumons { get; set; }//ナビゲーションプロパティ
        public List<T_Order> T_Orders { get; set; }//ナビゲーションプロパティ
        public List<T_Sale> T_Sales { get; set; }//ナビゲーションプロパティ
        public List<T_Shipment> T_Shipments { get; set; }//ナビゲーションプロパティ
        public List<T_Syukko> T_Syukkos { get; set; }//ナビゲーションプロパティ





    }
}
