using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispWarehousing
    {
        [Key]
        [DisplayName("入庫ID")]
        public int WaID { get; set; }               //入庫ID
        [DisplayName("発注ID")]
        public int HaID { get; set; }               //発注ID	
        [DisplayName("入庫確認社員ID")]
        public int EmID { get; set; }           //入庫確認社員ID		  
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("入庫年月日")]
        public DateTime WaDate { get; set; }      //入庫年月日
        [DisplayName("入庫済フラグ(棚）")]
        public int WaShelfFlag { get; set; }               //入庫済フラグ(棚）		
        [DisplayName("入庫管理フラグ")]
        public int WaFlag { get; set; }      //入庫管理フラグ
        [DisplayName("非表示理由")]
        public String WaHidden { get; set; }         //非表示理由		
        [DisplayName("備考")]
        public String WaMemo { get; set; }　//備考
    }
}
