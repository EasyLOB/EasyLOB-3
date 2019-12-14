using AutoMapper;
using EasyLOB.Library;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ModelState.IsValid vs IValidateableObject in MVC3
// http://stackoverflow.com/questions/3744408/modelstate-isvalid-vs-ivalidateableobject-in-mvc3
// Validation using the DefaultModelBinder is a two stage process.
// First, Data Annotations are validated.
// Then (and only if the data annotations validation resulted in zero errors), IValidatableObject.Validate() is called.
// This all takes place automatically when your post action has a viewmodel parameter.ModelState.IsValid doesn't do anything as such.
// Rather it just reports whether any item in the ModelState collection has non-empty ModelErrorCollection.

namespace EasyLOB.Data
{
    public abstract class ZViewBase<TEntityView, TEntity> : IZViewBase<TEntityView, TEntity>, IValidatableObject, IZValidatableObject
        where TEntityView : class, IZViewBase<TEntityView, TEntity>
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
                LibraryHelper.Clone<TEntityView>(DIHelper.Mapper.Map<TEntityView>(dataModel as TEntity), this);
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

        #region Methods Validate

        public virtual IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext) // IValidatableObject
        {
            return new List<ValidationResult>();
        }

        public virtual bool Validate(ZOperationResult operationResult) // IZValidatableObject
        {
            return true;
        }

        #endregion Methods Validate
    }
}