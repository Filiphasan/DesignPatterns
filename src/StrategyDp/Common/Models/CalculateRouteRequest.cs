using StrategyDp.Common.Enums;

namespace StrategyDp.Common.Models;

public class CalculateRouteRequest
{
    public int SourceRouteId { get; set; }
    public int DestinationRouteId { get; set; }
    public RouteType RouteType { get; set; }
}

public class CalculateRouteResponse
{
    public int Distance { get; set; }
    public int Duration { get; set; }
}