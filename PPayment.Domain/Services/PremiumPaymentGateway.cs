using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    public class PremiumPaymentGateway : BasePaymentGateway, IPremiumPaymentGateway
    {
        public PremiumPaymentGateway(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
