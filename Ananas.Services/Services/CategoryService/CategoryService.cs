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
                return (IEnumerable<Category>)categoryList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(CategoryCreateInputDto categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _unitOfWork.Categories.Add(category);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(CategoryUpdateInputDto categorynDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categorynDto);
                var updated = await _unitOfWork.Categories.UpdateCollection(category);
                return updated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CategoryGetByNameOutputDto>> GetByName(string name)
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetByName(name);
                return _mapper.Map<List<CategoryGetByNameOutputDto>>(categories);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
