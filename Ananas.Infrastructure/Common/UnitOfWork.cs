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

        public IStyleRepository Styles { get; }

        public UnitOfWork(AnanasDbContext dbContext,
                          IColorRepository colorRepository,
                          IMarketRepository marketRepository,
                          IStyleRepository styles)
        {
            _dbContext = dbContext;
            Colors = colorRepository;
            Markets = marketRepository;
            Styles = styles;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
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
