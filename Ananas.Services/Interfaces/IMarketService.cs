using Ananas.Core.Models;

namespace Ananas.Services.Interfaces
{
    public interface IMarketService
    {
        Task<IEnumerable<Market>> GetAll();
    }
}
