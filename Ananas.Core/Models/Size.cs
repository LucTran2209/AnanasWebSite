using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public int CategoryId { get; set; }

    public string Size1 { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
