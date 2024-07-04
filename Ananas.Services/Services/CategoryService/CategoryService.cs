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

namespace Ananas.Services.Services.CategoryService
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var categoryList = await _unitOfWork.Categories.GetAll();
                return categoryList;
            
            }catch (Exception ) { throw; }
        }
    }
}
