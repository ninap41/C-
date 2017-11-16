using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;
namespace BankAccount.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly BankAccountContext _context;
 
        public HomeController(BankAccountContext context) //Constructor.
        {
              _context = context; 
            
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            List<User> AllUsers = _context.Users.ToList();
            
           return View();
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser registeringUser)
        {
            if(TryValidateModel(registeringUser))
            {
                //create a password hasher object just like when you make a random object
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User newUser = new User {
                    First_Name = registeringUser.First_Name,
                    Last_Name = registeringUser.Last_Name,
                    Email = registeringUser.Email.ToLower(),
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                newUser.Password = hasher.HashPassword(newUser, registeringUser.Password);
                Account newAccount = new Account {
                    Balance = 0
                };
                _context.Accounts.Add(newAccount);
                //NewAccount now has an idea from when it was created
                newUser.AccountsID = newAccount.AccountsId;
                newUser.userAccount = newAccount;

                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserName",newUser.First_Name);
                HttpContext.Session.SetInt32("UserID", newUser.UsersId);

                return RedirectToAction("Account_Page");
            } 
            else 
                {
                return RedirectToAction("Index");
                }
            }

          [HttpGet]
	        [Route("Account_Page")]
	        public IActionResult Account_Page(string Email, string Password)

	        {
	            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");
                // Password = HttpContext.Session.GetString("PasswordVerify", (string)Password);
	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
               
	            else
                {
	                ViewBag.User = thisuser;
	                User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID); //creates current user account with matching Id to transferred over RegisterUser Object
	                Account userAccount = _context.Accounts.SingleOrDefault(acc => acc.AccountsId == currentUser.AccountsID); // matches accounts to user by AccountsID attribute
                    // .where()

                    //                 List<Account> allChanges = _context.AccountChanges.

                    // List<Transaction> allTransactions = _context.Transactions.Include(a => a.AccountsId).ToList();
                    // ViewBag.allTransactions = allTransactions;
                    // Wrapper model = new Wrapper(Users, transactions, userAccount);



	                ViewBag.Balance = userAccount.Balance; //keeps track of their balance on the page.
	                return View("Account_Page");
	            }
	        }

            [HttpPost]
	        [Route("Login")]
	        public IActionResult LoginUser(string Email, string Password)
	        {
	            var loginUser = _context.Users.SingleOrDefault(user => user.Email == Email);
                System.Console.WriteLine(Password);
	            if(loginUser == null)
                {
                    TempData["EmailError"] = "Invalid email!";
                    return RedirectToAction("Index");
                }
            
                else
                {
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    if (0 != hasher.VerifyHashedPassword(loginUser, loginUser.Password, Password))
                    {
	                    HttpContext.Session.SetString("UserName",loginUser.First_Name);
	                    HttpContext.Session.SetInt32("UserID", loginUser.UsersId);
	                    return RedirectToAction("Account_Page");
	                }
                    else
	                {
	                    TempData["PasswordError"] = "Invalid password";
	                    return RedirectToAction("Index");
	                }
                }
            }


        [HttpPost]
        [Route("Deposit")]
        public IActionResult Deposit(int Deposit,Transaction model)
        {
            int? userID = HttpContext.Session.GetInt32("UserID");

            if(userID == null)
            {
                return RedirectToAction("Index");
            }
            else{

                

                User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                Account userAccount = _context.Accounts.SingleOrDefault(acc => acc.AccountsId == currentUser.AccountsID);
                userAccount.Balance += Deposit;
                _context.SaveChanges();
                return RedirectToAction("Account_Page");
            }
        }

        [HttpPost]
        [Route("Withdraw")]
        public IActionResult Withdraw(int Withdraw)
        {
            
            int? userID = HttpContext.Session.GetInt32("UserID");
            if(userID == null)
            {
                return RedirectToAction("Index");
            }
            
            
            else{
            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
            Account userAccount = _context.Accounts.SingleOrDefault(account => account.AccountsId == currentUser.AccountsID);
            if(userAccount.Balance - Withdraw < 0)
            {
                TempData["NoMon"]= "Your balance cannot be negative";
                return RedirectToAction("Account_Page");
            }
            else {
                userAccount.Balance -= Withdraw;
                _context.SaveChanges();
                return RedirectToAction("Account_Page");
            }
          }
            
        }



            [HttpGet]
            [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }

	        }

    }
  
