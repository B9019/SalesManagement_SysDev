using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class T_Shipment
    {
        [Key]
        public int ShID { get; set; }               //出荷ID		
        public int ClID { get; set; }               //顧客ID		
        public int? EmID { get; set; }               //社員ID		
        public int SoID { get; set; }               //営業所ID		
        public int OrID { get; set; }               //受注ID		
        public int? ShStateFlag { get; set; }	//出荷状態フラグ
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShFinishDate { get; set; }  //出荷完了年月日
        public int ShFlag { get; set; }	//出荷管理フラグ
        public String ShHidden { get; set; }        //非表示理由
        public String memo { get; set; }　//備考
        //public virtual M_Client M_Client { get; set; }//顧客ID　外部キー
        //public virtual M_Employee M_Employee { get; set; }//顧客ID　外部キー
        //public virtual M_SalesOffice M_SalesOffice { get; set; }//営業所ID　外部キー
        //public virtual T_Order T_Order { get; set; }//受注ID　外部キー




    }
}
