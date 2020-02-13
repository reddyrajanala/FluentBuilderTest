using System;
using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public partial class SlotCabinetsWithRowNumber
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
        public long? RowNumber { get; set; }
    }
}
