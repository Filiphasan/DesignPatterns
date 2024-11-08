using StrategyDp.Common.Models;
using StrategyDp.Strategies.Interfaces;

namespace StrategyDp.Strategies.Contexts;

public class RouteStrategyContext
{
    private IRouteService? _routeService;

    public void SetRouteStrategy(IRouteService routeService)
    {
        _routeService = routeService;
    }
    
    public async Task<CalculateRouteResponse> CalculateRoute(CalculateRouteRequest request)
    {
        ArgumentNullException.ThrowIfNull(_routeService);
        return await _routeService.CalculateRouteAsync(request.SourceRouteId, request.DestinationRouteId);
    }
}