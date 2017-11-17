using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class Wrapper : BaseEntity {
        public List<User> Users {get; set;}
        public List<Message> Messages {get; set;}
        public List<Comment> Comments {get; set;}
 
        public Wrapper(List<User> users, List<Message> messages, List<Comment> comments)
        {
            Users = users;
            Messages = messages;
            Comments = comments;
         
        }
    }
}