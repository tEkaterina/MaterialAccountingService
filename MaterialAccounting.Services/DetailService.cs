using ServiceModel = MaterialAccounting.Services.Models;
using System;
using DasModel = MaterialAccounting.DAS.Models;
using System.Linq;
using MaterialAccounting.DAS.Interfaces;
using System.Collections.Generic;
using MaterialAccounting.Common.Exceptions;
using MaterialAccounting.Services.Inerfaces;

namespace MaterialAccounting.Services
{
    internal class DetailService : IDetailService
    {
        private readonly IRepository<DasModel.Detail> _detailRepository;
        private readonly IRepository<DasModel.DetailType> _detailTypeRepository;
        private readonly IDetailTypeService _typeService;


        public DetailService(IRepository<DasModel.Detail> detailRepository,
            IRepository<DasModel.DetailType> detailTypeRepository, IDetailTypeService typeService)
        {
            _detailRepository = detailRepository ?? 
                throw new ArgumentNullException("detailRepository");

            _detailTypeRepository = detailTypeRepository ?? 
                throw new ArgumentNullException("detailTypeRepository");

            _typeService = typeService ??
                throw new ArgumentNullException("typeService");
        }
        
        public void CreateNewDetail(ServiceModel.Detail detailInfo)
        {
            if (detailInfo == null)
            {
                throw new ArgumentNullException("detailInfo");
            }
            if (string.IsNullOrEmpty(detailInfo.TypeName))
            {
                throw new ArgumentException("Type name for a new detail cannot be null or empty");
            }
            if (string.IsNullOrEmpty(detailInfo.Name))
            {
                throw new ArgumentException("The property name for a new detail cannot be null or empty");
            }

            DasModel.DetailType detailType = FindOrAddDetailType(detailInfo.TypeName);

            DasModel.Detail detailToAdd = new DasModel.Detail
            {
                Name = detailInfo.Name,
                DetailType = detailType
            };
            _detailRepository.Add(detailToAdd);
        }

        public IEnumerable<ServiceModel.Detail> GetAll()
        {
            return _detailRepository
                .GetAll()
                .Select(x => new ServiceModel.Detail
                {
                    Name = x.Name,
                    TypeName = x.DetailType?.TypeName
                });
        }

        public ServiceModel.Detail GetById(long id)
        {
            DasModel.Detail detail = _detailRepository.GetById(id);
            return new ServiceModel.Detail
            {
                Name = detail.Name,
                TypeName = detail.DetailType?.TypeName
            };
        }

        public void RemoveDetail(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            DasModel.Detail detailToRemove = _detailRepository.GetAll()
                .FirstOrDefault(x => x.Id.Equals(id));

            if (detailToRemove == null)
            {
                throw new ArgumentException("Cannot find a model with provided Id");
            }
            _detailRepository.Remove(detailToRemove);

        }

        public void UpdateDetail(ServiceModel.Detail detailInfo)
        {
            if (detailInfo == null)
            {
                throw new ArgumentNullException("detailInfo");
            }
            if (string.IsNullOrEmpty(detailInfo.TypeName))
            {
                throw new ArgumentException("Type name for a new detail cannot be null or empty");
            }
            if (string.IsNullOrEmpty(detailInfo.Name))
            {
                throw new ArgumentException("The property name for a new detail cannot be null or empty");
            }

            DasModel.Detail dbDetail = _detailRepository.GetById(detailInfo.Id);
            if (dbDetail == null)
            {
                throw new IdNotExistsException(detailInfo.Id);
            }

            dbDetail.Name = detailInfo.Name;

            if (!dbDetail.DetailType.TypeName
                .Equals(detailInfo.TypeName, StringComparison.InvariantCultureIgnoreCase))
            {
                dbDetail.DetailType = FindOrAddDetailType(detailInfo.TypeName);
            }

            _detailRepository.Update(dbDetail);
        }

        private DasModel.DetailType FindOrAddDetailType(string type)
        {
            DasModel.DetailType detailType = _detailTypeRepository.GetAll()
                .FirstOrDefault(x => x.TypeName.Equals(type));

            if (detailType == null)
            {
                detailType = _detailTypeRepository.GetRemoved()
                    .FirstOrDefault(x => x.TypeName.Equals(type, StringComparison.InvariantCultureIgnoreCase));

                if (detailType == null)
                {
                    detailType = _typeService.Add(type);
                }
                else
                {
                    _detailTypeRepository.Restore(detailType);
                }
            }
            
            return detailType;
        }
    }
}
