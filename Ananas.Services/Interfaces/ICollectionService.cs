using Ananas.Core.Models;
using Ananas.Services.Services.CollectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ananas.Services.Services.CollectionService.CollectionServiceOutputDto;

namespace Ananas.Services.Interfaces
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetAll();
        Task<bool> Create(CollectionCreateInputDto collectionDto);
        Task<bool> Update(CollectionUpdateInputDto collectionDto);
        Task<SetCollectionsByNameOutputDtoService> GetCollectionsByName(GetCollectionsByNameInputDtoService name);
    }
}
