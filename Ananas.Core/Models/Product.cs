using System;
using System.Collections.Generic;

namespace Ananas.Core.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductCode { get; set; }

    public string? Name { get; set; }

    public string? Thumbnail { get; set; }

    public int? Quantity { get; set; }

    public string? Size { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? MarketId { get; set; }

    public int? DiscountId { get; set; }

    public int? CollectionId { get; set; }

    public int? CategoryId { get; set; }

    public int? ProductLineId { get; set; }

    public int? ProductStatusId { get; set; }

    public bool? Upper { get; set; }

    public bool? Lower { get; set; }

    public bool? Accessory { get; set; }

    public int? StyleId { get; set; }

    public int? MediaId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Collection? Collection { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual Market? Market { get; set; }

    public virtual Medium? Media { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();

    public virtual ProductLine? ProductLine { get; set; }

    public virtual ProductStatus? ProductStatus { get; set; }

    public virtual Style? Style { get; set; }
}
