using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loginRegBoiler.Models
{
    public class Wrapper : BaseEntity {
        public List<User> Users {get; set;}
 
        public Wrapper(List<User> users)
        {
            Users = users;
         
        }
    }
}