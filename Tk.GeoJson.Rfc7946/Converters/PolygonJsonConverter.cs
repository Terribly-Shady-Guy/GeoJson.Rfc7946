using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tk.GeoJson.Rfc7946.Converters;

public sealed class PolygonJsonConverter : JsonConverter<PolygonCoordinates>
{
    public override PolygonCoordinates? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        LinearRingCoordinates[] polygon = JsonSerializer.Deserialize<LinearRingCoordinates[]>(ref reader, options)
            ?? throw new JsonException("Polygon array is null.");

        return new PolygonCoordinates(polygon);
    }

    public override void Write(Utf8JsonWriter writer, PolygonCoordinates value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
