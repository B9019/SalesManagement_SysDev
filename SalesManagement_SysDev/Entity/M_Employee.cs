using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_Employee
    {
        [Key]
        public int EmID { get; set; }               //社員ID
        [MaxLength(50)]
        [Required]
        public String EmName { get; set; }          //社員名		
        public int SoID { get; set; }               //営業所ID		
        public int PoID { get; set; }               //役職ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EmHiredate { get; set; }    //入社年月日
        [MaxLength(10)]
        [Required]
        public String EmPassword { get; set; }      //パスワード
        [MaxLength(13)]
        [Required]
        public String EmPhone { get; set; }         //電話番号	
        //[MaxLength(13)]
        //[Required]
        // public String EmBarcode { get; set; }    //社員バーコード		
        public int EmFlag { get; set; }             //社員管理フラグ
        public String EmHidden { get; set; }	    //非表示理由	
        public String Emmemo { get; set; }          //備考
        //public virtual M_SalesOffice M_SalesOffice { get; set; }//小分類ID　外部キー
        //public virtual M_Position M_Position { get; set; }//役職ID　外部キー
        //public virtual ICollection<T_Arrival> T_Arrivals { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Chumon> T_Chumons { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Hattyu> T_Hattyus { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_LoginHistory> T_LoginHistorys { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_OperationHistory> T_OperationHistorys { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Order> T_Orders { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Sale> T_Sales { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Shipment> T_Shipments { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Syukko> T_Syukkos { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<T_Warehousing> T_Warehousings { get; set; }//ナビゲーションプロパティ











    }
}
