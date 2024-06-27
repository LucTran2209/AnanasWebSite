using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class ProductDetail
{
    public int ProductDetailId { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public int SexId { get; set; }

    public int SizeId { get; set; }

    public int Quantity { get; set; }

    public string? Image { get; set; }

    public string? Specialname { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Sex Sex { get; set; } = null!;
}
