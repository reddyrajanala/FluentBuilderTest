using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetRegistration
    {
        public Guid SlotCabinetRegistrationId { get; set; }

        public Guid SlotCabinetId { get; set; }

        public string MacAddress { get; set; }

        public string SasVersion { get; set; }

        public long SlotCabinetRowNumber { get; set; }

        public ushort SlotCabinetSiteCode { get; set; }

        public DateTimeOffset RegistrationDateTime { get; set; }

        public virtual ICollection<SlotCabinetEvent> SlotCabinetEvents { get; } = new HashSet<SlotCabinetEvent>();
        public virtual ICollection<SlotCabinetPeriodicHealth> SlotCabinetPeriodicHealth { get; } = new HashSet<SlotCabinetPeriodicHealth>();

        public virtual ICollection<SlotGameRegistration> SlotGameRegistrations { get; } = new HashSet<SlotGameRegistration>();

        public virtual SlotCabinet SlotCabinet { get; set; }
    }
}
