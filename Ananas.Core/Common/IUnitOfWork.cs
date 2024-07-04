using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ananas.Core.Interfaces;

namespace Ananas.Core.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }
        IMarketRepository Markets { get; }

        ICollectionRepository Collections { get; }
        IStyleRepository Styles { get; }

        ISexRepository Sex { get; }
        ISizeRepository Sizes { get; }
        ICategoryRepository Categories { get; }

        IDiscountRepository Discounts { get; }

        //int Save();
    }
}
