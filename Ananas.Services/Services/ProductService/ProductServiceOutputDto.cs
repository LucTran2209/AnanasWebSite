using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.ProductService
{
    public class ProductServiceOutputDto
    {

    }

    public class ProductListOutputDto
    {
        public List<ProductDto>? ProductList { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public List<ProdutDetailDto>? ProductDetailList { get; set; }
    }

    public class ProdutDetailDto
    {
        public int? ProductDetailId { get; set; }
        public string? SpecialName { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
    }
}
