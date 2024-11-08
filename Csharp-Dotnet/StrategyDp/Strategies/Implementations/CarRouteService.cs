using StrategyDp.Common.Models;
using StrategyDp.Common.Providers;
using StrategyDp.Strategies.Interfaces;

namespace StrategyDp.Strategies.Implementations;

public class CarRouteService : IRouteService
{
    public async Task<CalculateRouteResponse> CalculateRouteAsync(int sourceRouteId, int destinationRouteId)
    {
        // Simulate Car route calculation
        await Task.Delay(1200);
        var routeDuration = RouteDataProvider.GetRouteDuration(sourceRouteId, destinationRouteId);
        return new CalculateRouteResponse
        {
            Duration = routeDuration.CarDuration,
            Distance = routeDuration.CarDistance
        };
    }
}