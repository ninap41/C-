using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankAccount.Models {
        public class BankAccountContext : DbContext

        {
              public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options)
        { }
    }
}
        

