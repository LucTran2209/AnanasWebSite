﻿using Ananas.Core.Common;
using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.Interfaces
{
    public interface IStyleRepository : IGenericRepository<Style>
    {
        Task<List<Style>> GetByName(string name);
        Task<bool> UpdateStyle(Style style);
        Task<Style> GetById(int id);
    }
}