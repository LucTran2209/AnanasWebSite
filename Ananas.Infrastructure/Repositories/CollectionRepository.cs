using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Repositories
{
    public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
    {
        public CollectionRepository(AnanasDbContext context) : base(context)
        {
        }

        public override Task Add(Collection entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Collection entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Collection>> GetAll()
        {
            try
            {
                var collectionList = await _dbContext.Collections.ToListAsync();
                return collectionList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override Task<Collection> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Collection>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Collection entity)
        {
            throw new NotImplementedException();
        }
    }
}
