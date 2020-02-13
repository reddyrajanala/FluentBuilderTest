namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;

    public interface ISlotCabinetEventDataBuilder : ISlotCabinetRegistrationDataBuilder, ISlotCabinetPeriodicHealthDataBuilder, IReturnTestDataSummary
    {
        ISlotCabinetEventDataBuilder AddCustomSlotCabinetEvent(Action<SlotCabinetEvent> customize = null);
        ITicketPrintedAuditHistoryDataBuilder CreateValidTicket(int ticketCount = 1, Action<SlotCabinetEventTicketPrinted> customizeTicket = null);
        ITicketPrintedAuditHistoryDataBuilder CreateExpiredTicket(int ticketCount = 1, Action<SlotCabinetEventTicketPrinted> customizeTicket = null);
    }
}