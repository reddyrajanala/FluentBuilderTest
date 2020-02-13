using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetEventGamePlayed
    {
        public Guid EventSequenceId { get; set; }
        public int AmountWagered { get; set; }
        public int AmountWon { get; set; }
        public bool? GameWon { get; set; }
        public string PokerStartingHand { get; set; }
        public string PokerEndingHand { get; set; }

        public virtual SlotCabinetEvent SlotCabinetEvent { get; set; }
    }
}
