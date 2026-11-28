using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Converters;

public sealed class LineStringJsonConverter : JsonConverter<LineStringCoordinates>
{
    public override LineStringCoordinates? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Position[] lineString = JsonSerializer.Deserialize<Position[]>(ref reader, options)
            ?? throw new JsonException("Position array returned null.");

        if (lineString.Length < 2)
        {
            throw new JsonException("A valid LineString must contain at least 2 positions.");
        }

        return new LineStringCoordinates(lineString);
    }

    public override void Write(Utf8JsonWriter writer, LineStringCoordinates value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
