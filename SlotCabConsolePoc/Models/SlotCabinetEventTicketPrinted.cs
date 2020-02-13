namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public partial class SlotCabinetEventTicketPrinted
    {
        public Guid EventSequenceId { get; set; }

        public uint Amount { get; set; }

        public byte SystemId { get; set; }

        public string ValidationNumber { get; set; }

        public ushort TicketNumber { get; set; }

        public byte TicketType { get; set; }

        public ushort PoolId { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] TicketHash { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

        public DateTimeOffset PrintedDateTime { get; set; }

        public DateTimeOffset? ExpirationDateTime { get; set; }

        public virtual SlotCabinetEvent SlotCabinetEvent { get; set; }
        public virtual ICollection<TicketPrintedAuditHistory> TicketsPrintedAuditHistory { get; } = new HashSet<TicketPrintedAuditHistory>();

        public (string Name, DateTimeOffset Date) GetStatus(DateTimeOffset calculationDate) =>
            CalculateTicketStatus(calculationDate, BuildTicketAuditHistoryQuery());

        public (string Name, DateTimeOffset Date) GetStatusExcludingQueue(DateTimeOffset calculationDate)
        {
            var filteredTicketHistoryQuery = BuildTicketAuditHistoryQuery()
                .Where(x => x.AuditActionId != TicketPrintedAuditActionEnum.Queued)
                .Where(x => x.AuditActionId != TicketPrintedAuditActionEnum.UnQueued);

            return CalculateTicketStatus(calculationDate, filteredTicketHistoryQuery);
        }

        private IQueryable<TicketPrintedAuditHistory> BuildTicketAuditHistoryQuery() =>
            TicketsPrintedAuditHistory
                .OrderBy(y => y.AuditDateTime)
                .AsQueryable();

        private (string Name, DateTimeOffset Date) CalculateTicketStatus(DateTimeOffset calculationDate,
            IQueryable<TicketPrintedAuditHistory> ticketHistory)
        {
            var lastStatus = ticketHistory
                .Select(y => new {y.TicketStatus.Name, y.AuditDateTime})
                .OrderByDescending(y => y.AuditDateTime).FirstOrDefault();
            var lastStatusOrDefault = lastStatus?.Name ?? nameof(TicketPrintedStatusEnum.Valid);

            var calculatedStatus = lastStatusOrDefault == nameof(TicketPrintedStatusEnum.Valid) &&
                                   ExpirationDateTime.HasValue &&
                                   ExpirationDateTime < calculationDate
                ? nameof(TicketPrintedStatusEnum.Expired)
                : lastStatusOrDefault;

            return (Name: calculatedStatus, Date: lastStatus?.AuditDateTime ?? PrintedDateTime);
        }
    }
}
