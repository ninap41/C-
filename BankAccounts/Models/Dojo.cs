using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models 
{
    public class Dojo : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="You must enter a dojo name")]
        public string Name { get; set; }

        [Required(ErrorMessage="You must enter a location")]
        public string Location { get; set; }

        public string AddlInfo { get; set; }

    }
}