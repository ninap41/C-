using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace loginRegBoiler.Models {
    public class loginRegBoilerContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. public DbSet<User> Users { get; set; }
        public DbSet<User> Users {get; set;}
        // public DbSet<Guest> Guests{ get; set; }
        // public DbSet<Wedding> Weddings { get; set; }
        public loginRegBoilerContext(DbContextOptions<loginRegBoilerContext> options) : base(options)
        { }
    }
}  
