using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
 
namespace BeltExam.Models
{
    public class User : BaseEntity
    {
        
      [Key]
        public int UsersId {get; set;}  //remember its plural

        public string First_Name {get; set;}

        public string Last_Name {get; set;}

        public string Email {get; set;}

        public string Password {get; set;}

        public string User_Level{get;set;}

        public string Description {get;set;}
      
        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        public List<Message> Messages {get;set;}

        public List<Comment> Comments {get;set;}

         public User()
        {
            Messages = new List<Message>();
            Comments= new List<Comment>();
         }
    }
}