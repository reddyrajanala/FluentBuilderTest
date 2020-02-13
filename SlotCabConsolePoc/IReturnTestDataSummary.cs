namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.SlotAccounting.Models;

    public interface IReturnTestDataSummary
    {
        Task<IList<SlotCabinet>> Execute();
    }
}