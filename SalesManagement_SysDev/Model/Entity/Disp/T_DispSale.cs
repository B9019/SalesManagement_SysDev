using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispSale
    {
        [Key]
        [DisplayName("売上ID")]
        public int SaID { get; set; }           //売上ID	
        [DisplayName("顧客ID")]
        public int ClID { get; set; }           //顧客ID
        [DisplayName("営業所ＩＤ")]
        public int SoID { get; set; }           //営業所ID
        [DisplayName("受注社員ID")]
        public int EmID { get; set; }           //受注社員ID
        [DisplayName("受注ID")]
        public int OrID { get; set; }           //受注ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("売上年月日")]
        public DateTime SaDate { get; set; }    //売上年月日
        [DisplayName("非表示理由")]
        public String SaHidden { get; set; }    //非表示理由	
        [DisplayName("売上管理フラグ")]
        public int SaFlag { get; set; }         //売上管理フラグ	
        [DisplayName("備考")]
        public String Samemo { get; set; }      //備考


    }
}
