using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Services.Services.ProductDetailService;
using AutoMapper;
using static Ananas.Services.Services.ProductDetailService.ProductDetailFilterDtoService;

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
            CreateMap<ProductDetailFilterInputDto, ProductDetailFilterDtoInputService>();
            CreateMap<ProductDetailFilterOutputDto, ProductDetailFilterDtoOutputService>();
            CreateMap<ProductDetailListsDto, ProductDetailListsDtoService>();
        }
    }
}
