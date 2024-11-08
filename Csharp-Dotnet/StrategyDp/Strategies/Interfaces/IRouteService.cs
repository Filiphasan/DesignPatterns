using StrategyDp.Common.Models;

namespace StrategyDp.Strategies.Interfaces;

public interface IRouteService
{
    Task<CalculateRouteResponse> CalculateRouteAsync(int sourceRouteId, int destinationRouteId);
}