using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoginAndReg3.Models {
        public class LoginAndReg3Context : DbContext

        {
       
        public DbSet<Trail> Trails { get; set; }

        public LoginAndReg3Context(DbContextOptions<LoginAndReg3Context> options) : base(options)
        
        {

            
        }
    }
}
        

