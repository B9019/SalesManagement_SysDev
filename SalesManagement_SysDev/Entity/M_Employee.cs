using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class M_Employee
    {
        [Key]
        public int EmID { get; set; }               //社員ID
        [MaxLength(50)]
        [Required]
        public String EmName { get; set; }          //社員名		
        public int SoID { get; set; }               //営業所ID		
        public int PoID { get; set; }               //役職ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EmHiredate { get; set; }    //入社年月日
        [MaxLength(10)]
        [Required]
        public String EmPassword { get; set; }      //パスワード
        [MaxLength(13)]
        [Required]
        public String EmPhone { get; set; }         //電話番号	
        //[MaxLength(13)]
        //[Required]
        // public String EmBarcode { get; set; }    //社員バーコード		
        public int EmFlag { get; set; }             //社員管理フラグ
        public String EmHidden { get; set; }	    //非表示理由	
        public String Emmemo { get; set; }          //備考
        public M_SalesOffice M_SalesOffice { get; set; }//小分類ID　外部キー
        public M_Position M_Position { get; set; }//役職ID　外部キー
        public List<T_Arrival> T_Arrival { get; set; }//ナビゲーションプロパティ
        public List<T_Chumon> T_Chumon { get; set; }//ナビゲーションプロパティ
        public List<T_Hattyu> T_Hattyu { get; set; }//ナビゲーションプロパティ
        public List<T_LoginHistory> T_LoginHistory { get; set; }//ナビゲーションプロパティ
        public List<T_OperationHistory> T_OperationHistory { get; set; }//ナビゲーションプロパティ
        public List<T_Order> T_Order { get; set; }//ナビゲーションプロパティ
        public List<T_Sale> T_Sale { get; set; }//ナビゲーションプロパティ
        public List<T_Shipment> T_Shipment { get; set; }//ナビゲーションプロパティ
        public List<T_Syukko> T_Syukko { get; set; }//ナビゲーションプロパティ
        public List<T_Warehousing> T_Warehousing { get; set; }//ナビゲーションプロパティ











    }
}
