using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Woods.Models
{

    public class Trails : BaseEntity {
        [Required]
        [MinLength(2, ErrorMessage="Field must be at least two characters long")]
        [Display(Name = "Trail_Name")]
        public string Trail_Name{ get; set; }

        [Required]
        [MaxLength(300, ErrorMessage="Description cannot exceed 300 characters")]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters")]

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
        [Range(-180, 180, ErrorMessage="Longitude out of range")]
        [Display(Name = "Latitude")]
        public float Latitude{ get; set; }

        [Required]
        [MinLength(0, ErrorMessage="Please submit a valid coordinate (ex: -40.01209)")]
        [Range(-90, 90, ErrorMessage="Latitude out of range")]
        [Display(Name = "Longitude")]
        public float Longitude{ get; set; }
    }

     public class Wrapper : BaseEntity {
        public List<Trails> Trails { get; set; }
        public Wrapper(List<Trails> trails)
        {
            Trails = trails;
        }
//     public class WoodsContext : DbContext
//   {
//      //include all models as DbSets ie. public DbSet<Guest> Guests {get; set;}
//      public DbSet<Trail> Trails {get; set; }
//   public WoodsContext(DbContextOptions<WoodsContext> options) : base(options)
//   { }
//   }

     }

}