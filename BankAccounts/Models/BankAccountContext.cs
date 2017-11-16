using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankAccount.Models {
    public class BankAccountContext : DbContext
    {
        // INCLUDE ALL MODELS AS DBSETS: ie. public DbSet<User> Users { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }


        public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options)
        { }
    }
}  
