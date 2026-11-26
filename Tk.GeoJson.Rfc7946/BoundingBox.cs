using System.Collections;
using System.Text.Json.Serialization;
using Tk.GeoJson.Rfc7946.Converters;

namespace Tk.GeoJson.Rfc7946;

/// <summary>
/// Represents a bounding box for a GeoJSON type.
/// </summary>
[JsonConverter(typeof(BoundingBoxJsonConverter))]
public sealed class BoundingBox : IEnumerable<double>
{
    private readonly double[] _bbox;

    public BoundingBox(double[] bbox)
    {
        if (bbox.Length < 4)
        {
            throw new ArgumentException("A valid bbox array must have at least 4 elements.");
        }

        if (bbox.Length % 2 != 0)
        {
            throw new ArgumentException("A valid bbox array must have an even number of elements.");
        }

        _bbox = bbox;
    }

    public BoundingBox(int numDimensions)
    {
        if (numDimensions < 2)
        {
            throw new ArgumentException("Number of dimensions must be 2 or greater.");
        }

        _bbox = new double[numDimensions * 2];
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= _bbox.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of range.");
            }

            return _bbox[index];
        }
        set
        {
            if (index < 0 || index >= _bbox.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "The provided index is out of range.");
            }

            _bbox[index] = value;
        }
    }

    public int Dimensions => _bbox.Length / 2;
    public int Length => _bbox.Length;

    public double West 
    { 
        get => _bbox[0]; 
        set => _bbox[0] = value; 
    }

    public double South 
    { 
        get => _bbox[1]; 
        set => _bbox[1] = value; 
    }

    public double East 
    {
        get
        {
            if (Dimensions == 2)
            {
                return _bbox[2];
            }

            return _bbox[3];
        }
        set
        {
            if (Dimensions == 2)
            {
                _bbox[2] = value;
            }
            else
            {
                _bbox[3] = value;
            }
        } 
    }

    public double North 
    {
        get
        {
            if (Dimensions == 2)
            {
                return _bbox[3];
            }

            return _bbox[4];
        }
        set
        {
            if (Dimensions == 2)
            {
                _bbox[3] = value;
            }
            else
            {
                _bbox[4] = value;
            }
        }
    }
    public double MinAltitude 
    {
        get
        {
            if (Dimensions == 2)
            {
                throw new ArgumentOutOfRangeException(null, "Min altitude is not available in a 2D bbox.");
            }

            return _bbox[2];
        }
        set
        {
            if (Dimensions == 2)
            {
                throw new ArgumentOutOfRangeException(null, "Min altitude is not available in a 2D bbox.");
            }

            _bbox[2] = value;
        }
    }
    public double MaxAltitude 
    {
        get
        {
            if (Dimensions == 2)
            {
                throw new ArgumentOutOfRangeException(null, "Max altitude is not available in a 2D bbox.");
            }

            return _bbox[5];
        }
        set
        {
            if (Dimensions == 2)
            {
                throw new ArgumentOutOfRangeException(null, "Max altitude is not available in a 2D bbox.");
            }

            _bbox[5] = value;
        }
    }

    public IEnumerator<double> GetEnumerator()
    {
        foreach (double value in _bbox)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
