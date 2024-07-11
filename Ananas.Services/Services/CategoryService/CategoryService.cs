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
using static Ananas.Core.OutputDataAccess.CategoryDto;
using static Ananas.Core.OutputDataAccess.StyleDto;
using static Ananas.Services.Services.CategoryService.CategoryServiceOutputDto;
using static Ananas.Services.Services.StyleService.SyleServiceOutputDto;

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

        public async Task<SetCategoriesByNameOutputDtoService> GetCategoriesByName(GetCategoriesByNameInputDtoService inputDto)
        {
            try
            {
                if (inputDto.Name == null)
                {
                    throw new ArgumentNullException(nameof(inputDto.Name));
                }
                var input = new InputSetCategoriesDto();
                input.Name = inputDto.Name;
                var categories = await _unitOfWork.Categories.GetByName(input);
                var listoutput = new SetCategoriesByNameOutputDtoService();
                foreach (var category in categories.CategoryList1)
                {
                    var item = new CategoryListDto();
                    item.Name = category.Name;
                    item.CategoryId = category.CategoryId;
                    item.Slug = category.Slug;
                    listoutput.categories.Add(item);
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
