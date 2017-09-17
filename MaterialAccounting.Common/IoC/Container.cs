using System;
using Microsoft.Practices.Unity;

namespace MaterialAccounting.Common.IoC
{
    internal class Container : IContainer
    {
        private UnityContainer _container;

        public Container()
        {
            _container = new UnityContainer();
        }

        public IContainer RegisterInstance<T>(T entity)
        {
            _container.RegisterInstance(entity);
            return this;
        }

        public IContainer RegisterType<T1, T2>() where T2 : T1
        {
            _container.RegisterType<T1, T2>();
            return this;
        }

        public IContainer RegisterType(Type t1, Type t2)
        {
            _container.RegisterType(t1, t2);
            return this;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
