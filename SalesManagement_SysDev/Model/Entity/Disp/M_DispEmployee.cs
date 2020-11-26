using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class M_DispEmployee
    {
        [DisplayName("社員ID")]
        public int EmID { get; set; }               //社員ID
        [MaxLength(50)]
        [Required]
        [DisplayName("社員名")]
        public String EmName { get; set; }          //社員名	
        [DisplayName("営業所ID")]
        public int SoID { get; set; }               //営業所ID		
        [DisplayName("役職ID")]
        public int PoID { get; set; }               //役職ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("入社年月日")]
        public DateTime EmHiredate { get; set; }    //入社年月日
        [MaxLength(10)]
        [Required]
        [DisplayName("パスワード")]
        public String EmPassword { get; set; }      //パスワード
        [MaxLength(13)]
        [Required]
        [DisplayName("電話番号")]
        public String EmPhone { get; set; }         //電話番号	
        //[MaxLength(13)]
        //[Required]
        // public String EmBarcode { get; set; }    //社員バーコード		        
        [DisplayName("社員管理フラグ")]
        public int EmFlag { get; set; }             //社員管理フラグ
        [DisplayName("非表示理由")]
        public String EmHidden { get; set; }	    //非表示理由		

    }
}
