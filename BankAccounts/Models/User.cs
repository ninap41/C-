using System.ComponentModel.DataAnnotations;
using System;
 
namespace BankAccount.Models
{
    public class User : BaseEntity
    {
        
      [Key]
        public int UsersId {get; set;}
        [Required]
        [MinLength(1)]
        public string First_Name {get; set;}
        [Required]
        [MinLength(1)]
        public string Last_Name {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        public string Password {get; set;}
        [Required]
        public DateTime Created_at { get; set; }
        [Required]
        public DateTime Updated_at { get; set; }

        public int AccountsID {get; set;}
        public Account userAccount {get; set;}


    }
}