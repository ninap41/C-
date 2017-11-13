using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

using Microsoft.EntityFrameworkCore;

namespace DojoLeague.Models {


    public class MakeTrails : BaseEntity {
        [Key]
        public long Id { get; set; }        
    
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [Display(Name = "Trail_Name")]
        public string Trail_Name{ get; set; }

        [Required]
        [MaxLength(300, ErrorMessage="Description cannot exceed 300 characters")]

        [Display(Name = "Description")]
        public string Description{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a trail length (miles)")]
        [Display(Name = "Trail_Length")]
        public float Trail_Length{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit an Elevation Gain(ft)")]
        [Display(Name = "Elevation_Change")]
        public int Elevation_Change{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a valid coordinate (ex: -40.01209)")]
        [Range(-180, 180)]
        [Display(Name = "Latitude")]
        public float Latitude{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a valid coordinate (ex: -40.01209)")]
        [Range(-90, 90)]
        [Display(Name = "Longitude")]
        public float Longitude{ get; set; }
    }

}