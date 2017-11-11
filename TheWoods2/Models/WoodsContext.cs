using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Woods.Models {
        public class WoodsContext : DbContext

        {
       
        public DbSet<Trail> Trails { get; set; }

        public WoodsContext(DbContextOptions<WoodsContext> options) : base(options)
        
        {

            
        }
    }
}
        

