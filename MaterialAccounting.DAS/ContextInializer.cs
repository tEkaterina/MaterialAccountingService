using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialAccounting.DAS
{
    internal class ContextInializer : DropCreateDatabaseIfModelChanges<MaterialDbContext>
    {

    }
}
