using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Converters;

public sealed class LineStringCoordinatesJsonConverter : JsonConverter<LineStringCoordinates>
{
    public override LineStringCoordinates? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Position[] lineString = JsonSerializer.Deserialize<Position[]>(ref reader, options)
            ?? throw new JsonException("Position array returned null.");

        return new LineStringCoordinates(lineString);
    }

    public override void Write(Utf8JsonWriter writer, LineStringCoordinates value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
