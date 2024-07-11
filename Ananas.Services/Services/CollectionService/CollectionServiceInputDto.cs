using Ananas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.CollectionService
{
    public class CollectionCreateInputDto
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
    // OutputDto for method GetByName
    public class CollectionUpdateInputDto
    {
        public int CollectionId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }

    public class GetCollectionsByNameInputDtoService
    {
        public string? Name { get; set; }
    }
}
