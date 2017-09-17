using MaterialAccounting.DAS.Interfaces;
using MaterialAccounting.DAS.Models;
using MaterialAccounting.Services.Inerfaces;
using System.Collections.Generic;
using System.Linq;

namespace MaterialAccounting.Services
{
    internal class DetailTypeService : IDetailTypeService
    {
        private readonly IRepository<DetailType> _repository;

        public DetailTypeService(IRepository<DetailType> repository)
        {
            _repository = repository ??
                throw new ArgumentNullExcpetion("repository");
        }

        public DetailType Add(string newType)
        {
            var detailType = new DetailType
            {
                TypeName = newType
            };
            _repository.Add(detailType);
            return detailType;
        }

        public IEnumerable<string> GetAllNames()
        {
            return _repository.GetAll()
                .Select(x => x.TypeName);
        }
    }
}
