namespace Kahului.Geo;

public class Coordinate
{
    public Coordinate() : this(0, 0)
    {
    }

    public Coordinate(double latitude, double longitude)
    {
        if (latitude > 90 || latitude < -90)
            throw new ArgumentOutOfRangeException("latitude");

        while (longitude > 180)
            longitude -= 360;
        while (longitude < -180)
            longitude += 360;

        if (longitude > 180 || longitude < -180)
            throw new ArgumentOutOfRangeException("longitude");

        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public override string ToString() => $"{Latitude}, {Longitude}";
}
