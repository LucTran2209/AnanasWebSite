using Ananas.Services.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Interfaces
{
    public interface IProductService
    {
        Task<dynamic> GetProductList();
    }
}
