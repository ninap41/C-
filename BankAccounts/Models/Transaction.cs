using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Transaction : BaseEntity
    {
        [Key]
        public int Id {get; set;}

        public int AccountId { get; set; }


        public string Type {get; set;}

        public string Amount{get; set;}

        public DateTime Date { get; set; }


    }
}