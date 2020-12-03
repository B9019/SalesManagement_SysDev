using System;

namespace SalesManagement_SysDev.Model.Entity
{
    class OperationLog
    {
        public int OperationLogId { get; set; }
        public DateTime EventRaisingTime { get; set; }
        public string Operator { get; set; }
        public string Table { get; set; }
        public string Command { get; set; }
        public string Data { get; set; }

    }
}
