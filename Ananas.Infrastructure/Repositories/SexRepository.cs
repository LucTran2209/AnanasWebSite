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
    public class SexRepository : GenericRepository<Sex>, ISexRepository
    {
        public SexRepository(AnanasDbContext context) : base(context)
        {
        }

        public override Task Add(Sex entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Sex entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Sex>> GetAll()
        {
            try
            {
                var sexList = await _dbContext.Sexes.ToListAsync();
                return sexList;
            }
            catch (Exception ) 
            { 
                throw; 
            }
        }

        public override Task<Sex> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sex>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Sex entity)
        {
            throw new NotImplementedException();
        }
    }
}
