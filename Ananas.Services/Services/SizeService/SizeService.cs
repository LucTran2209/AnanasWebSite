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

namespace Ananas.Services.Services.SizeService
{
    public class SizeService : BaseService, ISizeService
    {
        public SizeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Size>> GetAll()
        {
            try
            {
                var sizeList = await _unitOfWork.Sizes.GetAll();
                return sizeList;
            }
            catch (Exception) 
            { 
                throw; 
            }
        }
    }
}
