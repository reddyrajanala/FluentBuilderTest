using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetPeriodicHealth
    {
        public Guid Id { get; set; }

        public Guid SlotCabinetRegistrationId { get; set; }

        public int CpuTemperature { get; set; }

        public long MemoryAvailable { get; set; }

        public long MemoryUsed { get; set; }

        public string LocalEndpoint { get; set; }

        public long DriveTotalSize { get; set; }

        public long DriveFreeSpace { get; set; }

        public string SoftwareVersion { get; set; }

        public DateTimeOffset RecordDateTime { get; set; } 

        public SlotCabinetRegistration SlotCabinetRegistration { get; set; }
    }
}
