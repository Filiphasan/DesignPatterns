namespace DecoratorDp.EndpointFilters;

public class SimpleFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        Console.WriteLine("Simple Filter started");
        var result = await next(context);
        Console.WriteLine("Simple Filter ended");
        return result;
    }
}