using Carter;
using Microsoft.AspNetCore.Mvc;
using SingletonDp.Singletons;

namespace SingletonDp.Endpoints;

public class DbConnectionPoolEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/db-connection-pools")
            .WithTags("DbConnectionPool");

        group.MapGet("", GetAsync);
    }
    
    private static Task<IResult> GetAsync()
    {
        var value = DatabaseConnectionPool.Instance.Get();
        return Task.FromResult(Results.Ok());
    }
}