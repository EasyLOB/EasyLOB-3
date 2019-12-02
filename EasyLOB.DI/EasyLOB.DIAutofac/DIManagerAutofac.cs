using Autofac;

namespace EasyLOB
{
    public class DIManagerAutofac : IDIManager
    {
        #region Fields

        private IContainer _container;

        #endregion Fields

        #region Methods

        public DIManagerAutofac(IContainer container)
        {
            _container = container;
        }

        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }

        #endregion
    }
}