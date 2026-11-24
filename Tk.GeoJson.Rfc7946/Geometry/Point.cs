using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.CoordinateModels;

namespace Tk.GeoJson.Rfc7946.Geometry;

/// <summary>
/// A geometry GeoJSON type representing a single position.
/// </summary>
public sealed class Point(Position coordinates) : GeoJsonObject, IGeoJsonGeometry
{
    [JsonPropertyName("type")]
    public override GeoJsonObjectTypes Type => GeoJsonObjectTypes.Point;

    /// <summary>
    /// The object's coordinates as a Position.
    /// </summary>
    /// <remarks>Required; must be provided during object initialization.</remarks>
    [JsonPropertyName("coordinates")]
    [JsonPropertyOrder(2)]
    public Position Coordinates { get; } = coordinates;
}
