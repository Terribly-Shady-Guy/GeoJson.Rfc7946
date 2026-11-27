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
    private readonly double[] _bbox;

    public BoundingBox(double[] bbox)
    {
        if (bbox.Length < 4)
        {
            throw new ArgumentException("A valid bbox array must have at least 4 elements.");
        }

        if (bbox.Length % 2 != 0)
        {
            throw new ArgumentException("A valid bbox array must have an even number of elements.");
        }

        _bbox = bbox;
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= _bbox.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range.");
            }

            return _bbox[index];
        }
    }

    public int Dimensions => _bbox.Length / 2;
    public int Count => _bbox.Length;

    public double West => _bbox[0];
    public double South => _bbox[1];
    public double? MinAltitude => Dimensions == 3 ? _bbox[2] : null;
    public double East => Dimensions == 2 ? _bbox[2] : _bbox[3];
    public double North => Dimensions == 2 ? _bbox[3] : _bbox[4];
    public double? MaxAltitude => Dimensions == 3 ? _bbox[5] : null;

    public IEnumerator<double> GetEnumerator()
    {
        foreach (double value in _bbox)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static BoundingBox Create(double west, double south, double east, double north)
    {
        double[] bbox = [west, south, east, north];
        return new BoundingBox(bbox);
    }

    public static BoundingBox Create(double west, double south, double east, double north, double minAltitude, double maxAltitude)
    {
        double[] bbox = [west, south, minAltitude, east, north, maxAltitude];
        return new BoundingBox(bbox);
    }
}
