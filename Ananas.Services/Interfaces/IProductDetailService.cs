using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Services.Services.ProductDetailService;
using static Ananas.Services.Services.ProductDetailService.ProductDetailFilterDtoService;

namespace Ananas.Services.Interfaces
{
    public interface IProductDetailService
    {
        //All Intefaces of Detail Product Service
        Task<IEnumerable<ProductDetail>> GetAll();
        Task<ProductDetail> GetById(int id);
        Task<bool> CreateNewDetail(ProductDetailCreateInputDto pdetail);
        Task<ProductDetailCreateInputDto> UpdateDetail(int id, ProductDetailCreateInputDto pdetail);
        Task<ProductDetailListsDtoService> GetProductDetailFilter(ProductDetailFilterDtoInputService flist);

    }
}
