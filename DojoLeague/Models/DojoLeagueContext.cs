using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DojoLeague.Models {
        public class DojoLeagueContext : DbContext

        {
              public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public DojoLeagueContext(DbContextOptions<DojoLeagueContext> options) : base(options)
        { }
    }
}
        

