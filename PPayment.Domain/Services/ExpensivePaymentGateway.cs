using PPayment.Domain.Interfaces;

namespace PPayment.Domain.Services
{
    public class ExpensivePaymentGateway : BasePaymentGateway, IExpensivePaymentGateway
    {
        public ExpensivePaymentGateway(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
