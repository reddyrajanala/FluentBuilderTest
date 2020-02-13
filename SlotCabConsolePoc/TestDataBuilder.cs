namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.SlotAccounting.Models;
    using SMIBv3.DataContracts;

    public sealed class TestDataBuilder: ISlotCabinetDataBuilder, ITicketPrintedAuditHistoryDataBuilder
    {
        private readonly IList<Task> Tasks = new List<Task>();

        private readonly IList<SlotCabinet> SlotCabinets = new List<SlotCabinet>();
        private readonly IList<SlotCabinetRegistration> SlotCabinetRegistrations = new List<SlotCabinetRegistration>();
        private readonly IList<SlotCabinetEventTicketPrinted> SlotCabinetEventTicketsPrinted = new List<SlotCabinetEventTicketPrinted>();

        private TestDataBuilder()
        {
        }

        public static ISlotCabinetDataBuilder Build()
        {
            return new TestDataBuilder();
        }
        public ISlotCabinetRegistrationDataBuilder NewSlotCabinet(int count = 1, Action<SlotCabinet> customize = null)
        {
            for (var i = 0; i < count; i++)
            {
                var slotCabinet = SlotCabinetBuilderNew.Build(customize);
                SlotCabinets.Add(slotCabinet);
                Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinet); }));
            }
            return this;
        }
        public ISlotCabinetEventDataBuilder RegisterCabinet(Action<SlotCabinetRegistration> customize = null)
        {
            foreach (var slotCabinet in SlotCabinets)
            {
                var slotCabinetRegistration = SlotCabinetRegistrationBuilderNew.BuildFor(slotCabinet, false, customize);
                SlotCabinetRegistrations.Add(slotCabinetRegistration);
                Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetRegistration); }));

                var slotCabinetEvent = SlotCabinetEventBuilderNew.BuildFor(slotCabinetRegistration, c =>
                {
                    c.EventTypeId = (int)SlotEventType.RegisterCabinet;
                });
                Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetEvent); }));
            }
            return this;
        }

        public ISlotCabinetEventDataBuilder AddPeriodicHealth(Action<SlotCabinetPeriodicHealth> customize = null)
        {
            foreach (var slotCabinetRegistration in SlotCabinetRegistrations)
            {
                var slotCabinetPeriodicHealth = SlotCabinetPeriodicHealthBuilderNew.BuildFor(slotCabinetRegistration, customize);
                Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetPeriodicHealth); }));
            }

            return this;
        }
        public ISlotCabinetEventDataBuilder AddCustomSlotCabinetEvent(Action<SlotCabinetEvent> customize = null)
        {
            foreach (var slotCabinetRegistration in SlotCabinetRegistrations)
            {
                var slotCabinetEvent = SlotCabinetEventBuilderNew.BuildFor(slotCabinetRegistration, customize);
                Tasks.Add(Task.Run(async () =>
                {
                    await SliceFixture.InsertAsync(slotCabinetEvent);
                }));
            }
            return this;
        }

        public ITicketPrintedAuditHistoryDataBuilder CreateValidTicket(int ticketCount = 1, Action<SlotCabinetEventTicketPrinted> customizeTicket = null)
        {
            //create a `TicketPrinted` Event and then create Ticket Printed

            foreach (var slotCabinetRegistration in SlotCabinetRegistrations)
            {
                for (int i = 0; i < ticketCount; i++)
                {
                    var slotCabinetEvent = SlotCabinetEventBuilderNew.BuildFor(slotCabinetRegistration, c =>
                    {
                        c.EventTypeId = (int)SlotEventType.TicketPrinted;
                    });
                    Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetEvent); }));
                    var slotCabinetEventTicketPrinted = SlotCabinetEventTicketPrintedBuilderNew.BuildFor(slotCabinetEvent, 1, customizeTicket);
                    SlotCabinetEventTicketsPrinted.Add(slotCabinetEventTicketPrinted);
                    Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetEventTicketPrinted); }));
                }
            }
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder CreateExpiredTicket(int ticketCount = 1, Action<SlotCabinetEventTicketPrinted> customizeTicket = null)
        {
            //create an `TicketPrinted` event and then create ticket printed
            foreach (var slotCabinetRegistration in SlotCabinetRegistrations)
            {
                for (int i = 0; i < ticketCount; i++)
                {
                    var slotCabinetEvent = SlotCabinetEventBuilderNew.BuildFor(slotCabinetRegistration, c =>
                    {
                        c.EventTypeId = (int)SlotEventType.TicketPrinted;
                    });
                    Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetEvent); }));
                    var slotCabinetEventTicketPrinted = SlotCabinetEventTicketPrintedBuilderNew.BuildFor(slotCabinetEvent, 1, c =>
                    {
                        c.ExpirationDateTime = DateTimeOffset.Now.AddDays(-1);
                    });
                    SlotCabinetEventTicketsPrinted.Add(slotCabinetEventTicketPrinted);
                    Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(slotCabinetEventTicketPrinted); }));
                }
            }
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder AddReverseDispositionHistory()
        {
            CreateDispositionRecord(TicketPrintedStatusEnum.Valid, TicketPrintedAuditActionEnum.Reversed);
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder AddQueueDispositionHistory()
        {
            CreateDispositionRecord(TicketPrintedStatusEnum.Queued, TicketPrintedAuditActionEnum.Queued);
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder AddUnQueueDispositionHistory()
        {
            CreateDispositionRecord(TicketPrintedStatusEnum.Valid, TicketPrintedAuditActionEnum.UnQueued);
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder AddVoidDispositionHistory()
        {
            CreateDispositionRecord(TicketPrintedStatusEnum.Void, TicketPrintedAuditActionEnum.Voided);
            return this;
        }
        public ITicketPrintedAuditHistoryDataBuilder AddPayDispositionHistory()
        {
            CreateDispositionRecord(TicketPrintedStatusEnum.Paid, TicketPrintedAuditActionEnum.Paid);
            return this;
        }
        public async Task<IList<SlotCabinet>> Execute()
        {
            // Task.WaitAll(Tasks.ToArray());
            await Task.WhenAll(Tasks);
            // foreach (var task in Tasks)
            // {
            //     task.Start();
            // }
            return SlotCabinets;
        }

        private void CreateDispositionRecord(TicketPrintedStatusEnum ticketPrintedStatus, TicketPrintedAuditActionEnum ticketPrintedAuditAction)
        {
            foreach (var slotCabinetEventTicketPrinted in SlotCabinetEventTicketsPrinted)
            {
                var ticketPrintedAuditHistory = TicketPrintedAuditHistoryBuilderNew.BuildFor(slotCabinetEventTicketPrinted,
                    c =>
                    {
                        c.TicketStatusId = ticketPrintedStatus;
                        c.AuditActionId = ticketPrintedAuditAction;
                    });
                Tasks.Add(Task.Run(async () => { await SliceFixture.InsertAsync(ticketPrintedAuditHistory); }));
            }
        }
    }
}