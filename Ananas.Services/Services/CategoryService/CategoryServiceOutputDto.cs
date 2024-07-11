using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.CategoryService
{
    public class CategoryServiceOutputDto
    {
        public class SetCategoriesByNameOutputDtoService
        {
            public List<CategoryListDto> categories = new List<CategoryListDto>();
        }
        public class CategoryListDto
        {
            public int CategoryId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }
    }
}
