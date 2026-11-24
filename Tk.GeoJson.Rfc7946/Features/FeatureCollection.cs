using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Geometry;

namespace Tk.GeoJson.Rfc7946.Features;

/// <summary>
/// Reporesents a collection of Feature GeoJSON objects.
/// </summary>
/// <typeparam name="TFeatureGeometry">The type used for each feature Geometry property. Can be nullable.</typeparam>
/// <typeparam name="TFeatureProperties">The type used for each feature Properties property. Can be nullable.</typeparam>
public sealed class FeatureCollection<TFeatureGeometry, TFeatureProperties>(
    IList<Feature<TFeatureGeometry, TFeatureProperties>> features) : GeoJsonObject
    where TFeatureGeometry : IGeoJsonGeometry?
    where TFeatureProperties : class?
{
    [JsonPropertyName("type")]
    public override GeoJsonObjectTypes Type => GeoJsonObjectTypes.FeatureCollection;

    /// <summary>
    /// Represents the "features" property in a feature collection. This will contain a list of <see cref="Feature{TGeometry, TFeatureProperties}"/> objects.
    /// </summary>
    [JsonPropertyName("features")]
    [JsonPropertyOrder(2)]
    public IList<Feature<TFeatureGeometry, TFeatureProperties>> Features { get; } = features;
}