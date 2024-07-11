using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.CollectionDto;

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
                var collection = await _dbContext.Collections.FindAsync(id);
                if (collection == null)
                {
                    throw new Exception($"Collection with ID {id} not found.");
                }
                return collection;
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

        public async Task<CollectionDto.SetCollectionsNameOutputDto> GetByName(CollectionDto.InputSetCollectionsDto InputnameCollection)
        {
            try
            {
                if (InputnameCollection.Name == null)
                {
                    throw new ArgumentNullException(nameof(InputnameCollection.Name));
                }

                List<Collection> modelCollectionList = new List<Collection>();

                SetCollectionsNameOutputDto listbydto = new SetCollectionsNameOutputDto();

                modelCollectionList = await _dbContext.Collections.Where(s => s.Name != null && s.Name.Contains(InputnameCollection.Name))
                                .ToListAsync();
                foreach (var collection in modelCollectionList)
                {
                    var item = new CollectionDto.ListCollectionDto
                    {
                        CollectionId = collection.CollectionId,
                        Name = collection.Name,
                        Slug = collection.Slug
                    };
                    listbydto.CollectionList1.Add(item);
                }

                return listbydto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
