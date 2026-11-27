using System.Collections;

namespace Tk.GeoJson.Rfc7946;

public class LineStringCoordinates : IReadOnlyList<Position>, ICoordinatesCollection
{
    private readonly IList<Position> _items;

    public LineStringCoordinates(IList<Position> items)
    {
        if (items.Count < 2)
        {
            throw new ArgumentException("A valid LineString must conatin at least 2 positions.");
        }

        Dimensions = items.Count == 0 ? 0 : items[0].Dimensions;
        _items = items;
    }

    public Position this[int index]
    {
        get
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range.");
            }

            return _items[index];
        }
    }

    public int Dimensions { get; }

    public int Count => _items.Count;

    public IEnumerator<Position> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}