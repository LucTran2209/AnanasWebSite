using Ananas.Core.Interfaces;
using Ananas.Core.Models;
using Ananas.Core.OutputDataAccess;
using Ananas.Infrastructure.Common;
using Ananas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ananas.Core.OutputDataAccess.StyleDto;

namespace Ananas.Infrastructure.Repositories
{
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        public StyleRepository(AnanasDbContext context) : base(context)
        {
        }



        public override async Task Add(Style style)
        {
            try
            {
                await _dbContext.Styles.AddAsync(style);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Delete(Style entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Style>> GetAll()
        {
            try
            {
                var styleList = await _dbContext.Styles.ToListAsync();
                return styleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<Style> GetById(int id)
        {
            try
            {
                var style = await _dbContext.Styles.FindAsync(id);
                if (style == null)
                {
                    throw new Exception($"Style with ID {id} not found.");
                }
                return style;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StyleDto.SetStylesNameOutputDto> GetByName(StyleDto.InputSetStylesDto inputnameStyle)
        {
            try
            {
                if (inputnameStyle.Name == null)
                {
                    throw new ArgumentNullException(nameof(inputnameStyle.Name));
                }

                List<Style> modelStyleList = new List<Style>(); 

                SetStylesNameOutputDto listbydto = new SetStylesNameOutputDto();

                modelStyleList = await _dbContext.Styles.Where(s => s.Name != null && s.Name.Contains(inputnameStyle.Name))
                                .ToListAsync();
                foreach (var style in modelStyleList)
                {
                    var item = new StyleDto.ListDto
                    {
                        StyleId = style.StyleId,
                        Name = style.Name,
                        Slug = style.Slug
                    };
                    listbydto.StyleList1.Add(item);
                }

                return listbydto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStyle(Style style)
        {
            try
            {
                var existingStyle = await _dbContext.Styles.FindAsync(style.StyleId);
                if (existingStyle == null)
                {
                    return false;
                }

                _dbContext.Entry(existingStyle).CurrentValues.SetValues(style);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Update(Style entity)
        {
            throw new NotImplementedException();
        }


    }
}
