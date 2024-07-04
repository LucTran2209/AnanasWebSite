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

namespace Ananas.Services.Services.SexService
{
    public class SexService : BaseService, ISexService
    {
        public SexService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Sex>> GetAll()
        {
            try
            {
                var sexList = await _unitOfWork.Sex.GetAll();
                return sexList;
            }
            catch (Exception) 
            { 
                throw; 
            }
        }
    }
}
