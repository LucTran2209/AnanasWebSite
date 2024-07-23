namespace Ananas.Core.Interfaces
{   
    public class ProductGetProductDataAccess
    {
        public List<ProductDto>? ProductList { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? ProductDetailId { get; set; }
        public string? SpecialName { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
    } 
}