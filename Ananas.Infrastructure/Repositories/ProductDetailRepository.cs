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

                var search = new List<ProductDetail>();

                // check sexid
                if (flist.ListSexId != null && flist.ListSexId.Any())
                {
                    foreach (var item in flist.ListSexId)
                    {
                        var list = filter.Where(p => p.SexId == item.SexId).ToList();
                        search.AddRange(list);
                    }

                }
                // check colorid
                if (flist.ListColorId != null && flist.ListColorId.Any())
                {
                    foreach (var item in flist.ListColorId)
                    {
                        var list = filter.Where(p => p.ColorId == item.ColorId).ToList();
                        search.AddRange(list);
                    }

                }
                //check categoryid
                if (!flist.ListCategoryId.Any())
                {
                    foreach (var item in flist.ListCategoryId)
                    {
                        var list = filter.Where(p => p.Product.CategoryId == item.CategoryId).ToList();
                        search.AddRange(list);
                    }


                }
                //check line
                if (!flist.ListProductLineId.Any())
                {
                    foreach (var item in flist.ListProductLineId)
                    {
                        var list = filter.Where(p => p.Product.ProductLineId == item.ProductLineId).ToList();
                        search.AddRange(list);
                    }

                }
                //check styleid
                if (!flist.ListStyleId.Any())
                {
                    foreach (var item in flist.ListStyleId)
                    {
                        var list = filter.Where(p => p.Product.StyleId == item.StyleId).ToList();
                        search.AddRange(list);
                    }

                }
                //check collectionid
                if (!flist.ListCollectionId.Any())
                {
                    foreach (var item in flist.ListCollectionId)
                    {
                        var list = filter.Where(p => p.Product.CollectionId == item.CollectionId).ToList();
                        search.AddRange(list);
                    }

                }
                //check maketid
                if (!flist.ListMarketId.Any())
                {
                    foreach (var item in flist.ListMarketId)
                    {
                        var list = filter.Where(p => p.Product.MarketId == item.MarketId).ToList();
                        search.AddRange(list);
                    }

                }
                //check statusid
                if (!flist.ListProductStatusId.Any())
                {
                    foreach (var item in flist.ListProductStatusId)
                    {
                        var list = filter.Where(p => p.Product.ProductStatusId == item.ProductStatusId).ToList();
                        search.AddRange(list);
                    }

                }
                //check range price
                if (flist.ListPriceRanges != null)
                {
                    decimal min = 0;
                    decimal max = 0;
                    foreach (var item in flist.ListPriceRanges)
                    {
                        min = item.PriceMin;
                        max = item.PriceMax;
                        if (min < max)
                        {
                            var list = filter.Where(p => p.Product.Price > min && p.Product.Price < max).ToList();
                            search.AddRange(list);
                        }
                    }
                }

                //xoa bo nhung detailId trung lap
                search = search.DistinctBy(p => p.ProductDetailId).ToList();

                //add value in ouput
                foreach (var item in search)
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
