using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity
{
    public interface IActivityGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}