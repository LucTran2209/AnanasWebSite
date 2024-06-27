using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class Medium
{
    public int MediaId { get; set; }

    public string? Link { get; set; }

    public string? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
