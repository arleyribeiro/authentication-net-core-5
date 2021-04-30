namespace Authentication.Repositories.Interfaces
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}