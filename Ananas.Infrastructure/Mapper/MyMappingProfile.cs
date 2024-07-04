using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using AutoMapper;


namespace Ananas.Infrastructure.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<ProductDetail, ProdutDetailDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(src => src.ProductDetailList, opt => opt.MapFrom(dest => dest.ProductDetails));
            CreateMap<ProductDetailCreateInputDto, ProductDetail>();
        }
    }
}
