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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AnanasDbContext context) : base(context)
        {
        }

        public override Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var categoryList = await _dbContext.Categories.ToListAsync();
                return categoryList;
            }
            catch (Exception ) { throw; }
        }

        public override Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
