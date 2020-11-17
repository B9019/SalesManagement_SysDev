using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Model.Entity
{
    // 暗号化キー管理　エンティティ
    public class CryptographicKey
    {
        public int CryptographicKeyId { get; set; }
        public byte[] Key { get; set; }
        public byte[] Iv { get; set; }
        public int Status { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}
