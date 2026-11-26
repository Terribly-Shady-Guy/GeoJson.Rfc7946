namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Represents a 2D bounding box for a GeoJson type.
/// </summary>
public sealed class TwoDimensionalBoundingBox : BoundingBox
{
    public override string ToString()
    {
        return $"[{West},{South},{East},{North}]";
    }
}
