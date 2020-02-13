using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetMeter
    {
        public Guid EventSequenceId { get; set; }
        public long? TotalCoinIn { get; set; }
        public long? TotalCoinOut { get; set; }
        public long? Jackpots { get; set; }
        public long? CancelledCredits { get; set; }
        public long? GamesPlayed { get; set; }
        public long? GamesWon { get; set; }
        public long? GamesLost { get; set; }
        public long? TotalBillsIn { get; set; }
        public long? CurrentCredits { get; set; }
        public long? NonRestrictedVoucherIn { get; set; }
        public long? RestrictedVoucherIn { get; set; }
        public long? NonRestrictedVoucherOut { get; set; }
        public long? RestrictedVoucherOut { get; set; }

        public virtual SlotCabinetEvent SlotCabinetEvent { get; set; }
    }
}
