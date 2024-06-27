using Ananas.Core.Models;
using Ananas.Core.Interfaces;
using Ananas.Services.Common.Dtos.Results;
using Ananas.Services.Interfaces;
using AutoMapper;

namespace Ananas.Services.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //public async Task<IEnumerable<Color>> GetAllColor()
        //{
        //    var colorList = await _unitOfWork.Colors.GetAll();
        //    return colorList;
        //}

        public Task<bool> CreateProduct(Color color)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteColor(int colorId)
        {
            throw new NotImplementedException();
        }


        public Task<Color> GetColorById(int colorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateColor(Color color)
        {
            throw new NotImplementedException();
        }

        public async Task<ColorList> GetAllColor()
        {
            var colorList = await _unitOfWork.Colors.GetAll();

            List<ColorDto> colorDtos = colorList.Select(c => _mapper.Map<ColorDto>(c)).ToList();

            ColorList output = new ColorList();
            output.Colors = colorDtos;

            return output;
        }
    }
}
