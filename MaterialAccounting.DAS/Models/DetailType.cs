using System.Collections.Generic;

namespace MaterialAccounting.DAS.Models
{
    public class DetailType : Model
    {
        public string TypeName { get; set; }

        public IEnumerable<Detail> Details { get; set; }
    }
}
