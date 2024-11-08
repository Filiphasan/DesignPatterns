using Carter;
using Microsoft.AspNetCore.Mvc;
using SingletonDp.Common.Models;
using SingletonDp.Singletons;

namespace SingletonDp.Endpoints;

public class CacheEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/cache")
            .WithTags("Cache");
        
        group.MapPost("/set", SetAsync)
            .WithName("Set")
            .Produces(200);

        group.MapGet("/get", GetAsync)
            .WithName("Get")
            .Produces(200);
    }
    
    private static Task<IResult> SetAsync([FromBody] SetCacheRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Key))
        {
            return Task.FromResult(Results.BadRequest());
        }

        MemCacheService.Instance.Set(request.Key, request.Value);
        return Task.FromResult(Results.Ok());
    }
    
    private static Task<IResult> GetAsync([FromQuery] string key)
    {
        var value = MemCacheService.Instance.Get<string>(key);
        return Task.FromResult(Results.Ok(value));
    }
}