using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.CollectionService
{
    public class CollectionService : BaseService, ICollectionService
    {
        public CollectionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Collection>> GetAll()
        {
            try
            {
                var collectionList = await _unitOfWork.Collections.GetAll();
                return (IEnumerable<Collection>)collectionList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(CollectionCreateInputDto collectionDto)
        {
            try
            {
                var collection = _mapper.Map<Collection>(collectionDto);
                await _unitOfWork.Collections.Add(collection);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(CollectionUpdateInputDto collectionDto)
        {
            try
            {
                var collection = _mapper.Map<Collection>(collectionDto);
                var updated = await _unitOfWork.Collections.UpdateCollection(collection);
                return updated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CollectionGetByNameOutputDto>> GetByName(string name)
        {
            try
            {
                var collections = await _unitOfWork.Collections.GetByName(name);
                return _mapper.Map<List<CollectionGetByNameOutputDto>>(collections);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
