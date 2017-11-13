using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

using Microsoft.EntityFrameworkCore;

namespace Restauranter.Models {


    public class Review : BaseEntity {
        [Key]
        public int Id { get; set; }  
        
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        // [Display]
        public string Restaurant_Name{ get; set; }      
    
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        // [Display]
        public string Reviewer_Name{ get; set; }

        [Required]
        [MaxLength(400, ErrorMessage="Review cannot be over 400 characters")]
        // [Display]
        public string Reviews{ get; set; }

        [Required]
        // [Display]
        public DateTime Visit_Date { get; set; }
       
        [Required]
        // [Display]
        public int Rating { get; set; }

  
    }

}