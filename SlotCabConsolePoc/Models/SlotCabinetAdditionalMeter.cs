using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetAdditionalMeter
    {
        public Guid EventSequenceId { get; set; }
        public int MeterId { get; set; }
        public long Value { get; set; }
    }
}
