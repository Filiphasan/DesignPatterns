using StrategyDp.Common.Models;
using StrategyDp.Common.Providers;
using StrategyDp.Strategies.Interfaces;

namespace StrategyDp.Strategies.Implementations;

public class BicycleRouteService : IRouteService
{
    public async Task<CalculateRouteResponse> CalculateRouteAsync(int sourceRouteId, int destinationRouteId)
    {
        // Simulate Bicycle route calculation
        await Task.Delay(1200);
        var routeDuration = RouteDataProvider.GetRouteDuration(sourceRouteId, destinationRouteId);
        return new CalculateRouteResponse
        {
            Duration = routeDuration.BicycleDuration,
            Distance = routeDuration.BicycleDistance
        };
    }
}