using System;

namespace MaterialAccounting.Common.IoC
{
    public interface IContainer
    {
        IContainer RegisterInstance<T>(T entity);
        IContainer RegisterType<T1, T2>() where T2: T1;
        IContainer RegisterType(Type t1, Type t2);

        T Resolve<T>();
    }
}
