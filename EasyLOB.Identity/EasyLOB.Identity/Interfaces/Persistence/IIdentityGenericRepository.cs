namespace EasyLOB.Identity
{
    public interface IIdentityGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}