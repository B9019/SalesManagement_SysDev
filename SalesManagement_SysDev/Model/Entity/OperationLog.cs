using System;

namespace SalesManagement.Model.Entity
{
    // ログ　エンティティ
    public class OperationLog
    {
        public int OperationLogId { get; set; }
        public DateTime EventRaisingTime { get; set; }
        public string Operator { get; set; }
        public string Table { get; set; }
        public string Command { get; set; }
        public string Data { get; set; }
        public string Comments { get; set; }
    }
}
