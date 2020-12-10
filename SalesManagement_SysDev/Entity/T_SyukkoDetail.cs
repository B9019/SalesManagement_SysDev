﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_SyukkoDetail
    {
        [Key]
        public int SyDetailID { get; set; }     //出庫詳細ID
        public int SyID { get; set; }           //出庫ID
        public int PrID { get; set; }           //商品ID
        public int SyQuantity { get; set; }     //数量
        public virtual T_Syukko T_Syukko { get; set; }//出庫ID　外部キー
        public virtual M_Product M_Product { get; set; }//商品ID　外部キー


    }
}
