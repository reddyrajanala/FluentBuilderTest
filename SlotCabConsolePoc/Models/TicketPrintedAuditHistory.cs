using System;
using System.Collections.Generic;
using System.Text;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public class TicketPrintedAuditHistory
    {
        public Guid Id { get; set; }

        public Guid EventSequenceId { get; set; }

        public TicketPrintedStatusEnum TicketStatusId { get; set; }

        public TicketPrintedAuditActionEnum AuditActionId { get; set; }

        public string Comment { get; set; }

        // UserId comes from the Security.Users table and does NOT have a FK relation
        public string UserId { get; set; }

        public DateTimeOffset AuditDateTime { get; set; }

        public virtual TicketPrintedStatus TicketStatus { get; set; }

        public virtual TicketPrintedAuditAction AuditAction { get; set; }

        public virtual SlotCabinetEventTicketPrinted TicketPrintedEvent { get; set; }
    }
}
