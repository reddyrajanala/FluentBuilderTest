using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotGameMeter
    {
        public Guid EventSequence { get; set; }
        public int MeterId { get; set; }
        public long Value { get; set; }
    }
}
