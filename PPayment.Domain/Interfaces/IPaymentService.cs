using System.Threading.Tasks;
using PPayment.Domain.Entities;

namespace PPayment.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<Payment>> ProcessPayment(Payment payment);

    }
}
