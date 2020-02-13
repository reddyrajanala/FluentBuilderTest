namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;

    public interface ISlotCabinetRegistrationDataBuilder : IReturnTestDataSummary
    {
        ISlotCabinetEventDataBuilder RegisterCabinet(Action<SlotCabinetRegistration> customize = null);
    }
}