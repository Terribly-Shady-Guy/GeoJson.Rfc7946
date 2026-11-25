using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Tk.GeoJson.Rfc7946;

public sealed class GeoJsonPolymorphismOptions
{
    public GeoJsonPolymorphismOptions()
    {
        TypeDiscriminatorPropertyName = "$type";
    }

    public string TypeDiscriminatorPropertyName { get; set; }
    public bool IgnoreUnrecognizedTypeDiscriminators { get; set; }
    public JsonUnknownDerivedTypeHandling UnknownDerivedTypeHandling { get; set; }

    internal JsonPolymorphismOptions CreateJsonPolymorphismOptions()
    {
        return new JsonPolymorphismOptions
        {
            TypeDiscriminatorPropertyName = TypeDiscriminatorPropertyName,
            IgnoreUnrecognizedTypeDiscriminators = IgnoreUnrecognizedTypeDiscriminators,
            UnknownDerivedTypeHandling = UnknownDerivedTypeHandling
        };
    }
}