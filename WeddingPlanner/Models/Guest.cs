using System.ComponentModel.DataAnnotations;
using System;
 
namespace WeddingPlanner.Models
{
    public class Guest : BaseEntity
    {

        [Key]
       
     
        public int id { get; set; }
        // public Wedding Wedding { get; set; }

    

        public int GuestId{get;set;}
        public int WeddingId { get; set; }
        // public User User { get; set; }
        public int UserId { get; set; }
      
        public Wedding Wedding { get; set; }
        
        public User User { get; set; }
     

    }

}


    
