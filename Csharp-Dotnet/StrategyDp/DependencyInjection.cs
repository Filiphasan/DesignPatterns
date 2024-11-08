using StrategyDp.Strategies.Contexts;
using StrategyDp.Strategies.Implementations;

namespace StrategyDp;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<RouteStrategyContext>();
        services.AddTransient<CarRouteService>();
        services.AddTransient<BicycleRouteService>();
        services.AddTransient<FootRouteService>();
    }
}