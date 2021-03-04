using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPayment.Domain.Interfaces
{
    public interface IRepository<TModel> where TModel: class
    {
        Task<TModel> Get(string id);
        Task Save(TModel entity);
        Task<IEnumerable<TModel>> GetAll();

    }
}
