using Ananas.Core.Models;
using Ananas.Services.Services.StyleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface IStyleService
    {
        Task<IEnumerable<Style>> GetAll();
        Task<bool> Create(StyleCreateInputDto styleDto);

        Task<bool> Update(StyleUpdateInputDto styleDto);
    }
}
