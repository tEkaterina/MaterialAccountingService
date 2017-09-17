namespace MaterialAccounting.Common.IoC
{
    public class ServiceLocator
    {
        public IContainer Container { get; private set; }

        public ServiceLocator()
        {
            Container = new Container();
        }
    }
}
