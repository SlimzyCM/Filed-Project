namespace PPayment.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPaymentRepository PaymentRepository { get; }
    }
}
