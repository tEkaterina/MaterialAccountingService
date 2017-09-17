using MaterialAccounting.DAS.Models;
using System.Collections.Generic;

namespace MaterialAccounting.Services.Inerfaces
{
    public interface IDetailTypeService
    {
        DetailType Add(string newType);
        IEnumerable<string> GetAllNames();
    }
}
