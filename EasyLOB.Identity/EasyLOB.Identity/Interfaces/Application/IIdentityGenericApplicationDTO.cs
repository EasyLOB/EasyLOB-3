namespace EasyLOB.Identity
{
    public interface IIdentityGenericApplicationDTO<TEntityDTO, TEntity> : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
    }
}