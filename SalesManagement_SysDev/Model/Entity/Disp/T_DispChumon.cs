using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispChumon
    {
        [Key]
        [DisplayName("注文ID")]
        public int ChID { get; set; }               //注文ID
        [DisplayName("営業所ID")]
        public int SoID { get; set; }               //営業所ID	
        [DisplayName("社員ID")]
        public int? EmID { get; set; }           //社員ID		        
        [DisplayName("顧客ID")]
        public int ClID { get; set; }              //顧客ID	
        [DisplayName("受注ID")]
        public int OrID { get; set; }         //受注ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("注文年月日")]
        public DateTime? ChDate { get; set; }      //注文年月日
        [DisplayName("注文状態フラグ")]
        public int ChStateFlag { get; set; }               //注文状態フラグ		
        [DisplayName("注文管理フラグ")]
        public int ChFlag { get; set; }      //注文管理フラグ
        [DisplayName("非表示理由")]
        public String ChHidden { get; set; }         //非表示理由		
    }
}
