using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Restauranter.Models {
        public class RestauranterContext : DbContext

        {
       
        public DbSet<Review> Reviews { get; set; }

        public RestauranterContext(DbContextOptions<RestauranterContext> options) : base(options)
        
        {

            
        }
    }
}
        

