using FactoryDp.Common.Enums;

namespace FactoryDp.Services.Interfaces;

public interface IPaymentServiceFactory
{
    IPaymentService GetPaymentService(PaymentBankType paymentBankType);
}