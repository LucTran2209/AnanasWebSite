using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.CollectionDto;

namespace Ananas.Core.Interfaces
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        Task<SetCollectionsNameOutputDto> GetByName(InputSetCollectionsDto InputnameCollection);
        Task<bool> UpdateCollection(Collection collection);
        new Task<Collection> GetById(int id);
    }
}
