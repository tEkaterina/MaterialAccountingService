using MaterialAccounting.Common.IoC;
using MaterialAccounting.Services;

namespace MaterialAccounting.WebApi
{
    public static class Bootstrapper
    {
        private static ServiceLocator _locator;

        static Bootstrapper()
        {
            _locator = new ServiceLocator();
            new ServicesContainerConfigurator().Configure(_locator.Container);
        }

        public static T Resolve<T>()
        {
            return _locator.Container.Resolve<T>();
        }
    }
}