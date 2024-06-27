using Ananas.Core.Models;
using Ananas.Services.Common.Dtos.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface IColorService
    {
        Task<bool> CreateProduct(Color color);

        Task<ColorList> GetAllColor();

        Task<Color> GetColorById(int colorId);

        Task<bool> UpdateColor(Color color);

        Task<bool> DeleteColor(int colorId);
    }
}
