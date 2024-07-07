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

        public override async Task Add(Collection collection)
        {
            try
            {
                await _dbContext.Collections.AddAsync(collection);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
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

        public override async Task<Collection> GetById(int id)
        {
            try
            {
                return await _dbContext.Collections.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Collection>> GetByName(string name)
        {
            try
            {
                return await _dbContext.Collections.Where(c => c.Name.Contains(name)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCollection(Collection collection)
        {
            try
            {
                var existingCollection = await _dbContext.Collections.FindAsync(collection.CollectionId);
                if (existingCollection == null)
                {
                    return false;
                }

                _dbContext.Entry(existingCollection).CurrentValues.SetValues(collection);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Update(Collection entity)
        {
            throw new NotImplementedException();
        }
    }
}
