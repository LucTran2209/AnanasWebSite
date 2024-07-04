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
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(AnanasDbContext context) : base(context)
        {
        }

        public override Task Add(Discount entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Discount entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Discount>> GetAll()
        {
            try
            {
                var discountList = await _dbContext.Discounts.ToListAsync();
                return discountList;
            }
            catch (Exception ) { throw; }
        }

        public override Task<Discount> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discount>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
