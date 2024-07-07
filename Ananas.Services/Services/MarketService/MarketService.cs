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

namespace Ananas.Services.Services.MarketService
{
    public class MarketService : BaseService, IMarketService
    {
        public MarketService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Market>> GetAll()
        {
            try
            {
                var marketList = await _unitOfWork.Markets.GetAll();

                return marketList;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
