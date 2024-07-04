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
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(AnanasDbContext context) : base(context)
        {
        }

        public override Task Add(Size entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Size entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Size>> GetAll()
        {
            try
            {
                var sizeList = await _dbContext.Sizes.ToListAsync();
                return sizeList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task<Size> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Size>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Size entity)
        {
            throw new NotImplementedException();
        }
    }
}
