using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Woods3.Models {
        public class Woods3Context : DbContext

        {
       
        public DbSet<Trail> Trails { get; set; }

        public Woods3Context(DbContextOptions<Woods3Context> options) : base(options)
        
        {

            
        }
    }
}
        

