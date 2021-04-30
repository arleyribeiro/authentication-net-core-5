using System.Data;
using Authentication.Repositories.Interfaces;

namespace Authentication.Repositories
{
    public abstract class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                                      IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(IDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        protected DomainRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}