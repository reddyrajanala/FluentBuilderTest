using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetEventType
    {
        public int EventTypeId { get; set; }
        public string EventName { get; set; }

        public virtual ICollection<SlotCabinetEvent> SlotCabinetEvents { get; } = new HashSet<SlotCabinetEvent>();
    }
}
