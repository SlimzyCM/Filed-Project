using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPayment.Domain.Entities;

namespace PPayment.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var payment = modelBuilder.Entity<Payment>();
            payment.HasKey(p => p.Id);
            payment.Property(prop => prop.CardNumber).IsRequired();
            payment.Property(prop => prop.SecurityCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();
            payment.Property(prop => prop.Amount).IsRequired();
           

        }
    }
}
