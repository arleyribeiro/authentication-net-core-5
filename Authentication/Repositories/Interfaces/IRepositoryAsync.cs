using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Repositories.Interfaces
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}