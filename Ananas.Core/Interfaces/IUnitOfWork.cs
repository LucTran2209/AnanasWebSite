using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }

        //int Save();
    }
}
