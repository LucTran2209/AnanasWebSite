using Ananas.Core.Common;
using Ananas.Core.Models;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return (IEnumerable<Style>)styleList;
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

        public async Task<List<GetByNameOutputDto>> GetByName(string name)
        {
            try
            {
                var styles = await _unitOfWork.Styles.GetByName(name);
                return _mapper.Map<List<GetByNameOutputDto>>(styles);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
