using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Common.Dtos.Results
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



    //public class LucTran
    //{
    //    [Required]
    //    public string Name { get; set; }

    //    [Range(0, 100)]
    //    public int Age { get; set; }
    //}
}
