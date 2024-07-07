using Ananas.Core.Common;
using Ananas.Infrastructure.Contexts;
using AutoMapper;

namespace Ananas.Infrastructure.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AnanasDbContext _dbContext;
        protected readonly IMapper _mapper; 

        protected GenericRepository(AnanasDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public abstract Task Add(T entity);
        public abstract void Delete(T entity);
        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task<T> GetById(int id);
        public abstract void Update(T entity);
    }
}
