using Unity;

namespace EasyLOB
{
    public class DIManagerUnity : IDIManager
    {
        #region Fields

        private IUnityContainer _container;

        #endregion Fields

        #region Methods

        public DIManagerUnity(IUnityContainer container)
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