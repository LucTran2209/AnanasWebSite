using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.Interfaces
{
    public interface ICollectionRepository : IGenericRepository<Collection>
    {
        Task<List<Collection>> GetByName(string name);
    }
}
