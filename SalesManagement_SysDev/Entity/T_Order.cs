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
        public M_SalesOffice M_SalesOffice { get; set; }//ナビゲーションプロパティ
        public M_Employee M_Employee { get; set; }//ナビゲーションプロパティ
        public M_Client M_Client { get; set; }//ナビゲーションプロパティ

        public List<T_Arrival> T_Arrival { get; set; }//ナビゲーションプロパティ
        public List<T_Chumon> T_Chumon { get; set; }//ナビゲーションプロパティ
        public List<T_OrderDetail> T_OrderDetail { get; set; }//ナビゲーションプロパティ
        public List<T_Sale> T_Sale { get; set; }//ナビゲーションプロパティ
        public List<T_Shipment> T_Shipment { get; set; }//ナビゲーションプロパティ
        public List<T_Syukko> T_Syukko { get; set; }//ナビゲーションプロパティ


    }
}
