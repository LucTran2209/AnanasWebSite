using Ananas.Core.Models;
using Ananas.Services.Services.CollectionService;
using Ananas.Services.Services.ColorService;
using Ananas.Services.Services.StyleService;
using Ananas.Services.Services.CategoryService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Common.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {

            CreateMap<Color, ColorDto>();
            CreateMap<StyleCreateInputDto, Style>();
            CreateMap<StyleUpdateInputDto, Style>();
            CreateMap<Style, GetByNameOutputDto>();

            CreateMap<CollectionCreateInputDto, Collection>();
            CreateMap<CollectionUpdateInputDto, Collection>();
            CreateMap<Collection, CollectionGetByNameOutputDto>();

            CreateMap<CategoryCreateInputDto, Category>();
            CreateMap<CategoryUpdateInputDto, Category>();
            CreateMap<Category, CategoryGetByNameOutputDto>();
        }
    }
}
