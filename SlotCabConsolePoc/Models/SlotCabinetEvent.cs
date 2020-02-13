using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetEvent
    {
        public Guid EventSequenceId { get; set; }

        public int EventTypeId { get; set; }

        public DateTimeOffset EventDateTime { get; set; }

        public Guid? ProcessSequenceId { get; set; }

        public Guid SlotCabinetRegistrationId { get; set; }

        public Guid? SlotGameRegistrationId { get; set; }

        public SlotCabinetRegistration SlotCabinetRegistration { get; set; }

        public SlotGameRegistration SlotGameRegistration { get; set; }

        public virtual SlotCabinetEventType EventType { get; set; }

        public virtual SlotCabinetEventTicketPrinted TicketPrinted { get; set; }
        public virtual SlotCabinetEventGamePlayed GamePlayed { get; set; }


        public virtual SlotCabinetMeter SlotCabinetMeters { get; set; }
    }
}
