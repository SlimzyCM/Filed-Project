using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Entities;
using PPayment.Domain.Enums;
using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    /// <summary>
    /// method to implement the cheap payment gateway service
    /// </summary>
    public abstract class BasePaymentGateway : IPaymentGateway
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BasePaymentGateway(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Payment>> Process(Payment payment)
        {

            await _unitOfWork.PaymentRepository.Save(payment);

            return new Response<Payment>
            {
                Status = PaymentStatus.pending.ToString(),
                Data = payment
            };
        }

        public async Task<Payment> Update(string id)
        {
            return await _unitOfWork.PaymentRepository.UpdatePayment(id);
        }
    }
}
