using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

using Microsoft.EntityFrameworkCore;

namespace Woods3.Models {


      public class Trail : BaseEntity {
        [Key]
        public int Id { get; set; }        
    
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        public string Trail_Name{ get; set; }

        [Required]
        [MaxLength(300, ErrorMessage="Description cannot exceed 300 characters")]

        public string Description{ get; set; }

        [Required]
        [Range(-300, 2000)]        
        public double Trail_Length{ get; set; }

        [Required]
        [Range(-300, 2000)]     

        public int Elevation_Change{ get; set; }

        [Required]
        [Range(-300, 2000)]
        public double Latitude{ get; set; }

        [Required]
         [Range(-300, 2000)]
        public double Longitude{ get; set; }
    }

}