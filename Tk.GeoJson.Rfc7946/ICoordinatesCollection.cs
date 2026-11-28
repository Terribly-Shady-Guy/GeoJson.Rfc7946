namespace Tk.GeoJson.Rfc7946;

public interface ICoordinatesCollection<T> : IReadOnlyList<T>
{
    public int Dimensions { get; }
}
