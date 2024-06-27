using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class Sex
{
    public int SexId { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
