using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

using Microsoft.EntityFrameworkCore;


namespace DojoLeague.Models
{

       public class Trail
    {
        public int Id { get; set; }
        public string Trail_Name{ get; set; }
        public string Description{ get; set; }
        public float Trail_Length{ get; set; }
        public int Elevation_Change{ get; set; }
        public float Latitude{ get; set; }
        public float Longitude{ get; set; }
    }
  
    


  

}