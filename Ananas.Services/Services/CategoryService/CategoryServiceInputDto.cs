using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.CategoryService
{
    public class CategoryCreateInputDto
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
    // OutputDto for method GetByName
    public class CategoryUpdateInputDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }

    public class CategoryGetByNameOutputDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}
