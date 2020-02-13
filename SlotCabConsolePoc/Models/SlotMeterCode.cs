using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotMeterCode
    {
        public int MeterId { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public string Notes { get; set; }
    }
}
