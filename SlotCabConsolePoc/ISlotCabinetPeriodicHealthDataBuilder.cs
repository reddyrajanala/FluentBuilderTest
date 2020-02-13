namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;

    public interface ISlotCabinetPeriodicHealthDataBuilder
    {
        ISlotCabinetEventDataBuilder AddPeriodicHealth(Action<SlotCabinetPeriodicHealth> customize = null);
    }
}