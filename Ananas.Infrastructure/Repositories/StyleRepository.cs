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
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        public StyleRepository(AnanasDbContext context) : base(context)
        {
        }

        public override async Task Add(Style style)
        {
            try
            {
                await _dbContext.Styles.AddAsync(style);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Delete(Style entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Style>> GetAll()
        {
            try
            {
                var styleList = await _dbContext.Styles.ToListAsync();
                return styleList;
            }
            catch(Exception) 
            {
                throw;
            }
        }

        public override async Task<Style> GetById(int id)
        {
            try
            {
                return await _dbContext.Styles.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Style>> GetByName(string name)
        {
            try
            {
                return await _dbContext.Styles.Where(s => s.Name.Contains(name)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStyle(Style style)
        {
            try
            {
                var existingStyle = await _dbContext.Styles.FindAsync(style.StyleId);
                if (existingStyle == null)
                {
                    return false; 
                }

                _dbContext.Entry(existingStyle).CurrentValues.SetValues(style);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Update(Style entity)
        {
            throw new NotImplementedException();
        }
    }
}
