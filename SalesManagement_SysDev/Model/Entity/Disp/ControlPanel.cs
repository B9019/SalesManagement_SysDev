using System;

namespace SalesManagement.Model.Entity
{
    // コントロールパネル　エンティティ
    public class ControlPanel
    {
        public int ControlPanelId { get; set; }
        public string FileName { get; set; }
        public int PageSize { get; set; }
        public long LockSttRecord { get; set; }
        public long LockEndRecord { get; set; }
        public int Status { get; set; }
        public Byte[] Timestamp { get; set; }
    }
}
