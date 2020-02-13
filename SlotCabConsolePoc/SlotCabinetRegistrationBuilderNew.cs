namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using Data.SlotAccounting.Models;
    using SMIBv3.DataContracts;

    public class SlotCabinetRegistrationBuilderNew
    {
        public static SlotCabinetRegistration BuildFor(SlotCabinet slotCabinet, bool addRegisterEvent = true, Action<SlotCabinetRegistration> customize = null)
        {
            var slotCabinetRegistration = new SlotCabinetRegistration
            {
                MacAddress = Utils.SampleMacAddress(),
                SasVersion = "SasVersion",
                SlotCabinetId = slotCabinet.SlotCabinetId,
                RegistrationDateTime = SliceFixture.GetSystemDateTime(),
            };

            customize?.Invoke(slotCabinetRegistration);

            slotCabinet.SlotCabinetRegistrations.Add(slotCabinetRegistration);

            if (addRegisterEvent)
            {
                //auto add a register cabinet event on new cabinet registration addition
                var slotCabinetEvent = SlotCabinetEventBuilderNew.BuildFor(slotCabinetRegistration, sce =>
                {
                    sce.EventTypeId = (int)SlotEventType.RegisterCabinet;
                });
                slotCabinetRegistration.SlotCabinetEvents.Add(slotCabinetEvent);
            }

            return slotCabinetRegistration;
        }
    }
}