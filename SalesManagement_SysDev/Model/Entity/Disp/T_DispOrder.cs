using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispOrder
    {
        [Key]
        [DisplayName("受注ID")]
        public int OrID { get; set; }           //受注ID	
        [DisplayName("営業所ID")]
        public int SoID { get; set; }           //営業所ID	
        [DisplayName("社員ID")]
        public int EmID { get; set; }           //社員ID	
        [DisplayName("顧客ID")]
        public int ClID { get; set; }           //顧客ID
        [MaxLength(50)]
        [Required]
        [DisplayName("顧客担当者名")]
        public String ClCharge { get; set; }    //顧客担当者名
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("受注年月日")]
        public DateTime OrDate { get; set; }    //受注年月日
        [DisplayName("受注状態フラグ")]
        public int? OrStateFlag { get; set; }    //受注状態フラグ
        [DisplayName("受注管理フラグ")]
        public int OrFlag { get; set; } //受注管理フラグ
        [DisplayName("非表示理由")]
        public String OrHidden { get; set; }    //非表示理由
    }
}
