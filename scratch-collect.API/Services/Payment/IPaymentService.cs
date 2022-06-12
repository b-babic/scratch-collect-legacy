using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Services
{
    public interface IPaymentService
    {
       public PaymentDetailsDTO ProcessPayment(PaymentBuyRequest request);
    }
}