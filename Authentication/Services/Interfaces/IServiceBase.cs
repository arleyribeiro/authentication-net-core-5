using System.Threading.Tasks;
using System.Collections.Generic;

namespace Authentication.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}