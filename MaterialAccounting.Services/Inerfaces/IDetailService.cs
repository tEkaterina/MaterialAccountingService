using System.Collections.Generic;

namespace MaterialAccounting.Services.Inerfaces
{
    public interface IDetailService
    {
        void CreateNewDetail(Detail detailInfo);
        void RemoveDetail(long id);
        void UpdateDetail(Detail detailInfo);
        IEnumerable<Detail> GetAll();
        Detail GetById(long id);
    }
}
