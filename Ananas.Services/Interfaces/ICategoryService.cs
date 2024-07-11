using Ananas.Core.Models;
using Ananas.Services.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ananas.Services.Services.CategoryService.CategoryServiceOutputDto;

namespace Ananas.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<bool> Create(CategoryCreateInputDto categoryDto);
        Task<bool> Update(CategoryUpdateInputDto categoryDto);
        Task<SetCategoriesByNameOutputDtoService> GetCategoriesByName(GetCategoriesByNameInputDtoService inputDto);
    }
}
