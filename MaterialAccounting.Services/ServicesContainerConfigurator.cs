using MaterialAccounting.Common.IoC;
using MaterialAccounting.DAS;
using MaterialAccounting.Services.Inerfaces;

namespace MaterialAccounting.Services
{
    public class ServicesContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            new DasContainerConfigurator().Configure(container);
            container
                .RegisterType<IDetailService, DetailService>()
                .RegisterType<IDetailTypeService, DetailTypeService>();
        }
    }
}
