using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Represents a bounding box for a GeoJSON type.
/// </summary>
[JsonConverter(typeof(BoundingBoxJsonConverter))]
public sealed class BoundingBox : ReadOnlyCollection<double>
{
    internal BoundingBox(double[] bbox) : base(bbox)
    {}

    public BoundingBox(double west, double south, double east, double north) 
        : this([west, south, east, north])
    {}

    public BoundingBox(double west, double south, double east, double north, double minAltitude, double maxAltitude)
        : this([west, south, minAltitude, east, north, maxAltitude])
    {}

    public int Dimensions => Items.Count / 2;

    public double West => Items[0];
    public double South => Items[1];
    public double? MinAltitude => Dimensions == 3 ? Items[2] : null;
    public double East => Dimensions == 2 ? Items[2] : Items[3];
    public double North => Dimensions == 2 ? Items[3] : Items[4];
    public double? MaxAltitude => Dimensions == 3 ? Items[5] : null;

    public static BoundingBox CreateFromArray(double[] bbox)
    {
        if (bbox.Length < 4)
        {
            throw new ArgumentException("bbox must have at least 4 elements.", nameof(bbox));
        }

        if (bbox.Length % 2 != 0)
        {
            throw new ArgumentException("bbox must contain an even number of elements.", nameof(bbox));
        }

        return new BoundingBox(bbox);
    }
}
