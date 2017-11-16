using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Wrapper : BaseEntity {
        public List<User> Users {get; set;}
        public List<Transaction> Transactions {get; set;}
        public List<Account> Accounts {get; set;}

        public Wrapper(List<User> users, List<Transaction> transactions, List<Account> accounts)
        {
            Users = users;
            Transactions = transactions;
            Accounts = accounts;
        }
    }
}