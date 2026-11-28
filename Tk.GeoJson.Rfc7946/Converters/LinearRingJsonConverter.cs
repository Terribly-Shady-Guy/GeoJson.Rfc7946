using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Converters;

[JsonConverter(typeof(LinearRingJsonConverter))]
public sealed class LinearRingJsonConverter : JsonConverter<LinearRingCoordinates>
{
    public override LinearRingCoordinates? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Position[] linearRing = JsonSerializer.Deserialize<Position[]>(ref reader, options)
            ?? throw new JsonException("LinearRing array is null.");

        if (linearRing.Length < 4)
        {
            throw new JsonException("A valid LinearRing must contain at least 4 positions");
        }

        if (linearRing[0] != linearRing[^1])
        {
            throw new JsonException("A valid LinearRing's first and last position must be equal.");
        }

        return new LinearRingCoordinates(linearRing);
    }

    public override void Write(Utf8JsonWriter writer, LinearRingCoordinates value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
