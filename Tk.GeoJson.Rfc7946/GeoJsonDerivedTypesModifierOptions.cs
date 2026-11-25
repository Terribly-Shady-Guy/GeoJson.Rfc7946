using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Configuration for <see cref="GeoJsonDerivedTypeModifier"/> to modify polymorphism behavior for types extending GeoJSON types.
/// </summary>
public sealed class GeoJsonDerivedTypesModifierOptions
{
    public string GlobalTypeDiscriminatorPropertyName { get; set; } = "$type";
    public bool GloballyIgnoreUnrecognizedTypeDiscriminators { get; set; }
    public JsonUnknownDerivedTypeHandling GlobalUnknownDerivedTypeHandling { get; set; }

    public GeoJsonPolymorphismOptions PointOptions
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        }
        set;
    }

    public GeoJsonPolymorphismOptions MultiPointOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions LineStringOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        }
        set; 
    }

    public GeoJsonPolymorphismOptions MultiLineStringOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        }
        set; 
    }

    public GeoJsonPolymorphismOptions PolygonOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions MultiPolygonOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions GeometryCollectionOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions FeatureOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions FeatureCollectionOptions 
    {
        get
        {
            field ??= CreateDefaultOptions();
            return field;
        } 
        set; 
    }

    private GeoJsonPolymorphismOptions CreateDefaultOptions()
    {
        return new GeoJsonPolymorphismOptions
        {
            TypeDiscriminatorPropertyName = GlobalTypeDiscriminatorPropertyName,
            UnknownDerivedTypeHandling = GlobalUnknownDerivedTypeHandling,
            IgnoreUnrecognizedTypeDiscriminators = GloballyIgnoreUnrecognizedTypeDiscriminators
        };
    }
}
