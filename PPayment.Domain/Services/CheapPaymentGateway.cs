using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    public class CheapPaymentGateway : BasePaymentGateway, ICheapPaymentGateway
    {
        public CheapPaymentGateway(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
