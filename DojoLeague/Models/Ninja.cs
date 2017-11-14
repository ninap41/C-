using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models 
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="You must enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage="You must enter a level")]
        public int Level { get; set; }

        [Required(ErrorMessage="Dojo required.")]
        public string DojoName { get; set; }




        [Required(ErrorMessage="Description Required")]
    
        public string Description { get; set; }
    }
}