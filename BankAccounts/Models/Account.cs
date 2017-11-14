using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models 
{
    public class Account : BaseEntity
    {
        [Key]
        public int AccountsId{ get; set; }
        public double Balance { get; set; }


        
    }
}