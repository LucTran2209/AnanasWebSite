namespace Ananas.Core.OutputDataAccess
{
    //public class ProductRepositoryOutput
    //{

    //}

    public class ProductGetProductDataAccess
    {
        public List<ProductDto>? ProductList { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public List<ProdutDetailDto>? ProductDetailList { get; set; }
    }

    public class ProdutDetailDto
    {
        public int? ProductDetailId { get; set; }
        public string? Specialname { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
    }
}