namespace Tk.GeoJson.Rfc7946.Generators;

internal readonly record struct GeoJsonDerivedTypeInfo
{
    public GeoJsonDerivedTypeInfo(string derivedClassName, string geoJsonBaseTypeName)
    {
        DerivedClassName = derivedClassName;
        GeoJsonBaseTypeName = geoJsonBaseTypeName;
    }

    public string DerivedClassName { get; }
    public string GeoJsonBaseTypeName { get; }
}