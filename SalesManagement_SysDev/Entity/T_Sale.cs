using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class T_Sale
    {
        [Key]
        public int SaID { get; set; }           //売上ID	
        public int ClID { get; set; }           //顧客ID	
        public int SoID { get; set; }           //営業所ID	
        public int EmID { get; set; }           //受注社員ID	
        public int OrID { get; set; }           //受注ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SaDate { get; set; }    //売上日時
        public String SaHidden { get; set; }    //非表示理由	
        public int SaFlag { get; set; }	        //売上管理フラグ	
        public String Samemo { get; set; }      //備考
        public M_Client M_Client { get; set; }//顧客ID　外部キー
        public M_SalesOffice M_SalesOffice { get; set; }//顧客ID　外部キー
        public M_Employee M_Employee { get; set; }//顧客ID　外部キー
        public T_Order T_Order { get; set; }//顧客ID　外部キー
        public List<T_SaleDetail> T_SaleDetail { get; set; }//ナビゲーションプロパティ





    }
}
