using System;
using System.Collections.Generic;
using System.Text;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public class SlotCabinet
    {
        public Guid SlotCabinetId { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public uint AssetNumber { get; set; }

        public ushort? SiteCode { get; set; }

        public ushort? HouseNumber { get; set; }

        public string LogicBoardSerialNumber { get; set; }

        public int SlotCabinetManufactureId { get; set; }

        public int SlotCabinetTypeId { get; set; }

        public int SlotCabinetStyleId { get; set; }

        public virtual SlotCabinetManufacture SlotCabinetManufacture { get; set; }

        public virtual SlotCabinetType SlotCabinetType { get; set; }

        public virtual SlotCabinetStyle SlotCabinetStyle { get; set; }

        public virtual ICollection<SlotCabinetRegistration> SlotCabinetRegistrations { get; } = new HashSet<SlotCabinetRegistration>();

    }
}
