using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotGameRegistration
    {
        public Guid SlotGameRegistrationId { get; set; }

        public Guid SlotCabinetRegistrationId { get; set; }

        public ushort GameNumber { get; set; }

        public ushort Denomination { get; set; }

        public string PayTableId { get; set; }

        public string GameId { get; set; }

        public string AdditionalGameId { get; set; }

        public decimal? BaseTheoPercent { get; set; }

        public virtual ICollection<SlotCabinetEvent> SlotCabinetEvents { get; } = new HashSet<SlotCabinetEvent>();

        public virtual SlotCabinetRegistration SlotCabinetRegistration { get; set; }
    }
}
