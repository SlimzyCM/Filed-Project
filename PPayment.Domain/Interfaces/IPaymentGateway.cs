using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Entities;

namespace PPayment.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        Task<Response<Payment>> Process(Payment payment);

        Task<Payment> Update(string id);
    }
}
