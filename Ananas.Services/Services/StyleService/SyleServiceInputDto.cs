using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.StyleService
{
    public class StyleCreateInputDto
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }

    public class StyleUpdateInputDto
    {
        public int StyleId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }

    public class GetStylesByNameInputDtoService
    {
        public string? Name { get; set; }
    }

   
}
