using FactoryDp.Common.Enums;
using FactoryDp.Services.Implementations;
using FactoryDp.Services.Interfaces;

namespace FactoryDp.Services.Factories;

public class PaymentServiceFactory(IServiceProvider serviceProvider)
    : IPaymentServiceFactory
{
    public IPaymentService GetPaymentService(PaymentBankType paymentBankType)
    {
        return paymentBankType switch
        {
            PaymentBankType.YapiKredi => serviceProvider.GetRequiredService<YapiKrediPaymentService>(),
            PaymentBankType.IsBankasi => serviceProvider.GetRequiredService<IsBankasiPaymentService>(),
            PaymentBankType.Garanti => serviceProvider.GetRequiredService<GarantiPaymentService>(),
            PaymentBankType.Akbank => serviceProvider.GetRequiredService<AkbankPaymentService>(),
            _ => throw new InvalidOperationException("Invalid payment bank type")
        };
    }
}