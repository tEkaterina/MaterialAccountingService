using MaterialAccounting.Common.IoC;
using MaterialAccounting.DAS.Interfaces;

namespace MaterialAccounting.DAS
{
    public class DasContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container
                .RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
