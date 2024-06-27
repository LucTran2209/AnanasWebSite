using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? Name { get; set; }

    public decimal? DiscountPercent { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
