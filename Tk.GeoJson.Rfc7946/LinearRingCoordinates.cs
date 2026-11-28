using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

[JsonConverter(typeof(LinearRingJsonConverter))]
public sealed class LinearRingCoordinates : LineStringCoordinates
{
    public LinearRingCoordinates(IList<Position> items) : base(items)
    { 
        if (Count < 4 || items[0] != items[^1])
        {
            throw new ArgumentException("A valid linear ring must have at least 4 positions and the first and last positions must be equal.");
        }
    }

}
