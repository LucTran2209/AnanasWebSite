using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.StyleService
{
    public class SyleServiceOutputDto
    {
        public class SetStylesByNameOutputDtoService
        {
            public List<StyleListDto> styles = new List<StyleListDto>();
        }
        public class StyleListDto
        {
            public int StyleId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }
    }
}
