using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Services.Services.CollectionService
{
    public class CollectionServiceOutputDto
    {
        public class SetCollectionsByNameOutputDtoService
        {
            public List<CollectionListDto> collections = new List<CollectionListDto>();
        }
        public class CollectionListDto
        {
            public int CollectionId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }
    }
}
