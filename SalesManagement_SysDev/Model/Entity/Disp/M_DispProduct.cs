using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement_SysDev.Model.Entity.Disp
{
    class M_DispProduct
    {
        [Key]
        [DisplayName("メーカＩＤ")]
        public int PrID { get; set; }               //商品ID	
        [DisplayName("メーカＩＤ")]
        public int MaID { get; set; }               //メーカID	
        [MaxLength(50)]
        [Required]
        [DisplayName("商品名")]
        public String PrName { get; set; }           //商品名		        
        [DisplayName("価格")]
        public int Price { get; set; }              //価格	
        [MaxLength(13)]
        [DisplayName("JANコード")]
        public String PrJCode { get; set; }         //JANコード
        [DisplayName("安全在庫数")]
        public int PrSafetyStock { get; set; }      //安全在庫数
        [DisplayName("小分類ID")]
        public int ScID { get; set; }               //小分類ID		
        [DisplayName("型番")]
        public int PrModelNumber { get; set; }      //型番
        [MaxLength(20)]
        [Required]
        [DisplayName("色")]
        public String PrColor { get; set; }         //色		
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("発売日")]
        public DateTime PrReleaseDate { get; set; } //発売日	
        [DisplayName("商品管理フラグ")]
        public int PrFlag { get; set; }             //商品管理フラグ
        [DisplayName("非表示理由")]
        public String PrHidden { get; set; }	    //非表示理由		
        [DisplayName("備考")]
        public String PrMemo { get; set; }　//備考

    }
}
