using Carter;
using DecoratorDp.EndpointFilters;

namespace DecoratorDp.Endpoints;

public class SimpleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/simple")
            .WithTags("Simple");
        
        group.MapPost("/", () => "Hello from Simple Endpoint")
            .AddEndpointFilter<SimpleFilter>();
    }
}