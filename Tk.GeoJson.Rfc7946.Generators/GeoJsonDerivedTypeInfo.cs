namespace Tk.GeoJson.Rfc7946.Generators;

internal readonly record struct GeoJsonDerivedTypeInfo
{
    public GeoJsonDerivedTypeInfo(string geoJsonType, string className, string baseTypeName)
    {
        GeoJsonType = geoJsonType;
        ClassName = className;
        BaseTypeName = baseTypeName;
    }

    public string GeoJsonType { get; }
    public string ClassName { get; }
    public string BaseTypeName { get; }
}