using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class T_DispStock
    {
        [Key]
        [DisplayName("在庫ID")]
        public int StID        { get; set; }               //在庫ID
        [DisplayName("商品ID")]
        public int PrID        { get; set; }               //商品ID
        [DisplayName("在庫数")]
        public int StQuantity        { get; set; }           //在庫数
        [DisplayName("在庫管理フラグ")]
        public int StFlag        { get; set; }      //在庫管理フラグ	
        [DisplayName("備考")]
        public String StMemo { get; set; }　//備考
    }
}
