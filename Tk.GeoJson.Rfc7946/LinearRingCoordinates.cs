using System.Collections.ObjectModel;

namespace Tk.GeoJson.Rfc7946;

public sealed class LinearRingCoordinates : Collection<Position>, ICoordinatesCollection
{
    public LinearRingCoordinates() : base()
    {
        Dimensions = 0;
    }

    public LinearRingCoordinates(IList<Position> items) : base(items)
    {
        Dimensions = items.Count == 0 ? 0 : items[0].Dimensions;
    }

    public int Dimensions { get; private set; }
    public bool IsValid => Count >= 4 && Items[0] == Items[^1];

    protected override void InsertItem(int index, Position item)
    {
        if (Dimensions == 0)
        {
            Dimensions = item.Dimensions;
        }

        base.InsertItem(index, item);
    }

    protected override void SetItem(int index, Position item)
    {
        if (Dimensions == 0)
        {
            Dimensions = item.Dimensions;
        }

        base.SetItem(index, item);
    }
}
