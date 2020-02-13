namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;

    public class TicketPrintedAuditHistoryBuilderNew
    {
        public static TicketPrintedAuditHistory BuildFor(SlotCabinetEventTicketPrinted ticket,
            Action<TicketPrintedAuditHistory> customize = null)
        {
            var nextNumber = Utils.GetNextNaturalNumber();

            var ticketPrintedAuditHistory = new TicketPrintedAuditHistory
            {
                EventSequenceId = ticket.EventSequenceId,
                TicketStatusId = TicketPrintedStatusEnum.Valid,
                AuditActionId = TicketPrintedAuditActionEnum.None,
                UserId = Guid.NewGuid().ToString(), //TODO: Get UnitTest UserId?
                Comment = $"Comment{nextNumber}",
                AuditDateTime = SliceFixture.GetSystemDateTime()
            };
            customize?.Invoke(ticketPrintedAuditHistory);
            ticket.TicketsPrintedAuditHistory.Add(ticketPrintedAuditHistory);

            return ticketPrintedAuditHistory;
        }
        public TicketPrintedAuditHistory PayTicket(SlotCabinetEventTicketPrinted ticket)
        {
            var ticketPrintedAuditHistory = BuildFor(ticket, c =>
            {
                c.AuditActionId = TicketPrintedAuditActionEnum.Paid;
                c.TicketStatusId = TicketPrintedStatusEnum.Paid;
            });

            return ticketPrintedAuditHistory;
        }
        public TicketPrintedAuditHistory VoidTicket(SlotCabinetEventTicketPrinted ticket)
        {
            var ticketPrintedAuditHistory = BuildFor(ticket, c =>
            {
                c.AuditActionId = TicketPrintedAuditActionEnum.Voided;
                c.TicketStatusId = TicketPrintedStatusEnum.Void;
            });

            return ticketPrintedAuditHistory;
        }

        public TicketPrintedAuditHistory QueueTicket(SlotCabinetEventTicketPrinted ticket)
        {
            var ticketPrintedAuditHistory = BuildFor(ticket, c =>
            {
                c.AuditActionId = TicketPrintedAuditActionEnum.Queued;
                c.TicketStatusId = TicketPrintedStatusEnum.Queued;
            });

            return ticketPrintedAuditHistory;
        }
        public TicketPrintedAuditHistory UnQueTicket(SlotCabinetEventTicketPrinted ticket)
        {
            var ticketPrintedAuditHistory = BuildFor(ticket, c =>
            {
                c.AuditActionId = TicketPrintedAuditActionEnum.UnQueued;
                c.TicketStatusId = TicketPrintedStatusEnum.Valid;
            });

            return ticketPrintedAuditHistory;
        }
        public TicketPrintedAuditHistory ReverseTicket(SlotCabinetEventTicketPrinted ticket)
        {
            var ticketPrintedAuditHistory = BuildFor(ticket, c =>
            {
                c.AuditActionId = TicketPrintedAuditActionEnum.Reversed;
                c.TicketStatusId = TicketPrintedStatusEnum.Valid;
            });

            return ticketPrintedAuditHistory;
        }

    }
}