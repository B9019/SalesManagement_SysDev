using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_ArrivalDetail
    {
        [Key]
        public int ArDetailID { get; set; }     //入荷詳細ID
        public int ArID { get; set; }           //入荷ID
        public int PrID { get; set; }           //商品ID
        public int ArQuantity { get; set; }     //数量
        //public virtual T_Arrival T_Arrival { get; set; }//受注ID　外部キー
        //public virtual M_Product M_Product { get; set; }//商品ID　外部キー


    }
}
