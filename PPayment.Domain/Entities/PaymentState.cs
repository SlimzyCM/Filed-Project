using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPayment.Domain.Entities
{
    public class PaymentState
    {
        public string Id { get; set; }
        public string State { get; set; } = "pending";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
