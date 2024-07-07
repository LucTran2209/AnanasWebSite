using Ananas.Core.Models;
using Ananas.Services.Services.CollectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetAll();
        Task<bool> Create(CollectionCreateInputDto collectionDto);
        Task<bool> Update(CollectionUpdateInputDto collectionDto);
        Task<List<CollectionGetByNameOutputDto>> GetByName(string name);
    }
}
