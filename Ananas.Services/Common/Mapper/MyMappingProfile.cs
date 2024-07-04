using Ananas.Core.Models;
using Ananas.Services.Services.ColorService;
using Ananas.Services.Services.StyleService;
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
        }
    }
}
