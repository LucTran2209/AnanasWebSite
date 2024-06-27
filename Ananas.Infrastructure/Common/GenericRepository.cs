﻿using Ananas.Core.Interfaces;
using Ananas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AnanasDbContext _dbContext;

        protected GenericRepository(AnanasDbContext context)
        {
            _dbContext = context;
        }

        public abstract Task Add(T entity);
        public abstract void Delete(T entity);
        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task<T> GetById(int id);
        public abstract void Update(T entity);
    }
}
