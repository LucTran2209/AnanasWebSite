using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ananas.Infrastructure.Repositories
{
    public class ProductDetailRepository : GenericRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(AnanasDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Task Add(ProductDetail entity)
        {
            throw new NotImplementedException();
        }

        // Insert New Detail của Infrastructure
        public async Task<bool> CreateNewDetail(ProductDetailCreateInputDto pdetail)
        {
            try
            {
                ProductDetail p = new ProductDetail();

                _mapper.Map(pdetail, p);

                await _dbContext.ProductDetails.AddAsync(p);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Delete By Id Detail
        public override void Delete(ProductDetail entity)
        {
            throw new NotImplementedException();
        }
        //Get all Detail
        public override async Task<IEnumerable<ProductDetail>> GetAll()
        {
            try
            {
                var detail = await _dbContext.ProductDetails.ToListAsync();
                return detail;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Get Detail By id
        public override async Task<ProductDetail> GetById(int id)
        {
            try
            {
                var detail = await _dbContext.ProductDetails.FirstOrDefaultAsync(p => p.ProductDetailId == id);

                return detail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<ProductDetail>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(ProductDetail entity)
        {
            throw new NotImplementedException();
        }
        //Update Detail by ID
        public async Task<ProductDetailCreateInputDto> UpdateDetail(int id, ProductDetailCreateInputDto pdetail)
        {
            try
            {
                //check ID real
                var detail = await _dbContext.ProductDetails.FirstOrDefaultAsync(p => p.ProductDetailId == id);
                if (detail == null)
                {
                    return null;
                }
                else
                {
                    //update Detail in database
                    _mapper.Map(pdetail, detail);
                    _dbContext.Update(detail);
                    await _dbContext.SaveChangesAsync();
                    return pdetail;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
