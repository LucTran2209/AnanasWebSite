using Ananas.Core.Models;
using Ananas.Services.Common.Dtos.Results;
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
               
            
            
            
        }
    }
}
