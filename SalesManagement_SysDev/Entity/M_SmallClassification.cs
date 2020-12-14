using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class M_SmallClassification
    {
        [Key]
        public int ScID { get; set; }           //小分類ID		
        public int McID { get; set; }           //大分類ID
        [MaxLength(50)]
        [Required]
        public String ScName { get; set; }      //小分類名		
        public int ScFlag { get; set; }         //小分類管理フラグ
        public String ScHidden { get; set; }    //非表示理由	
        //public virtual ICollection<M_Product> M_Products { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<M_MajorCassification> M_MajorCassifications { get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<M_Employee> M_Employees { get; set; }//ナビゲーションプロパティ




    }
}
