using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPayment.Domain.Interfaces;
using PPayment.Domain.Services;
using PPayment.Infrastructure.Data;
using PPayment.Infrastructure.Repository;

namespace PPayment.API.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            
            services.AddScoped<IPremiumPaymentGateway, PremiumPaymentGateway>();


            //Add Database connection
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
