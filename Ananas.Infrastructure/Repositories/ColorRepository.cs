using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Infrastructure.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(AnanasDbContext dbContext) : base(dbContext)
        {

        }

        public override Task Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Color>> GetAll()
        {
            var colorList = await _dbContext.Colors.ToListAsync();
            return colorList;
        }

        public override Task<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
