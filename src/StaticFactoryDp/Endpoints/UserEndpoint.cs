using Carter;
using StaticFactoryDp.Common.Constants;
using StaticFactoryDp.Common.Models;
using StaticFactoryDp.StaticFactories;

namespace StaticFactoryDp.Endpoints;

public class UserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users");
        
        group.MapPost("", CreateUserAsync);
    }

    private static Task<IResult> CreateUserAsync(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            var result = GenericResponse<User>.Fail(StatusCodeConstant.BadRequest, MessageConstant.User.CreatedError);
            return Task.FromResult(Results.Json(result, statusCode: result.StatusCode));
        }

        var user = User.Create(request.Name, request.LastName, request.Email);
        return Task.FromResult(Results.Ok(GenericResponse<User>.Success(user)));
    }
}