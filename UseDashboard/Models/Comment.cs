using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
 
namespace BeltExam.Models
{
    public class Comment : BaseEntity
    {

        [Key]
        public int CommentId {get; set;}

        public string Content {get;set;}

        public int UserId {get; set;}


        public int MessageId {get;set;}

        public Message Message {get; set;}

        public User User {get; set;}


        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Created_At { get; set; }

          [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime Updated_At { get; set; }
        

       
    }

}