using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_Hattyu
    {
        [Key]
        public int HaID { get; set; }                   //発注ID	
        public int MaID { get; set; }                   //メーカID	
        public int EmID { get; set; }                   //発注社員ID
        public DateTime HaDate { get; set; }            //発注年月日	
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public int? WaWarehouseFlag { get; set; }	//入庫済フラグ（倉庫）
        public int HaFlag { get; set; }	            //発注管理フラグ
        public String Hamemo { get; set; }          //備考
        public String HaHidden { get; set; }            //非表示理由	
        public M_Maker M_Maker { get; set; }//メーカID　外部キー
        public M_Employee M_Employee { get; set; }//社員ID　外部キー
        public List<T_HattyuDetail> T_HattyuDetail { get; set; }//ナビゲーションプロパティ
        public List<T_Warehousing> T_Warehousing { get; set; }//ナビゲーションプロパティ






    }
}
