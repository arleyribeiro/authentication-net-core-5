using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Repositories;

namespace Authentication.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryAsync<TEntity> repository;
        public ServiceBase(IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync().ConfigureAwait(false);
        }
    }
}