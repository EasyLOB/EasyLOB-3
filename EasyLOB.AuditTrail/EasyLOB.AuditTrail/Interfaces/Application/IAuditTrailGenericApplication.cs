using EasyLOB.Data;

namespace EasyLOB.AuditTrail
{
    public interface IAuditTrailGenericApplication<TEntity> : IGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}