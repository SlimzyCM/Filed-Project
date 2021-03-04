using System;

namespace PPayment.Domain.Entities
{
    public class PaymentState
    {
        public string Id { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
