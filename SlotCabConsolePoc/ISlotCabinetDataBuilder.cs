namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using System.Threading.Tasks;
    using Data.SlotAccounting.Models;

    public interface ISlotCabinetDataBuilder : IReturnTestDataSummary
    {
        ISlotCabinetRegistrationDataBuilder NewSlotCabinet(int count = 1, Action<SlotCabinet> customize = null);
    }
}