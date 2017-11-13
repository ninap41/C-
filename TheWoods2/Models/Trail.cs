using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;


using Microsoft.EntityFrameworkCore;

namespace Woods.Models {


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
        [MinLength(0, ErrorMessage="Please submit a trail length (miles)")]
        public float Trail_Length{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit an Elevation Gain(ft)")]
        public int Elevation_Change{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a valid coordinate (ex: -40.01209)")]
        [Range(-180, 180)]
        public float Latitude{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a valid coordinate (ex: -40.01209)")]
        [Range(-90, 90)]
        public float Longitude{ get; set; }
    }

}