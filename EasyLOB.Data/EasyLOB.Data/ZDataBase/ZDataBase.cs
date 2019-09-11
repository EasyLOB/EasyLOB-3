using EasyLOB.Library;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLOB.Data
{
    public abstract class ZDataBase : IZDataBase, INotifyPropertyChanged
    {
        #region Properties

        private string _lookupText; // AutoMapper

        [JsonIgnore] // Newtonsoft.Json
        [NotMapped] // MongoDB
        public virtual string LookupText
        {
            get
            {
                string result = "";

                Type entityType = this.GetType();
                IZProfile profile = DataHelper.GetProfile(entityType);
                if (!String.IsNullOrEmpty(profile.Lookup))
                {
                    try
                    {
                        var value = LibraryHelper.GetPropertyValue(this, profile.Lookup);
                        result = value == null ? "" : value.ToString();
                    }
                    catch { }
                }

                return result;
            }
            set
            {
                _lookupText = value; // AutoMapper
            }
        }

        #endregion Properties

        #region Methods

        public virtual object[] GetId()
        {
            throw new NotImplementedException();
        }

        public virtual void OnConstructor()
        {
        }

        public virtual void SetId(object[] ids)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        #region Triggers

        public virtual bool BeforeCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        #endregion Triggers

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}