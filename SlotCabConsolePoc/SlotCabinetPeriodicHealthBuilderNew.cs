namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;

    public static class SlotCabinetPeriodicHealthBuilderNew
    {
        public static SlotCabinetPeriodicHealth BuildFor(SlotCabinetRegistration registration,
            Action<SlotCabinetPeriodicHealth> customize = null)
        {
            var periodicHealth = new SlotCabinetPeriodicHealth
            {
                SlotCabinetRegistrationId = registration.SlotCabinetRegistrationId,
                RecordDateTime = SliceFixture.GetSystemDateTime(),
            };

            customize?.Invoke(periodicHealth);

            return periodicHealth;
        }
    }
}