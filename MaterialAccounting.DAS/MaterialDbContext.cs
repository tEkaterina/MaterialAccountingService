using MaterialAccounting.DAS.Models;
using System.Data.Entity;

namespace MaterialAccounting.DAS
{
    internal class MaterialDbContext : DbContext
    {
        static MaterialDbContext()
        {
            Database.SetInitializer(new ContextInializer());
        }

        public MaterialDbContext()
            : base("MaterialAccountingConnection")
        {

        }

        DbSet<Detail> Details { get; set; }
        DbSet<DetailType> DetailTypes { get; set; }
    }
}
