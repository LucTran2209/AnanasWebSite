using Ananas.Core.Interfaces;

namespace Ananas.Core.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }
        IMarketRepository Markets { get; }
        IProductRepository Products { get; }
        IProductDetailRepository ProductDetails { get; }

        //int Save();
    }
}
