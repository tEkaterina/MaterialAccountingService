using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialAccounting.Common.IoC
{
    public interface IContainerConfigurator
    {
        void Configure(IContainer container);
    }
}
