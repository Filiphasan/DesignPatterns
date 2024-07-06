using FactoryDp.Services.Factories;
using FactoryDp.Services.Implementations;
using FactoryDp.Services.Interfaces;

namespace FactoryDp;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentServiceFactory, PaymentServiceFactory>();
        services.AddScoped<YapiKrediPaymentService>();
        services.AddScoped<IsBankasiPaymentService>();
        services.AddScoped<GarantiPaymentService>();
        services.AddScoped<AkbankPaymentService>();

        services.AddScoped<INotificationFactoryService, NotificationFactoryService>();
        services.AddScoped<SmsNotificationService>();
        services.AddScoped<EmailNotificationService>();
        services.AddScoped<WhatsappNotificationService>();
        services.AddScoped<CallNotificationService>();

        return services;
    }
}

