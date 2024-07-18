using OptionsDp.Common.Options;

namespace OptionsDp;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RuntimeSettingOptiponModel>(configuration.GetSection(RuntimeSettingOptiponModel.SectionName));
    }
}