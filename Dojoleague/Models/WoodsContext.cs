using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DojoLeague.Models {
        public class DojoLeagueContext : DbContext

        {
       
        public DbSet<Trail> Trails { get; set; }

        public DojoLeagueContext(DbContextOptions<DojoLeagueContext> options) : base(options)
        
        {

            
        }
    }
}
        

