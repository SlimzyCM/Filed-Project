using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Entities;
using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    /// <summary>
    /// method to implement the cheap payment gateway service
    /// </summary>
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private readonly IPaymentRepository _paymentRepo;

        public CheapPaymentGateway(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        public async Task<Response<Payment>> Process(Payment payment)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
