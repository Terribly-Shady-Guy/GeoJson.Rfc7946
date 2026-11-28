using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Geometry;

/// <summary>
/// A geometry GeoJSON type representing a collection of positions.
/// </summary>
public class MultiPoint : GeoJsonObject, IGeoJsonGeometry
{
    public MultiPoint(IList<Position> coordinates, BoundingBox? bbox = null) : base(bbox)
    {
        Coordinates = coordinates;
    }

    [JsonPropertyName("type")]
    public sealed override GeoJsonObjectTypes Type => GeoJsonObjectTypes.MultiPoint;

    /// <summary>
    /// Represents the "coordinates" property in a GeoJSON geometry object. For a "MultiPoint" type, it will contain an array of arbitrary position arrays.
    /// </summary>
    [JsonPropertyName("coordinates")]
    [JsonPropertyOrder(2)]
    public IList<Position> Coordinates { get; }
}
