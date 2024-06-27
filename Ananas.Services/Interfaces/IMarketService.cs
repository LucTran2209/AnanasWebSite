using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface IMarketService
    {
        Task<IEnumerable<Market>> GetAll();
    }
}
