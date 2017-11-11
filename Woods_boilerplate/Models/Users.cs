using System.ComponentModel.DataAnnotations;
using System;
 
namespace Woods.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [Display(Name = "FirstName")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters allowed")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [Display(Name = "LastName")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Only letters allowed")]
        public string LastName { get; set; }
 
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8, ErrorMessage="Password requires 8 characters, at least one uppercase")]
        [DataType(DataType.Password)]
        
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MinLength(8, ErrorMessage="Make sure your passwords are matching")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm")]
        public string Confirm{ get; set; }
    }
}