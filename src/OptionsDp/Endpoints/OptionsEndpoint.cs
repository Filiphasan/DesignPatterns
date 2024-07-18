using Carter;
using Microsoft.Extensions.Options;
using OptionsDp.Common.Options;

namespace OptionsDp.Endpoints;

public class OptionsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/options")
            .WithTags("Options");

        group.MapGet("", GetOptionAsync);
    }

    private static Task<IResult> GetOptionAsync(IOptions<RuntimeSettingOptiponModel> options)
    {
        var model = options.Value;
        return Task.FromResult(Results.Ok(model));
    }
}