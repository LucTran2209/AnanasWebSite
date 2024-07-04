using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;

namespace Ananas.Core.Interfaces
{
    public interface IProductDetailRepository : IGenericRepository<ProductDetail>
    {
        //interface different common of Detail Product
        Task<bool> CreateNewDetail(ProductDetailCreateInputDto pdetail);
        Task<ProductDetailCreateInputDto> UpdateDetail(int id, ProductDetailCreateInputDto pdetail);
    }

}
