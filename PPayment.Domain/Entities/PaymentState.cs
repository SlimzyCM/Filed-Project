using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Enums;

namespace PPayment.Domain.Entities
{
    public class PaymentState
    {
        public string Id { get; set; }
        public string State { get; set; } = PaymentStatus.pending.ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
