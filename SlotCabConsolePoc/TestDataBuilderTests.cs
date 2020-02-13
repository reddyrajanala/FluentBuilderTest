namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.SlotAccounting.Models;
    using Shouldly;
    using SMIBv3.DataContracts;
    using Xunit;

    public class TestDataBuilderTests
    {
        [Fact]
        public async Task ShouldPersistTestData()
        {

            // var slotCabinet122 = SlotCabinetBuilderNew.Build();
            // await SliceFixture.InsertAsync(slotCabinet122);

            //1 cabinet only
            var cabinets = await TestDataBuilder
                .Build().NewSlotCabinet()
                .Execute();
            return;
            //2 cabinets with one registration each
            await TestDataBuilder
                .Build().NewSlotCabinet(2).RegisterCabinet()
                .Execute(); ;

            //1 cabinet and two registrations
            await TestDataBuilder
                .Build()
                .NewSlotCabinet()
                .RegisterCabinet()
                .RegisterCabinet()//register another
                .Execute(); ;

            //1 cabinet, registration and 20 valid ticket, 10 expired tickets
            var result = TestDataBuilder
                .Build().NewSlotCabinet()
                .RegisterCabinet()
                .CreateValidTicket() //Note that ticket add ticket printed event record also
                //.CreateExpiredTicket(10)
                .Execute();


           

            //10 cabinets, 1 registration, 1 periodic health, 1 custom event and 1 valid ticket, 10 expired tickets
            var slotCabinets = await TestDataBuilder
                .Build()
                .NewSlotCabinet(10)
                .RegisterCabinet()
                .AddPeriodicHealth()
                .AddCustomSlotCabinetEvent(c => { c.EventTypeId = (int) SlotEventType.ACPowerLost;})
                .CreateValidTicket()
                .Execute();

            foreach (var slotCabinet in slotCabinets)
            {
                // var cabinet = await SliceFixture.FindAsync<SlotCabinet>(slotCabinet.SlotCabinetId);
                // cabinet.ShouldNotBeNull();
            }
        }
        [Fact]
        public async Task ShouldBuildCabinetWithAnExpiredTicket()
        {
            var slotCabinets = await TestDataBuilder
                .Build()
                .NewSlotCabinet(1)
                .RegisterCabinet()
                .CreateExpiredTicket()
                .Execute();

            foreach (var slotCabinet in slotCabinets)
            {
                // var cabinet = await SliceFixture.FindAsync<SlotCabinet>(slotCabinet.SlotCabinetId);
                // cabinet.ShouldNotBeNull();
            }
        }
        [Fact]
        public async Task ShouldBuildCabinetAndValidTicketWithDisposition()
        {
            var slotCabinets = await TestDataBuilder
                .Build()
                .NewSlotCabinet(1)
                .RegisterCabinet()
                .CreateValidTicket()
                .AddQueueDispositionHistory()
                .AddUnQueueDispositionHistory()
                .AddQueueDispositionHistory()
                .AddReverseDispositionHistory()
                .AddPayDispositionHistory()
                .Execute();

            foreach (var slotCabinet in slotCabinets)
            {
                foreach (var slotCabinetSlotCabinetRegistration in slotCabinet.SlotCabinetRegistrations)
                {
                    var printedEvent = slotCabinetSlotCabinetRegistration.SlotCabinetEvents.SingleOrDefault(x => x.EventTypeId == (int) SlotEventType.TicketPrinted);
                    printedEvent.ShouldNotBeNull();
                    //TODO: Load all audit histories and assert
                    //var printAuditHistories = await SliceFixture.FindAsync<TicketPrintedAuditHistory>(printedEvent.EventSequenceId);
                }
            }
        }
    }
}