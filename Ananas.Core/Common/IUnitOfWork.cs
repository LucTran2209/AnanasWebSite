﻿using System;
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
        IProductRepository Products { get; }
        ITokenRepository Tokens { get; }
        IUserRepository Users { get; }
        //int Save();
    }
}
