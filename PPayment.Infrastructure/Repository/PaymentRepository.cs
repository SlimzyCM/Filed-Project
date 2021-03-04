using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPayment.Domain.Entities;
using PPayment.Domain.Enums;
using PPayment.Domain.Interfaces;
using PPayment.Infrastructure.Data;

namespace PPayment.Infrastructure.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> UpdatePayment(string id)
        {
            //find the payment with id
            var entity = await _context.Payments.Where(x => x.Id == id)
                .Include(x => x.PaymentState).FirstOrDefaultAsync();
            
            if (entity is null) return null;
            
            entity.PaymentState.State = PaymentStatus.processed.ToString();
            
            _context.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
