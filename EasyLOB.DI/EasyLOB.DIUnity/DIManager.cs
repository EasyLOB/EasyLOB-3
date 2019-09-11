using Unity;

namespace EasyLOB
{
    public class DIManager : IDIManager
    {
        #region Fields

        private IUnityContainer _container;

        #endregion Fields

        #region Methods

        public DIManager(IUnityContainer container)
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