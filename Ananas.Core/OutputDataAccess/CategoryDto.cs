using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.OutputDataAccess
{
    public class CategoryDto
    {
        public class SetCategoriesNameOutputDto
        {
            public List<ListDto> CategoryList1 { get; set; }
            public SetCategoriesNameOutputDto()
            {
                CategoryList1 = new List<ListDto>();
            }
        }

        public class ListDto
        {
            public int CategoryId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }

        public class InputSetCategoriesDto
        {
            public string? Name { get; set; }
        }
    }
}
