using Ananas.Core.Common;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.ProductService
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<dynamic> GetProductList()
        {
            try
            {
                var productList = await _unitOfWork.Products.GetList();

                return productList;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
