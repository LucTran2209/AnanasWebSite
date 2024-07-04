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
                return styleList;
            }
            catch(Exception) 
            {
                throw;
            }
        }
        //public async Task<Style> Create(Style style)
        //{
        //    try
        //    {
        //        var createStyle = await _unitOfWork.Styles.Add(style);
                
        //        return createStyle;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
