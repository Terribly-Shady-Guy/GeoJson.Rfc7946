using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// An options class to configure <see cref="JsonPolymorphismOptions"/>.
/// </summary>
public sealed class GeoJsonPolymorphismOptions
{
    public GeoJsonPolymorphismOptions()
    {
        TypeDiscriminatorPropertyName = null;
    }

    public string? TypeDiscriminatorPropertyName { get; set; }
    public bool IgnoreUnrecognizedTypeDiscriminators { get; set; }
    public JsonUnknownDerivedTypeHandling UnknownDerivedTypeHandling { get; set; }

    internal JsonPolymorphismOptions CreateJsonPolymorphismOptions()
    {
        JsonPolymorphismOptions options = new()
        {
            IgnoreUnrecognizedTypeDiscriminators = IgnoreUnrecognizedTypeDiscriminators,
            UnknownDerivedTypeHandling = UnknownDerivedTypeHandling
        };

        if (string.IsNullOrWhiteSpace(TypeDiscriminatorPropertyName))
        {
            options.TypeDiscriminatorPropertyName = TypeDiscriminatorPropertyName;
        }

        return options;
    }
}