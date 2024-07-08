namespace Ananas.Core.OutputDataAccess
{
    public class ProductDetailDto
    {

    }
    public class ProductDetailCreateInputDto
    {

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int SexId { get; set; }

        public int SizeId { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }

        public string? Specialname { get; set; }
    }
    public class PriceRange
    {
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
    public class SexIdd
    {
        public int? SexId { get; set; }
    }
    public class ListCategoryIdd
    {
        public int? CategoryId { get; set; }
    }
    public class ListStyleIdd
    {
        public int? StyleId { get; set; }
    }
    public class ListProductLineIdd
    {
        public int? ProductLineId { get; set; }
    }
    public class ListCollectionIdd
    {
        public int? CollectionId { get; set; }
    }
    public class ListColorIdd
    {
        public int? ColorId { get; set; }
    }
    public class ListMarketIdd
    {
        public int? MarketId { get; set; }
    }
    public class ListProductStatusIdd
    {
        public int? ProductStatusId { get; set; }
    }
    public class ProductDetailFilterInputDto
    {
        public List<SexIdd> ListSexId { get; set; }
        public List<ListCategoryIdd> ListCategoryId { get; set; }
        public List<ListStyleIdd> ListStyleId { get; set; }
        public List<ListProductLineIdd> ListProductLineId { get; set; }
        public List<ListCollectionIdd> ListCollectionId { get; set; }
        public List<ListColorIdd> ListColorId { get; set; }
        public List<ListMarketIdd> ListMarketId { get; set; }
        public List<ListProductStatusIdd> ListProductStatusId { get; set; }
        public List<PriceRange> ListPriceRanges { get; set; }

        public ProductDetailFilterInputDto()
        {
            ListSexId = new List<SexIdd>();
            ListCategoryId = new List<ListCategoryIdd>();
            ListStyleId = new List<ListStyleIdd>();
            ListProductLineId = new List<ListProductLineIdd>();
            ListCollectionId = new List<ListCollectionIdd>();
            ListColorId = new List<ListColorIdd>();
            ListMarketId = new List<ListMarketIdd>();
            ListProductStatusId = new List<ListProductStatusIdd>();
            ListPriceRanges = new List<PriceRange>();
        }
    }

    // dto output product fillter
    public class ProductDetailListsDto
    {
        public List<ProductDetailFilterOutputDto> productDetailFilterOutputDtos { get; set; }
        public ProductDetailListsDto()
        {
            productDetailFilterOutputDtos = new List<ProductDetailFilterOutputDto>();
        }
    }
    public class ProductDetailFilterOutputDto
    {
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
