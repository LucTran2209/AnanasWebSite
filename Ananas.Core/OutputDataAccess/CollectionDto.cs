using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananas.Core.OutputDataAccess
{
    public class CollectionDto
    {
        public class SetCollectionsNameOutputDto
        {
            public List<ListCollectionDto> CollectionList1 { get; set; }
            public SetCollectionsNameOutputDto()
            {
                CollectionList1 = new List<ListCollectionDto>();
            }
        }

        public class ListCollectionDto
        {
            public int CollectionId { get; set; }
            public string? Name { get; set; }
            public string? Slug { get; set; }
        }

        public class InputSetCollectionsDto
        {
            public string? Name { get; set; }
        }
    }
}
