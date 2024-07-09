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

        public override async Task Add(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
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
            catch(Exception) 
            { 
                throw; 
            }
        }

        public override async Task<Category> GetById(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(id);
                if (category == null)
                {
                    throw new Exception($"Category with ID {id} not found.");
                }
                return category;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<Category>> GetByName(string name)
        {
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return await _dbContext.Categories
                                        .Where(s => s.Name != null && s.Name.Contains(name))
                                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> UpdateCollection(Category category)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FindAsync(category.CategoryId);
                if (existingCategory == null)
                {
                    return false;
                }

                _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Update(Category entity)
        {
            throw new NotImplementedException();
        }

    }
}
