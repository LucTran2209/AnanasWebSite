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

        public UnitOfWork(AnanasDbContext dbContext,
                          IColorRepository colorRepository)
        {
            _dbContext = dbContext;
            Colors = colorRepository;
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
