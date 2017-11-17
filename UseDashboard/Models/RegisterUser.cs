using System;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class RegisterUser : BaseEntity
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters allowed")]
        public string First_Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters allowed")]
        public string Last_Name { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string User_Level { get; set; }

        [MaxLength(300, ErrorMessage = "Description cannot be more than 300 characters")]
         public string Description { get; set; }
 
        [Required(ErrorMessage = "You must enter a password")]
        [MinLength(8, ErrorMessage = "Password cannot be less than eight characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
     
        [Required(ErrorMessage = "Plase confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirm_Password { get; set; }
    }
}