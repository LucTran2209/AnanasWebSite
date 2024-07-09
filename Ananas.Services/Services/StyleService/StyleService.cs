using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.StyleDto;
using static Ananas.Services.Services.StyleService.SyleServiceOutputDto;

namespace Ananas.Services.Services.StyleService
{
    public class StyleService : BaseService, IStyleService
    {
        public StyleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Style>> GetAll()
        {
            try
            {
                var styleList = await _unitOfWork.Styles.GetAll();
                return styleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(StyleCreateInputDto styleDto)
        {
            try
            {
                var style = _mapper.Map<Style>(styleDto);
                await _unitOfWork.Styles.Add(style);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(StyleUpdateInputDto styleDto)
        {
            try
            {
                var style = _mapper.Map<Style>(styleDto);
                var updated = await _unitOfWork.Styles.UpdateStyle(style);
                return updated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SetStylesByNameOutputDtoService> GetStylesByName(GetStylesByNameInputDtoService inputDto)
        {
            try
            {
                if (inputDto.Name == null)
                {
                    throw new ArgumentNullException(nameof(inputDto.Name));
                }
                var input = new InputSetStylesDto();
                input.Name = inputDto.Name;
                var styles = await _unitOfWork.Styles.GetByName(input);

                var listoutput = new SetStylesByNameOutputDtoService();
                foreach ( var style in styles.StyleList1)
                {
                    var item = new StyleListDto();
                    item.Name = style.Name;
                    item.StyleId = style.StyleId;
                    item.Slug = style.Slug;
                    listoutput.styles.Add(item);
                }


                return listoutput;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
