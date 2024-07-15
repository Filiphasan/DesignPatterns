using StrategyDp.Common.Models;
using StrategyDp.Common.Providers;
using StrategyDp.Strategies.Interfaces;

namespace StrategyDp.Strategies.Implementations;

public class FootRouteService : IRouteService
{
    public async Task<CalculateRouteResponse> CalculateRouteAsync(int sourceRouteId, int destinationRouteId)
    {
        // Simulate Foot route calculation
        await Task.Delay(1200);
        var routeDuration = RouteDataProvider.GetRouteDuration(sourceRouteId, destinationRouteId);
        return new CalculateRouteResponse
        {
            Duration = routeDuration.FootDuration,
            Distance = routeDuration.FootDistance
        };
    }
}