using AdapterDp.Adapters.Implementations;
using AdapterDp.Adapters.Interfaces;
using AdapterDp.Services.Implementations;
using AdapterDp.Services.Interfaces;

namespace AdapterDp;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserAdapterService, UserAdapterService>();
    }
}