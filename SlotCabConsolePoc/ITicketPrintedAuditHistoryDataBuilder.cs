namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    public interface ITicketPrintedAuditHistoryDataBuilder: ISlotCabinetEventDataBuilder, IReturnTestDataSummary
    {
        ITicketPrintedAuditHistoryDataBuilder AddPayDispositionHistory();
        ITicketPrintedAuditHistoryDataBuilder AddVoidDispositionHistory();
        ITicketPrintedAuditHistoryDataBuilder AddQueueDispositionHistory();
        ITicketPrintedAuditHistoryDataBuilder AddUnQueueDispositionHistory();
        ITicketPrintedAuditHistoryDataBuilder AddReverseDispositionHistory();
    }
}