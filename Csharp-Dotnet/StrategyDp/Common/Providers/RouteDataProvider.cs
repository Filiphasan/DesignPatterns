namespace StrategyDp.Common.Providers;

public static class RouteDataProvider
{
    public static RouteModel[] GetRoutes() =>
    [
        new RouteModel { Id = 1, Name = "İstanbul", Latitude = "41.0054632", Longitude = "28.8473759" },
        new RouteModel { Id = 2, Name = "İzmir", Latitude = "38.4177807", Longitude = "26.9973174" },
        new RouteModel { Id = 3, Name = "Ankara", Latitude = "39.9032225", Longitude = "32.4509717" },
        new RouteModel { Id = 4, Name = "Bursa", Latitude = "40.2217045", Longitude = "28.876407" },
        new RouteModel { Id = 5, Name = "Gaziantep", Latitude = "37.0588328", Longitude = "37.3389377" },
    ];

    private static RouteDurationModel[] GetRouteDurations() =>
    [
        new RouteDurationModel { SourceRouteId = 1, DestinationRouteId = 2, CarDuration = 3, BicycleDuration = 6, FootDuration = 12, CarDistance = 350, BicycleDistance = 420, FootDistance = 500 },
        new RouteDurationModel { SourceRouteId = 1, DestinationRouteId = 3, CarDuration = 5, BicycleDuration = 10, FootDuration = 20, CarDistance = 570, BicycleDistance = 640, FootDistance = 830 },
        new RouteDurationModel { SourceRouteId = 1, DestinationRouteId = 4, CarDuration = 4, BicycleDuration = 8, FootDuration = 16, CarDistance = 270, BicycleDistance = 330, FootDistance = 400 },
        new RouteDurationModel { SourceRouteId = 1, DestinationRouteId = 5, CarDuration = 20, BicycleDuration = 40, FootDuration = 80, CarDistance = 990, BicycleDistance = 1200, FootDistance = 1480 },
        new RouteDurationModel { SourceRouteId = 2, DestinationRouteId = 3, CarDuration = 6, BicycleDuration = 12, FootDuration = 24, CarDistance = 640, BicycleDistance = 750, FootDistance = 870 },
        new RouteDurationModel { SourceRouteId = 2, DestinationRouteId = 4, CarDuration = 4, BicycleDuration = 8, FootDuration = 16, CarDistance = 320, BicycleDistance = 370, FootDistance = 480 },
        new RouteDurationModel { SourceRouteId = 2, DestinationRouteId = 5, CarDuration = 18, BicycleDuration = 36, FootDuration = 72, CarDistance = 1200, BicycleDistance = 1500, FootDistance = 1780 },
        new RouteDurationModel { SourceRouteId = 3, DestinationRouteId = 4, CarDuration = 5, BicycleDuration = 10, FootDuration = 20, CarDistance = 440, BicycleDistance = 530, FootDistance = 620 },
        new RouteDurationModel { SourceRouteId = 3, DestinationRouteId = 5, CarDuration = 12, BicycleDuration = 24, FootDuration = 48, CarDistance = 770, BicycleDistance = 890, FootDistance = 950 },
        new RouteDurationModel { SourceRouteId = 4, DestinationRouteId = 5, CarDuration = 16, BicycleDuration = 32, FootDuration = 64, CarDistance = 800, BicycleDistance = 850, FootDistance = 930 },
    ];

    public static RouteDurationModel GetRouteDuration(int sourceRouteId, int destinationRouteId)
    {
        var durations = GetRouteDurations();
        var duration = durations
            .FirstOrDefault(x => (x.SourceRouteId == sourceRouteId && x.DestinationRouteId == destinationRouteId) || (x.SourceRouteId == destinationRouteId && x.DestinationRouteId == sourceRouteId));

        ArgumentNullException.ThrowIfNull(duration);
        return duration;
    }
}

public class RouteModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;
}

public class RouteDurationModel
{
    public int SourceRouteId { get; set; }
    public int DestinationRouteId { get; set; }
    public int CarDuration { get; set; }
    public int CarDistance { get; set; }
    public int BicycleDuration { get; set; }
    public int BicycleDistance { get; set; }
    public int FootDuration { get; set; }
    public int FootDistance { get; set; }
}