using EasyLOB.Data;
using System;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// IGenericRepository Extensions.
    /// </summary>
    public static class IGenericRepositoryExtensions
    {
        /// <summary>
        /// Get repository type.
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <param name="_"></param>
        /// <returns>Type</returns>
        public static Type GetRepositoryType<TEntity>(this IGenericRepository<TEntity> _)
            where TEntity : class, IZDataBase
        {
            return typeof(TEntity);
        }

        /// <summary>
        /// Get repository type.
        /// </summary>
        /// <typeparam name="TEntityDTO">Entity</typeparam>
        /// <typeparam name="TEntity">Entity DTO</typeparam>
        /// <param name="_"></param>
        /// <returns>Type</returns>
        public static Type GetRepositoryType<TEntityDTO, TEntity>(this IGenericRepositoryDTO<TEntityDTO, TEntity> _)
            where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
            where TEntity : class, IZDataBase
        {
            return typeof(TEntityDTO);
        }
    }
}