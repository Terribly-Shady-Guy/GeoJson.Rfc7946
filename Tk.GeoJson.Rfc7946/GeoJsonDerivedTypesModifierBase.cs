using System.Text.Json.Serialization.Metadata;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Applies the generated polymorphism contracts to the <see cref="JsonTypeInfo"/> for any user derived types from any <see cref="GeoJsonObject"/> type.
/// </summary>
public abstract class GeoJsonDerivedTypesModifierBase
{
    protected GeoJsonPolymorphismOptions Options { get; private set; }

    /// <summary>
    /// Initializes a new instance of <see cref="GeoJsonDerivedTypesModifierBase"/> using default options.
    /// </summary>
    public GeoJsonDerivedTypesModifierBase()
    {
        Options = new GeoJsonPolymorphismOptions();    
    }

    /// <summary>
    /// Initializes a new instance of <see cref="GeoJsonDerivedTypesModifierBase"/> using provided options.
    /// </summary>
    /// <param name="options"></param>
    public GeoJsonDerivedTypesModifierBase(GeoJsonPolymorphismOptions options)
    {
        Options = options;
    }

    /// <summary>
    /// Applies the <see cref="JsonPolymorphismOptions"/> supplied by the source generator.
    /// </summary>
    /// <param name="typeInfo">The <see cref="JsonTypeInfo"/> to apply a polymorphic contract.</param>
    public abstract void Apply(JsonTypeInfo typeInfo);
}
