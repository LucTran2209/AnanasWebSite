using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;

namespace Ananas.Services.Interfaces
{
    public interface IProductDetailService
    {
        //All Intefaces of Detail Product Service
        Task<IEnumerable<ProductDetail>> GetAll();
        Task<ProductDetail> GetById(int id);
        Task<bool> CreateNewDetail(ProductDetailCreateInputDto pdetail);
        Task<ProductDetailCreateInputDto> UpdateDetail(int id, ProductDetailCreateInputDto pdetail);

    }
}
