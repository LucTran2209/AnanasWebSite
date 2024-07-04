using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;

namespace Ananas.Services.Services.ProductDetailService
{
    public class ProductDetailService : BaseService, IProductDetailService
    {
        public ProductDetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        //Create Detail In sẻvice
        public async Task<bool> CreateNewDetail(ProductDetailCreateInputDto pdetail)
        {
            bool isCreateDetail = await _unitOfWork.ProductDetails.CreateNewDetail(pdetail);
            return isCreateDetail;
        }
        // get all detail
        public async Task<IEnumerable<ProductDetail>> GetAll()
        {
            try
            {
                var productDetailList = await _unitOfWork.ProductDetails.GetAll();

                return productDetailList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //get Detail by id
        public async Task<ProductDetail> GetById(int id)
        {
            try
            {
                var detail = await _unitOfWork.ProductDetails.GetById(id);
                return detail;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Update detail by id
        public async Task<ProductDetailCreateInputDto> UpdateDetail(int id, ProductDetailCreateInputDto pdetail)
        {
            try
            {
                var detail = await _unitOfWork.ProductDetails.UpdateDetail(id, pdetail);
                return detail;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
