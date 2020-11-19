using System;

namespace SalesManagement.Model.Entity
{
    // Salt管理　エンティティ
    public class Salt
    {
        public int SaltId { get; set; }
        public int SaltCode { get; set; }
        public byte[] SaltData { get; set; }
        public int Status { get; set; }
        public Byte[] Timestamp { get; set; }
    }
}
