using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_Order
    {
        [Key]
        public int OrID { get; set; }           //受注ID		
        public int SoID { get; set; }           //営業所ID		
        public int EmID { get; set; }           //社員ID		
        public int ClID { get; set; }           //顧客ID
        [MaxLength(50)]
        [Required]
        public String ClCharge { get; set; }    //顧客担当者名
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime OrDate { get; set; }    //受注年月日
        public int? OrStateFlag { get; set; }    //受注状態フラグ
        public int OrFlag { get; set; } //受注管理フラグ
        public String OrHidden { get; set; }    //非表示理由
        public virtual M_SalesOffice M_SalesOffice { get; set; }//ナビゲーションプロパティ
        public virtual M_Employee M_Employee { get; set; }//ナビゲーションプロパティ
        public virtual M_Client M_Client { get; set; }//ナビゲーションプロパティ

        public virtual ICollection<T_Arrival> T_Arrivals { get; set; }//ナビゲーションプロパティ
        public virtual ICollection<T_Chumon> T_Chumons { get; set; }//ナビゲーションプロパティ
        public virtual ICollection<T_OrderDetail> T_OrderDetails { get; set; }//ナビゲーションプロパティ
        public virtual ICollection<T_Sale> T_Sales { get; set; }//ナビゲーションプロパティ
        public virtual ICollection<T_Shipment> T_Shipments { get; set; }//ナビゲーションプロパティ
        public virtual ICollection<T_Syukko> T_Syukkos { get; set; }//ナビゲーションプロパティ


    }
}
