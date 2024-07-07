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



        public async Task<List<ProductDetailFilterOutputDto>> GetProductDetailFilter(ProductDetailFilterInputDto flist)
        {
            try
            {
                var filter = await _dbContext.ProductDetails.Include(p => p.Product).ThenInclude(p => p.Category).Include(p => p.Sex).ToListAsync();
                if (flist.ListSexId != null && flist.ListSexId.Any())
                {
                    foreach (var item in flist.ListSexId)
                    {
                        filter = filter.Where(p => p.SexId == item.SexId).ToList();
                    }

                }
                if (flist.ListColorId != null && flist.ListColorId.Any())
                {
                    foreach (var item in flist.ListColorId)
                    {
                        filter = filter.Where(p => p.ColorId == item.ColorId).ToList();
                    }

                }
                if (!flist.ListCategoryId.Any())
                {
                    foreach (var item in flist.ListCategoryId)
                    {
                        filter = filter.Where(p => p.Product.CategoryId == item.CategoryId).ToList();
                    }


                }
                if (!flist.ListProductLineId.Any())
                {
                    foreach (var item in flist.ListProductLineId)
                    {
                        filter = filter.Where(p => p.Product.ProductLineId == item.ProductLineId).ToList();
                    }

                }
                if (!flist.ListStyleId.Any())
                {
                    foreach (var item in flist.ListStyleId)
                    {
                        filter = filter.Where(p => p.Product.StyleId == item.StyleId).ToList();
                    }

                }
                if (!flist.ListCollectionId.Any())
                {
                    foreach (var item in flist.ListCollectionId)
                    {
                        filter = filter.Where(p => p.Product.CollectionId == item.CollectionId).ToList();
                    }

                }

                if (!flist.ListMarketId.Any())
                {
                    foreach (var item in flist.ListMarketId)
                    {
                        filter = filter.Where(p => p.Product.MarketId == item.MarketId).ToList();
                    }

                }

                if (!flist.ListProductStatusId.Any())
                {
                    foreach (var item in flist.ListProductStatusId)
                    {
                        filter = filter.Where(p => p.Product.ProductStatusId == item.ProductStatusId).ToList();
                    }

                }
                if (!flist.ListPriceRanges.Any())
                {
                    decimal min = 0;
                    decimal max = 0;
                    foreach (var item in flist.ListPriceRanges)
                    {
                        min = item.PriceMin;
                        max = item.PriceMax;
                        if (min < max)
                        {
                            filter = filter.Where(p => p.Product.Price > min && p.Product.Price < max).ToList();
                        }
                    }
                }
                List<ProductDetailFilterOutputDto> listfilter = new List<ProductDetailFilterOutputDto>();
                foreach (var item in filter)
                {
                    ProductDetailFilterOutputDto p = new ProductDetailFilterOutputDto();
                    p.ProductId = item.ProductId;
                    p.ProductDetailId = item.ProductDetailId;
                    p.Name = item.Product.Name + " - " + item.Product.ProductCode + " - " + item.Specialname;
                    p.Quantity = item.Product.Quantity;
                    p.Size = item.Product.Size;
                    p.Price = (decimal)item.Product.Price;
                    listfilter.Add(p);

                }
                return listfilter;
            }
            catch (Exception)
            {

                throw;
            }


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
