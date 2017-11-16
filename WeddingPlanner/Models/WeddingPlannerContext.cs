using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Models {
    public class WeddingPlannerContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. public DbSet<User> Users { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<Guest> Guests{ get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public WeddingPlannerContext(DbContextOptions<WeddingPlannerContext> options) : base(options)
        { }
    }
}  
