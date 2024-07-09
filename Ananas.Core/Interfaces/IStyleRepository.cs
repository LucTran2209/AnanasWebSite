using Ananas.Core.Common;
using Ananas.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.StyleDto;

namespace Ananas.Core.Interfaces
{
    public interface IStyleRepository : IGenericRepository<Style>
    {
        Task<SetStylesNameOutputDto> GetByName(InputSetStylesDto inputnameStyle);
        Task<bool> UpdateStyle(Style style);
        new Task<Style> GetById(int id);
    }
}
