using Carter;
using StrategyDp.Common.Enums;
using StrategyDp.Common.Models;
using StrategyDp.Common.Providers;
using StrategyDp.Strategies.Contexts;
using StrategyDp.Strategies.Implementations;
using StrategyDp.Strategies.Interfaces;

namespace StrategyDp.Endpoints;

public class RouteEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/routes")
            .WithTags("Routes");

        group.MapGet("", GetRoutesAsync);
        group.MapPost("/calculate", CalculateRouteAsync);
    }

    private static Task<IResult> GetRoutesAsync()
    {
        var routes = RouteDataProvider.GetRoutes();
        return Task.FromResult(Results.Ok(routes));
    }

    private static async Task<IResult> CalculateRouteAsync(CalculateRouteRequest request, IServiceProvider serviceProvider)
    {
        IRouteService routeService = request.RouteType switch
        {
            RouteType.Car => serviceProvider.GetRequiredService<CarRouteService>(),
            RouteType.Bicycle => serviceProvider.GetRequiredService<BicycleRouteService>(),
            RouteType.Foot => serviceProvider.GetRequiredService<FootRouteService>(),
            _ => throw new NotImplementedException()
        };

        var routeStrategyContext = serviceProvider.GetRequiredService<RouteStrategyContext>();
        routeStrategyContext.SetRouteStrategy(routeService);
        var route = await routeStrategyContext.CalculateRoute(request);
        return Results.Ok(route);
    }
}