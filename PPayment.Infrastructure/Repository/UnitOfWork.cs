using PPayment.Domain.Interfaces;
using PPayment.Infrastructure.Data;

namespace PPayment.Infrastructure.Repository
{
    /// <summary>
    /// Unit of work for all implemented repository
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IPaymentRepository PaymentRepository => new PaymentRepository(_context);
        
    }
}
