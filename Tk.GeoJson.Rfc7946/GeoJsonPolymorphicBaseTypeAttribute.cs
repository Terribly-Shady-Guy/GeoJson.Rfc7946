namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// An attribute that inducates that the decorated class is derived from a GeoJSON type.
/// This is used by a source generator to generate the json polymorphic contracts.
/// </summary>
/// <param name="type">The GeoJSON type being extended.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class GeoJsonPolymorphicBaseTypeAttribute(GeoJsonObjectTypes type, string typeDiscriminator) : Attribute
{
    public GeoJsonObjectTypes Type { get; } = type;
    public string TypeDiscriminator { get; } = typeDiscriminator;
}
