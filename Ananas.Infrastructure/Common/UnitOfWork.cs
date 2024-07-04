using Ananas.Core.Common;
using Ananas.Core.Interfaces;
using Ananas.Infrastructure.Contexts;

namespace Ananas.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnanasDbContext _dbContext;
        public IColorRepository Colors { get; }

        public IMarketRepository Markets { get; }

        public IProductRepository Products { get; }
        public IProductDetailRepository ProductDetails { get; }

        public UnitOfWork(AnanasDbContext dbContext, IColorRepository colors, IMarketRepository markets, IProductRepository products, IProductDetailRepository productDetails)
        {
            _dbContext = dbContext;
            Colors = colors;
            Markets = markets;
            Products = products;
            ProductDetails = productDetails;
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
