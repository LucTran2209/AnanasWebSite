using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Repositories
{
    public class MarketRepository : GenericRepository<Market>, IMarketRepository
    {
        public MarketRepository(AnanasDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task Add(Market entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Market entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Market>> GetAll()
        {
            try
            {
                var marketList = await _dbContext.Markets.ToListAsync();

                return marketList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override Task<Market> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public override void Update(Market entity)
        {
            throw new NotImplementedException();
        }


        public Task<List<Market>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
