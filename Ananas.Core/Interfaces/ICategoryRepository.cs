using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.CategoryDto;

namespace Ananas.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<SetCategoriesNameOutputDto> GetByName(InputSetCategoriesDto inputnameCategory);
        Task<bool> UpdateCollection(Category category);
        new Task<Category> GetById(int id);
    }
}
