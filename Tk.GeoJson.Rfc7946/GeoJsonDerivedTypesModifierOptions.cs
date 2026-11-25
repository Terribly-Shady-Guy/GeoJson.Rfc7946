namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Configuration for <see cref="GeoJsonDerivedTypeModifier"/> to modify polymorphism behavior for types extending GeoJSON types.
/// </summary>
public sealed class GeoJsonDerivedTypesModifierOptions
{
    public GeoJsonPolymorphismOptions GlobalOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions();
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions PointOptions
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        }
        set;
    }

    public GeoJsonPolymorphismOptions MultiPointOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions LineStringOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        }
        set; 
    }

    public GeoJsonPolymorphismOptions MultiLineStringOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        }
        set; 
    }

    public GeoJsonPolymorphismOptions PolygonOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions MultiPolygonOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions GeometryCollectionOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions FeatureOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }

    public GeoJsonPolymorphismOptions FeatureCollectionOptions 
    {
        get
        {
            field ??= new GeoJsonPolymorphismOptions(GlobalOptions);
            return field;
        } 
        set; 
    }
}
