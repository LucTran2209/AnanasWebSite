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

        public ICollectionRepository Collections { get; }
        public IStyleRepository Styles { get; }

        public ISexRepository Sex { get; }
        public ISizeRepository Sizes { get; }

        public ICategoryRepository Categories { get; }

        public IDiscountRepository Discounts { get; }



        public UnitOfWork(AnanasDbContext dbContext,
                          IColorRepository colorRepository,
                          IMarketRepository marketRepository,
                          ICollectionRepository collectionRepository,
                          IStyleRepository styleRepository,
                          ISexRepository sexRepository,
                          ISizeRepository sizeRepository,
                          ICategoryRepository categoryRepository,
                          IDiscountRepository discountRepository)
        {
            _dbContext = dbContext;
            Colors = colorRepository;
            Markets = marketRepository;
            Collections = collectionRepository;
            Styles = styleRepository;
            Sex = sexRepository;
            Sizes = sizeRepository;
            Categories = categoryRepository;
            Discounts = discountRepository;
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
