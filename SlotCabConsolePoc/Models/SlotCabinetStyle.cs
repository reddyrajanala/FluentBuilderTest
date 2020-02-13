using System.Collections.Generic;

namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public class SlotCabinetStyle : ICatalogEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SlotCabinet> SlotCabinets { get; } = new HashSet<SlotCabinet>();
    }
}
