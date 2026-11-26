using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> that is responsible for converting an <see cref="BoundingBox"/> to and from a JSON array.
/// </summary>
public sealed class BoundingBoxJsonConverter : JsonConverter<BoundingBox>
{
    public override BoundingBox Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        double[] bbox = JsonSerializer.Deserialize<double[]>(ref reader, options)
            ?? throw new JsonException("bbox returned null.");

        return new BoundingBox(bbox);
    }

    public override void Write(Utf8JsonWriter writer, BoundingBox value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
