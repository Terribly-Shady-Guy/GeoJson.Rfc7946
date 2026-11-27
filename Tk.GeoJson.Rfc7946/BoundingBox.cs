using System.Collections;
using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Represents a bounding box for a GeoJSON type.
/// </summary>
[JsonConverter(typeof(BoundingBoxJsonConverter))]
public sealed class BoundingBox : IReadOnlyList<double>
{
    private readonly IList<double> _items;

    public BoundingBox(IList<double> bbox)
    {
        if (bbox.Count < 4)
        {
            throw new ArgumentException("bbox must have at least 4 elements.", nameof(bbox));
        }

        if (bbox.Count % 2 != 0)
        {
            throw new ArgumentException("bbox must contain an even number of elements.", nameof(bbox));
        }

        _items = bbox;
    }

    public BoundingBox(double west, double south, double east, double north) 
        : this([west, south, east, north])
    {}

    public BoundingBox(double west, double south, double east, double north, double minAltitude, double maxAltitude)
        : this([west, south, minAltitude, east, north, maxAltitude])
    {}

    public double this[int index] => _items[index];

    public int Dimensions => _items.Count / 2;
    public int Count => _items.Count;

    public double West => _items[0];
    public double South => _items[1];
    public double? MinAltitude => Dimensions == 3 ? _items[2] : null;
    public double East => Dimensions == 2 ? _items[2] : _items[3];
    public double North => Dimensions == 2 ? _items[3] : _items[4];
    public double? MaxAltitude => Dimensions == 3 ? _items[5] : null;

    public IEnumerator<double> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
