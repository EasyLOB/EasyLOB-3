using EasyLOB.Data;

namespace EasyLOB.Activity
{
    public interface IActivityGenericApplication<TEntity> : IGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}