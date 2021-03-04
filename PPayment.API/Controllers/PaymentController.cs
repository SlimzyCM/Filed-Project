using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PPayment.Domain.DTOs;
using PPayment.Domain.Entities;
using PPayment.Domain.Enums;
using PPayment.Domain.Interfaces;
using PPayment.Domain.Services;

namespace PPayment.API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;

        public PaymentController(ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            IPremiumPaymentGateway premiumPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPaymentGateway = premiumPaymentGateway;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto model)
        {
            var service = new PaymentService(_cheapPaymentGateway, _expensivePaymentGateway, _premiumPaymentGateway);

            var payment = new Payment
            {
                Id = Guid.NewGuid().ToString(),
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CardNumber = model.CardNumber,
                ExpirationDate = model.ExpirationDate,
                SecurityCode = model.SecurityCode,
                
                PaymentState = new PaymentState
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }

            };
            var response = await service.ProcessPayment(payment);

            if (response.Status != PaymentStatus.processed.ToString()) return BadRequest(response);
           
            return Ok(response);

        }
    }
}
