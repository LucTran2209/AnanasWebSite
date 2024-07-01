using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AnanasDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGetProductDataAccess> GetList()
        {
            try
            {
                //var productList = await _dbContext.Products
                //                        .Include(p => p.ProductDetails)
                //                        .Select( p => new ProductDto
                //                        {
                //                            ProductId = p.ProductId,
                //                            Price= p.Price,
                //                            ProductName = p.
                //                        })
                //                        .ToListAsync();

                ProductGetProductDataAccess result = new ProductGetProductDataAccess();
                result.ProductList = new List<ProductDto>();



                var l = from product in _dbContext.Products
                        join productDetail in _dbContext.ProductDetails on product.ProductId equals productDetail.ProductId
                        join color in _dbContext.Colors on productDetail.ColorId equals color.ColorId
                        join size in _dbContext.Sizes on product.CategoryId equals size.CategoryId
                        select new ProductDto
                        {
                            ProductId = product.ProductId,
                            ProductName = product.Name,
                            Price = product.Price,
                            ProductDetailId = productDetail.ProductDetailId,
                            SpecialName = productDetail.Specialname,
                            Size = size.Size1.ToString(),
                            Color = color.Code,
                            Quantity = productDetail.Quantity,
                        };

               

                result.ProductList = await l.ToListAsync();

                return result;


            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}
