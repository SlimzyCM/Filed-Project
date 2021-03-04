using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.DTOs;

namespace PPayment.Domain.Entities
{
    public class Payment : PaymentDto
    {
        public string Id { get; set; }
        public string PaymentStateId { get; set; }
        public PaymentState PaymentState { get; set; }

    }
}
