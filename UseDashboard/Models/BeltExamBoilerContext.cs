using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BeltExam.Models {
    public class BeltExamContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. public DbSet<User> Users { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public BeltExamContext(DbContextOptions<BeltExamContext> options) : base(options)
        { }
    }
}  
