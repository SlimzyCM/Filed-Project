using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPayment.Domain.Interfaces;
using PPayment.Infrastructure.Data;

namespace PPayment.Infrastructure.Repository
{
    /// <summary>
    /// abstract repository
    /// </summary>
    /// <typeparam name="TModel">Generic class</typeparam>
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DataContext Context;

        protected Repository(DataContext context)
        {
            Context = context;
        }

        public async Task<TModel> Get(string id)
        {
            return await Context.Set<TModel>().FindAsync(id);
            
        }

        public async Task Save(TModel entity)
        {
            if (entity != null)
            {
                await Context.Set<TModel>().AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await Context.Set<TModel>().ToListAsync();
        }
    }
}
