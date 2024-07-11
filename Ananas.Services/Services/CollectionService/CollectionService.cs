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
using static Ananas.Core.OutputDataAccess.CollectionDto;
using static Ananas.Core.OutputDataAccess.StyleDto;
using static Ananas.Services.Services.CollectionService.CollectionServiceOutputDto;
using static Ananas.Services.Services.StyleService.SyleServiceOutputDto;

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
        public async Task<SetCollectionsByNameOutputDtoService> GetCollectionsByName(GetCollectionsByNameInputDtoService inputDto)
        {
            try
            {
                if (inputDto.Name == null)
                {
                    throw new ArgumentNullException(nameof(inputDto.Name));
                }
                var input = new InputSetCollectionsDto();
                input.Name = inputDto.Name;
                var collections = await _unitOfWork.Collections.GetByName(input);
                var listoutput = new SetCollectionsByNameOutputDtoService();
                foreach (var collection in collections.CollectionList1)
                {
                    var item = new CollectionListDto();
                    item.Name = collection.Name;
                    item.CollectionId = collection.CollectionId;
                    item.Slug = collection.Slug;
                    listoutput.collections.Add(item);
                }


                return listoutput;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
