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
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("bbox must be an array.");
        }

        double[]? bbox = JsonSerializer.Deserialize<double[]>(ref reader, options);
        if (bbox == null)
        {
            throw new JsonException("bbox returned null.");
        }

        try
        {
            return new BoundingBox(bbox);
        }
        catch (ArgumentException ex)
        {
            throw new JsonException("The bounding box array is invalid.", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, BoundingBox value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
