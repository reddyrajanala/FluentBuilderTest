namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using System.Threading;
    using Data.SlotAccounting;
    using Data.SlotAccounting.Models;

    public class SlotCabinetEventTicketPrintedBuilderNew
    {
        private static int _validationNumber = 10000000;
        private static uint NextValidationNumber() => (uint)Interlocked.Increment(ref _validationNumber);

        public static SlotCabinetEventTicketPrinted BuildFor(SlotCabinetEvent slotCabinetEvent, int ticketNumber,
            Action<SlotCabinetEventTicketPrinted> customizeTicket = null)
        {
            var slotCabinetEventTicketPrinted = new SlotCabinetEventTicketPrinted
            {
                Amount = (uint)Utils.GetRandomTicketAmount(),
                SystemId = (byte)ticketNumber,
                ValidationNumber = "100",
                TicketNumber = (ushort)ticketNumber,
                TicketType = (byte)ticketNumber,
                PoolId = (ushort)ticketNumber,
                PrintedDateTime = SliceFixture.GetSystemDateTime(),
                ExpirationDateTime = SliceFixture.GetSystemDateTime().AddDays(2),
                EventSequenceId = slotCabinetEvent.EventSequenceId,
            };
            customizeTicket?.Invoke(slotCabinetEventTicketPrinted);
            //update ticket hash
            slotCabinetEventTicketPrinted.TicketHash = null;//slotCabinetEventTicketPrinted.GenerateTicketHashCode(slotCabinetEvent.SlotCabinetRegistrationId);
            return slotCabinetEventTicketPrinted;
        }
    }
}