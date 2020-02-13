namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;
    using SMIBv3.DataContracts;

    public class SlotCabinetEventBuilderNew 
    {
        public static SlotCabinetEvent BuildFor(SlotCabinetRegistration registration, Action<SlotCabinetEvent> customize = null)
        {
            var eventSequenceId = Guid.NewGuid();

            var slotCabinetEvent = new SlotCabinetEvent
            {
                EventSequenceId = eventSequenceId,
                SlotCabinetRegistrationId = registration.SlotCabinetRegistrationId,
                ProcessSequenceId = Guid.NewGuid(),
                EventDateTime = SliceFixture.GetSystemDateTime(),
                EventTypeId = (int) SlotEventType.Unknown
            };

            customize?.Invoke(slotCabinetEvent);

            registration.SlotCabinetEvents.Add(slotCabinetEvent);

            return slotCabinetEvent;
        }
    }
}