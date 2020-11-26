using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class M_DispClient
    {
        [Key]
        [DisplayName("顧客ID")]
        public int ClID { get; set; }           //顧客ID	
        [DisplayName("営業所ID")]
        public int SoID { get; set; }           //営業所ID
        [MaxLength(50)]
        [Required]
        [DisplayName("顧客名")]
        public String ClName { get; set; }      //顧客名
        [MaxLength(50)]
        [Required]
        [DisplayName("住所")]
        public String ClAddress { get; set; }   //住所	 
        [MaxLength(13)]
        [Required]
        [DisplayName("電話番号")]
        public String ClPhone { get; set; }     //電話番号	
        [DisplayName("郵便番号")]
        public int ClPostal { get; set; }       //郵便番号
        [MaxLength(13)]
        [Required]
        [DisplayName("FAX")]
        public String ClFAX { get; set; }       //FAX	
        [DisplayName("顧客管理フラグ")]
        public int ClFlag { get; set; }         //顧客管理フラグ	
        [DisplayName("非表示理由")]
        public String ClHidden { get; set; }	//非表示理由		


    }
}
