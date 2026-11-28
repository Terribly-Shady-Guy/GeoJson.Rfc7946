using System.Collections;
using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

[JsonConverter(typeof(LineStringJsonConverter))]
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

    public Position this[int index] => _items[index];
    public int Count => _items.Count;

    public int Dimensions { get; }

    public IEnumerator<Position> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}