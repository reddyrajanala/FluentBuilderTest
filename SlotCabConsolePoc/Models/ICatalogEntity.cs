namespace GEI.GoldenEdge.Data.SlotAccounting.Models
{
    public interface ICatalogEntity<out TId>
    {
        TId Id { get; }
        string Name { get; }
    }
}