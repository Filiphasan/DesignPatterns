using FactoryDp.Common.Models;

namespace FactoryDp.Services.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponseModel> HandlePaymentAsync();
}