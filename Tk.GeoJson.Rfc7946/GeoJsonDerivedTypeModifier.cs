using System.Text.Json.Serialization.Metadata;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Applies <see cref="JsonPolymorphismOptions"/> contracts to the <see cref="JsonTypeInfo"/> for any user derived types from any <see cref="GeoJsonObject"/> type.
/// The <see cref="JsonPolymorphismOptions"/> instance is source generated.
/// </summary>
public sealed partial class GeoJsonDerivedTypeModifier
{
    private readonly GeoJsonDerivedTypesModifierOptions _options;

    /// <summary>
    /// Initializes a new instance of <see cref="GeoJsonDerivedTypeModifier"/> using default options.
    /// </summary>
    public GeoJsonDerivedTypeModifier()
    {
        _options = new GeoJsonDerivedTypesModifierOptions();    
    }

    /// <summary>
    /// Initializes a new instance of <see cref="GeoJsonDerivedTypeModifier"/> using provided options.
    /// </summary>
    /// <param name="options"></param>
    public GeoJsonDerivedTypeModifier(GeoJsonDerivedTypesModifierOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Applies the <see cref="JsonPolymorphismOptions"/> supplied by the source generator.
    /// </summary>
    /// <param name="typeInfo">The <see cref="JsonTypeInfo"/> to apply a polymorphic contract.</param>
    public void Apply(JsonTypeInfo typeInfo)
    {
        ApplyImpl(typeInfo);
    }

    partial void ApplyImpl(JsonTypeInfo typeInfo);
}

