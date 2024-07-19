using Carter;
using DecoratorDp.Common.Models;
using DecoratorDp.Decorators;
using DecoratorDp.Decorators.Interfaces;

namespace DecoratorDp.Endpoints;

public class CoffeeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/coffee")
            .WithTags("Coffee");

        group.MapPost("/", GetCoffeeAsync);
    }

    private static Task<IResult> GetCoffeeAsync(CreateCoffeeRequest request)
    {
        ICoffee coffee = new BasicCoffee();
        if (request.HasMilk)
        {
            coffee = new MilkCoffeeDecorator(coffee);
        }

        if (request.HasChocolate)
        {
            coffee = new ChocolateCoffeeDecorator(coffee);
        }

        return Task.FromResult(Results.Ok(coffee.GetCoffeeInfo()));
    }
}