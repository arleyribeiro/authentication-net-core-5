namespace Authentication.Repositories
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}