using System.Collections;
using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

[JsonConverter(typeof(PolygonJsonConverter))]
public sealed class PolygonCoordinates(IList<LinearRingCoordinates> items) 
    : IReadOnlyList<LinearRingCoordinates>, ICoordinatesCollection
{
    private readonly IList<LinearRingCoordinates> _items = items;

    public LinearRingCoordinates this[int index] => _items[index];
    public int Count => _items.Count;

    public int Dimensions { get; } = items.Count == 0 ? 0 : items[0].Dimensions;
    public LinearRingCoordinates ExteriorRing => _items[0];
    public InteriorRingsCollection Holes => new(_items);

    public IEnumerator<LinearRingCoordinates> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public readonly struct InteriorRingsCollection : IReadOnlyList<LinearRingCoordinates>
{
    private readonly IList<LinearRingCoordinates> _positions;

    internal InteriorRingsCollection(IList<LinearRingCoordinates> positions)
    {
        _positions = positions;
    }

    public LinearRingCoordinates this[int index]
    {
        get
        {
            if (index < 0 || index >= _positions.Count - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of range.");
            }

            return _positions[index + 1];
        }
    }

    public int Count => _positions.Count - 1;

    public IEnumerator<LinearRingCoordinates> GetEnumerator()
    {
        for (int i = 1; i < _positions.Count; i++)
        {
            yield return _positions[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}