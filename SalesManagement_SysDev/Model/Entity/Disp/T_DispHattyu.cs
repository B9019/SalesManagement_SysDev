using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispHattyu
    {
        [Key]
        [DisplayName("発注ＩＤ")]
        public int HaID { get; set; }                   //発注ID	
        [DisplayName("メーカＩＤ")]
        public int MaID { get; set; }                   //メーカID	
        [DisplayName("発注社員ＩＤ")]
        public int EmID { get; set; }                   //発注社員ID
        [DisplayName("発注年月日")]
        public DateTime HaDate { get; set; }            //発注年月日	
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("入庫済フラグ（倉庫）")]
        public int? WaWarehouseFlag { get; set; }   //入庫済フラグ（倉庫）
        [DisplayName("発注管理フラグ")]
        public int HaFlag { get; set; }             //発注管理フラグ
        [DisplayName("備考")]
        public String Hamemo { get; set; }          //備考
        [DisplayName("非表示理由")]
        public String HaHidden { get; set; }            //非表示理由	

    }
}
