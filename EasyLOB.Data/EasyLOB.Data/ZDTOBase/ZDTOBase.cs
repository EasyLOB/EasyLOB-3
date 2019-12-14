using AutoMapper;
using EasyLOB.Library;

namespace EasyLOB.Data
{
    public abstract class ZDTOBase<TEntityDTO, TEntity> : IZDTOBase<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Properties

        public virtual string LookupText { get; set; }

        #endregion Properties

        #region Methods

        public virtual void FromData(IZDataBase dataModel)
        {
            if (dataModel != null)
            {
                LibraryHelper.Clone<TEntityDTO>(DIHelper.Mapper.Map<TEntityDTO>(dataModel as TEntity), this);
            }
        }

        public virtual void OnConstructor()
        {
        }

        public virtual IZDataBase ToData()
        {
            return DIHelper.Mapper.Map<TEntity>(this);
        }

        #endregion Methods
    }
}