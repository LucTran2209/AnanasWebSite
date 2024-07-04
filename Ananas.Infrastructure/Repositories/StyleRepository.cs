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

        public override Task Add(Style entity)
        {
            throw new NotImplementedException();
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

        public override Task<Style> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Style>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Style entity)
        {
            throw new NotImplementedException();
        }
    }
}
