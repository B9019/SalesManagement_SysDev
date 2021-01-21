using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispArrival
    {
        [Key]
        [DisplayName("入荷ID")]
        public int ArID { get; set; }               //入荷ID	
        [DisplayName("営業所ID")]
        public int SoID { get; set; }               //営業所ID	
        [DisplayName("社員ＩＤ")]
        public int? EmID { get; set; }               //社員ID	
        [DisplayName("顧客ID")]
        public int ClID { get; set; }               //顧客ID	
        [DisplayName("受注ＩＤ")]
        public int OrID { get; set; }               //受注ID	
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("入荷年月日")]
        public DateTime? ArDate { get; set; }       //入荷年月日	
        [DisplayName("入荷状態フラグ")]
        public int? ArStateFlag { get; set; }   //入荷状態フラグ
        [DisplayName("入荷管理フラグ")]
        public int ArFlag { get; set; } //入荷管理フラグ
        [DisplayName("備考")]
        public String Armemo { get; set; }          //備考
        [DisplayName("非表示理由")]
        public String ArHidden { get; set; }	    //非表示理由

    }
}
