using SalesManagement_SysDev.Model.ContentsManagement.Common;
using SalesManagement_SysDev;
using SalesManagement_SysDev.Model;
using SalesManagement_SysDev.Model.Entity;
using SalesManagement_SysDev.Model.Entity.Disp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagement_SysDev.Model.ContentsManagement;


namespace SalesManagement_SysDev.Entity
{
    // 従業員マスター　エンティティ
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public byte[] Password { get; set; }
    }
}
