using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models 
{
    public class Wrapper : BaseEntity
    {
        public List<Ninja> Ninjas { get; set; }
        public List<Dojo> Dojos { get; set; }

        public Wrapper(List<Ninja> ninjas, List<Dojo> dojos)
        {
            Ninjas = ninjas;
            Dojos = dojos;
        }
    }
}