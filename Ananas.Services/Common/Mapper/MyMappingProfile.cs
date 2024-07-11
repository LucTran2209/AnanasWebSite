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
using Ananas.Core.OutputDataAccess;
using static Ananas.Core.OutputDataAccess.StyleDto;
using static Ananas.Services.Services.StyleService.SyleServiceOutputDto;

namespace Ananas.Services.Common.Mapper
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {

            CreateMap<Color, ColorDto>();

            CreateMap<StyleCreateInputDto, Style>();
            CreateMap<StyleUpdateInputDto, Style>();
            //CreateMap<Style, GetStylesByNameOutputDto>();

            CreateMap<CollectionCreateInputDto, Collection>();
            CreateMap<CollectionUpdateInputDto, Collection>();
            //CreateMap<Collection, CollectionGetByNameOutputDto>();

            CreateMap<CategoryCreateInputDto, Category>();
            CreateMap<CategoryUpdateInputDto, Category>();
            //CreateMap<Category, CategoryGetByNameOutputDto>();

           
        }
    }
}
