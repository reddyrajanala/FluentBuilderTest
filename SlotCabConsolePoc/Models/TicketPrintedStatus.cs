using System;
using System.Collections.Generic;
using System.Text;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public class TicketPrintedStatus
    {
        public TicketPrintedStatusEnum Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TicketPrintedAuditHistory> TicketsPrintedAuditHistory { get; } = new HashSet<TicketPrintedAuditHistory>();
    }

    public enum TicketPrintedStatusEnum
    {
        Valid = 0,
        Expired = 1,
        Paid = 2,
        Void = 3,
        Queued = 4,
    }
}
