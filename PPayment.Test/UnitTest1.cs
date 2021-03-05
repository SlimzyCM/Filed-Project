using System;
using System.Threading.Tasks;
using Moq;
using PPayment.Domain.DTOs;
using PPayment.Domain.Entities;
using PPayment.Domain.Enums;
using PPayment.Domain.Interfaces;
using PPayment.Domain.Services;
using Xunit;

namespace PPayment.Test
{
    public class UnitTest1
    {

        [Fact]
        public async Task Use_Premium_Payment_Gateway()
        {
            var cheapPayment = new Mock<ICheapPaymentGateway>();
            var expensivePayment = new Mock<IExpensivePaymentGateway>();
            var premiumPayment = new Mock<IPremiumPaymentGateway>();

            var paymentDto = new PaymentDto()
            {
                CardHolder = "Oche Ijeh",
                CardNumber = "4024007186270533",
                ExpirationDate = DateTime.Now.AddYears(1),
                SecurityCode = "123",
                Amount = 900,


            };

            var payment = new Payment()
            {
                Amount = paymentDto.Amount,
                CardHolder = paymentDto.CardHolder,
                CardNumber = paymentDto.CardNumber,
                ExpirationDate = paymentDto.ExpirationDate,
                Id = new Guid().ToString(),
                
                PaymentState = new PaymentState()
                {
                    Id = new Guid().ToString(),
                    State = PaymentStatus.pending.ToString(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };


            premiumPayment.Setup(x => x.Process(payment));

            payment.PaymentState.State = PaymentStatus.processed.ToString();

            premiumPayment.Setup(x => x.Update(payment.Id)).ReturnsAsync(payment);

            var service = new PaymentService(cheapPayment.Object, expensivePayment.Object, premiumPayment.Object);

            var response = await service.ProcessPayment(payment);

            Assert.Equal("processed", response.Status);

            cheapPayment.Verify(x => x.Process(payment), Times.Never);
        }


    }


}

