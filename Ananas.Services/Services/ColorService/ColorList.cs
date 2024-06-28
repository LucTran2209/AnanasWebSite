using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.ColorService
{
    public class ColorList
    {
        public List<ColorDto>? Colors { get; set; }
    }

    public class ColorDto
    {
        public int ColorId { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }


    public class ProductListOutputDto
    {
        public List<ProductDto>? ProductList { get; set; }
    }

    public class ProductDto
    {
        public string? ProductName { get; set; } 
        public decimal Price { get; set; }

        public List<ProductDetailDto>? ProductDetailList { get; set; }

    }

    public class ProductDetailDto
    {
        public int ProductDetailId { get; set;}
    }
}
