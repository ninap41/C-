using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
 
namespace BeltExam.Models
{
    public class Message : BaseEntity
    {

        [Key]
        public int MessageId {get; set;}

        public int UserId {get;set;}

        public User Creator{get;set;}

        public int Posted_For {get;set;}

         public string Content {get;set;}

         [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Created_At { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Updated_At { get; set; }


        public string Comment {get;set;}

        public List<Comment> Comments {get;set;}
        
        public Message() {

            List<Comment> Comments = new List<Comment>();


        }
    }

}