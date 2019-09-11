using EasyLOB.Data;

namespace EasyLOB.AuditTrail
{
    public interface IAuditTrailGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}