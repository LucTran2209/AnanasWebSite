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
                return collectionList;
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
