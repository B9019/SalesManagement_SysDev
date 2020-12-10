using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_Syukko
    {
        [Key]
        public int SyID { get; set; }               //出庫ID	
        public int EmID { get; set; }               //社員ID	
        public int ClID { get; set; }               //顧客ID	
        public int SoID { get; set; }               //営業所ID	
        public int OrID { get; set; }               //受注ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SyDate { get; set; }       //出庫年月日	
        public int SyStateFlag { get; set; }    //出庫状態フラグ
        public int SyFlag { get; set; }	//出庫管理フラグ
        public String SyHidden { get; set; }        //非表示理由	
        public M_Employee M_Employee { get; set; }//社員ID　外部キー
        public M_Client M_Client { get; set; }//顧客ID　外部キー
        public T_Order T_Order { get; set; }//受注ID　外部キー
        public M_SalesOffice M_SalesOffice { get; set; }//顧客ID　外部キー
        public List<T_SyukkoDetail> T_SyukkoDetails { get; set; }//ナビゲーションプロパティ




    }
}
