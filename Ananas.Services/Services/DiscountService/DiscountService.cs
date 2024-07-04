using Ananas.Core.Common;
using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Services.Common.Base;
using Ananas.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.DiscountService
{
    public class DiscountService : BaseService, IDiscountService
    {
        public DiscountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Discount>> GetAll()
        {
            try
            {
                var discountList = await _unitOfWork.Discounts.GetAll();
                return discountList;
            }
            catch (Exception ) { throw; }
        }
    }
}
