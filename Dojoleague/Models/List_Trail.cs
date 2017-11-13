using System.Collections.Generic;

namespace DojoLeague.Models
{
      public class List_Trail : BaseEntity {
        public List<Trail> Trails { get; set; }
        public List_Trail(List<Trail> trails)
        {
            Trails = trails;
        }
    }
    
}