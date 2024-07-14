using AdapterDp.Adapters.Interfaces;
using AdapterDp.Services.Interfaces;
using Carter;

namespace AdapterDp.Endpoints;

public class UserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users");

        group.MapGet("/xml", GetUsersXmlAsync);
        group.MapGet("/json", GetUsersJsonAsync);
    }

    private static async Task<IResult> GetUsersXmlAsync(IUserService userService)
    {
        var users = await userService.GetUsers();
        return Results.Ok(users);
    }

    private static async Task<IResult> GetUsersJsonAsync(IUserAdapterService userAdapterService)
    {
        var users = await userAdapterService.GetUsers();
        return Results.Ok(users);
    }
}