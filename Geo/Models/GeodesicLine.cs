namespace Kahului.Geo;

public class GeodesicLine
{
    public GeodesicLine(Coordinate a, Coordinate b) : this(a, b, 32)
    {
    }

    public GeodesicLine(Coordinate a, Coordinate b, int fidelity)
    {
        Coordinates = CalculateLine(a, b, fidelity);
        DistanceNm = CalculateDistance(a.Latitude, a.Longitude, b.Latitude, b.Longitude);
    }

    public List<Coordinate> Coordinates { get; private set; }
    public double DistanceNm { get; private set; }

    private static List<Coordinate> CalculateLine(Coordinate a, Coordinate b, int fidelity)
    {
        if (fidelity < 2 || fidelity > 100)
            throw new ArgumentOutOfRangeException(nameof(fidelity));

        var lat1 = Deg2Rad(a.Latitude);
        var lon1 = Deg2Rad(a.Longitude);
        var lat2 = Deg2Rad(b.Latitude);
        var lon2 = Deg2Rad(b.Longitude);
        var list = new List<Coordinate>();

        var d = 2 * Math.Asin(Math.Sqrt(Math.Pow((Math.Sin((lat1 - lat2) / 2)), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow((Math.Sin((lon1 - lon2) / 2)), 2)));

        for (double k = 0; k <= fidelity; k++)
        {
            var f = (k / fidelity);
            var g = Math.Sin((1 - f) * d) / Math.Sin(d);
            var h = Math.Sin(f * d) / Math.Sin(d);

            var x = g * Math.Cos(lat1) * Math.Cos(lon1) + h * Math.Cos(lat2) * Math.Cos(lon2);
            var y = g * Math.Cos(lat1) * Math.Sin(lon1) + h * Math.Cos(lat2) * Math.Sin(lon2);
            var z = g * Math.Sin(lat1) + h * Math.Sin(lat2);

            var lat = Math.Atan2(z, Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            var lon = Math.Atan2(y, x);

            var coordinate = new Coordinate(Rad2Deg(lat), Rad2Deg(lon));
            list.Add(coordinate);
        }

        return list;
    }

    private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        double theta = lon1 - lon2;
        double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
        dist = Math.Acos(dist);
        dist = Rad2Deg(dist);
        dist = dist * 60 * 1.1515;
        dist *= 0.8684;
        return dist;
    }
}
