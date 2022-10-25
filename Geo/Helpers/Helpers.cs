namespace Kahului.Geo.Helpers;

internal static class Helpers
{
    internal static double Deg2Rad(double deg) => (deg * Math.PI / 180.0);

    internal static double Rad2Deg(double rad) => (rad / Math.PI * 180.0);
}
