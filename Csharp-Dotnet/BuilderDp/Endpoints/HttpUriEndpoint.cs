using BuilderDp.Builders;
using BuilderDp.Common.Models;
using Carter;

namespace BuilderDp.Endpoints;

public class HttpUriEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/http-uri")
            .WithTags("HttpUri");
        
        group.MapPost("/uri", GetHttpUriAsync);
    }
    
    private static Task<IResult> GetHttpUriAsync(GetHttpUriRequest request)
    {
        var httpUriBuilder = new HttpUriBuilder(request.BaseUrl);
        foreach (var pathParam in request.PathParams)
        {
            httpUriBuilder.AppendPath(pathParam);
        }

        foreach (var queryParam in request.QueryParams)
        {
            httpUriBuilder.AppendQueryParam(queryParam.Key, queryParam.Value);
        }
        return Task.FromResult(Results.Ok(httpUriBuilder.Build()));
    }
}