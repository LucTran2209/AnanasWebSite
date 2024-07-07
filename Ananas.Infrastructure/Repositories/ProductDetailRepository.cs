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
                //khai báo output
                List<ProductDetailFilterOutputDto> listfilter = new List<ProductDetailFilterOutputDto>();

                //lấy ra tất cả productdetail
                var filter = await _dbContext.ProductDetails.Include(p => p.Product).ThenInclude(p => p.Category).Include(p => p.Sex).ToListAsync();

                // check sexid
                if (flist.ListSexId != null && flist.ListSexId.Any())
                {
                    filter = filter.Where(p => flist.ListSexId.Select(item => item.SexId).Contains(p.SexId)).ToList();

                }
                // check colorid
                if (flist.ListColorId != null && flist.ListColorId.Any())
                {
                    filter = filter.Where(p => flist.ListColorId.Select(item => item.ColorId).Contains(p.ColorId)).ToList();

                }
                //check categoryid
                if (flist.ListCategoryId != null && flist.ListCategoryId.Any())
                {
                    filter = filter.Where(p => flist.ListCategoryId.Select(item => item.CategoryId).Contains(p.Product.CategoryId)).ToList();
                }
                //check line
                if (flist.ListProductLineId != null && flist.ListProductLineId.Any())
                {
                    filter = filter.Where(p => flist.ListProductLineId.Select(item => item.ProductLineId).Contains(p.Product.ProductLineId)).ToList();
                }
                //check styleid
                if (flist.ListStyleId != null && flist.ListStyleId.Any())
                {
                    filter = filter.Where(p => flist.ListStyleId.Select(item => item.StyleId).Contains(p.Product.StyleId)).ToList();
                }
                //check collectionid
                if (flist.ListCollectionId != null && flist.ListCollectionId.Any())
                {
                    filter = filter.Where(p => flist.ListCollectionId.Select(item => item.CollectionId).Contains(p.Product.CollectionId)).ToList();
                }
                //check maketid
                if (flist.ListMarketId != null && flist.ListMarketId.Any())
                {
                    filter = filter.Where(p => flist.ListMarketId.Select(item => item.MarketId).Contains(p.Product.MarketId)).ToList();
                }
                //check statusid
                if (flist.ListProductStatusId != null && flist.ListProductStatusId.Any())
                {
                    filter = filter.Where(p => flist.ListProductStatusId.Select(item => item.ProductStatusId).Contains(p.Product.ProductStatusId)).ToList();
                }
                //check range price
                if (flist.ListPriceRanges != null && flist.ListPriceRanges.Any())
                {
                    filter = filter.Where(p =>
                    flist.ListPriceRanges.Any(range => p.Product.Price >= range.PriceMin && p.Product.Price <= range.PriceMax)
                    && flist.ListMarketId.Select(item => item.MarketId).Contains(p.Product.MarketId)
                    ).ToList();
                }


                //add value in ouput
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
