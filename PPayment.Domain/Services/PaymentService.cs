using System.Threading.Tasks;
using PPayment.Domain.Entities;
using PPayment.Domain.Enums;
using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;

        public PaymentService(ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentGateway premiumPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
        }
        public async Task<Response<Payment>> ProcessPayment(Payment payment)
        {
            var paymentDetails = new Payment();

            if (payment.Amount < 20)
            {
                await _cheapPaymentGateway.Process(payment);
                
                paymentDetails = await _cheapPaymentGateway.Update(payment.Id);
                
                var response = new Response<Payment>
                {
                    Data = paymentDetails, 
                    Status = paymentDetails.PaymentState.State
                };

                if (response.Status == PaymentStatus.processed.ToString()) return response;

            }

            else if (payment.Amount > 21 && payment.Amount <= 500)
            {
                if (_expensivePaymentGateway is null)
                {
                    await _cheapPaymentGateway.Process(payment);
                    
                    paymentDetails = await _cheapPaymentGateway.Update(payment.Id);

                    var response = new Response<Payment>
                    {
                        Data = paymentDetails,
                        Status = paymentDetails.PaymentState.State
                    };

                    if (response.Status == PaymentStatus.processed.ToString()) return response;
                }
                else
                {
                    await _expensivePaymentGateway.Process(payment);
                    
                    paymentDetails = await _expensivePaymentGateway.Update(payment.Id);
                    
                    var response = new Response<Payment>
                    {
                        Data = paymentDetails,
                        Status = paymentDetails.PaymentState.State
                    };

                    if (response.Status == PaymentStatus.processed.ToString()) return response;

                }
            }

            else if (payment.Amount > 500)
            {
                var i = 0;

                while (i < 3)
                {
                    await _premiumPaymentGateway.Process(payment);
                    
                    paymentDetails = await _premiumPaymentGateway.Update(payment.Id);
                    
                    var response = new Response<Payment>
                    {
                        Data = paymentDetails,
                        Status = paymentDetails.PaymentState.State
                    };

                    if (response.Status == PaymentStatus.processed.ToString()) return response;

                    i++;
                }
            }

            return new Response<Payment>
            {
                Data = paymentDetails,
                Status = PaymentStatus.failed.ToString()
            };



        }
    }
}
