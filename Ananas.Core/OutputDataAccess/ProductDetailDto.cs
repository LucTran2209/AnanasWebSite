namespace Ananas.Core.OutputDataAccess
{
    public class ProductDetailDto
    {

    }
    public class ProductDetailCreateInputDto
    {

        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int SexId { get; set; }

        public int SizeId { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }

        public string? Specialname { get; set; }
    }
}
