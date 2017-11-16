using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wrapper : BaseEntity {
        public List<User> Users {get; set;}
        public List<Guest> Guests {get; set;}
        public List<Wedding> Weddings {get; set;}

        public Wrapper(List<User> users, List<Guest> guests, List<Wedding> weddings)
        {
            Users = users;
            Guests= guests;
            Weddings= weddings;
        }
    }
}