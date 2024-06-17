using scratch_collect.Model;
using scratch_collect.Model.Requests;

namespace scratch_collect.API.Services
{
    public interface IPaymentService
    {
        public PaymentDetailsDTO ProcessPayment(PaymentBuyRequest request);
    }
}
