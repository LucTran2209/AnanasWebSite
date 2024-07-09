using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.OutputDataAccess
{
    public class StyleDto
    {
        public class SetStylesNameOutputDto
        {
            public List<ListDto> StyleList1 { get; set; }
            public SetStylesNameOutputDto() 
            {
                StyleList1 = new List<ListDto>();
            }
        }

        public class ListDto
        {
            public int StyleId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }

        public class InputSetStylesDto
        {
            public string? Name { get; set; }
        }
    }
}
