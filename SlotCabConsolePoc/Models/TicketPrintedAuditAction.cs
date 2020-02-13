using System;
using System.Collections.Generic;
using System.Text;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public class TicketPrintedAuditAction
    {
        public TicketPrintedAuditActionEnum Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TicketPrintedAuditHistory> TicketsPrintedAuditHistory { get; } = new HashSet<TicketPrintedAuditHistory>();
    }

    public enum TicketPrintedAuditActionEnum
    {
        None = 0,
        Paid = 1,
        Voided = 2,
        Reversed = 3,
        Queued = 4,
        UnQueued = 5,
    }
}
