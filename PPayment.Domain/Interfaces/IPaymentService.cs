using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Entities;

namespace PPayment.Domain.Interfaces
{
    internal interface IPaymentService
    {
        Task<Response<Payment>> ProcessPayment(Payment payment);

    }
}
