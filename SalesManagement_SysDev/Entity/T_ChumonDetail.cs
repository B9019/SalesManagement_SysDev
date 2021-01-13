using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_ChumonDetail
    {
        [Key]
        public int ChDetailID2 { get; set; }     //注文詳細ID
        public int ChID2 { get; set; }           //注文ID
        public int PrID2 { get; set; }           //商品ID
        public int ChQuantity2 { get; set; }     //数量
        //public virtual ICollection<T_Chumon> T_Chumon{ get; set; }//ナビゲーションプロパティ
        //public virtual ICollection<M_Product> M_Product { get; set; }//ナビゲーションプロパティ



    }
}
