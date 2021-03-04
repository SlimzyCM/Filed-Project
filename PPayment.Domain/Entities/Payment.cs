using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPayment.Domain.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStateId { get; set; }
        public PaymentState PaymentState { get; set; }

    }
}
