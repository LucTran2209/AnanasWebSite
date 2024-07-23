using Ananas.Core.Common;
using Ananas.Core.Interfaces;
using Ananas.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnanasDbContext _dbContext;
        public IColorRepository Colors { get; }

        public IMarketRepository Markets { get; }

        public IProductRepository Products { get; }

        public ITokenRepository Tokens { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(AnanasDbContext dbContext,
                          IColorRepository colorRepository,
                          IMarketRepository marketRepository,
                          IProductRepository products,
                          ITokenRepository authen,
                          IUserRepository users)
        {
            _dbContext = dbContext;
            Colors = colorRepository;
            Markets = marketRepository;
            Products = products;
            Tokens = authen;
            Users = users;
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
