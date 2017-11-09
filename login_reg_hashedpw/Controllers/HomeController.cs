using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using newloginreg.Models;
using Microsoft.AspNetCore.Identity;
using newloginreg;

namespace newloginreg.Controllers
{
    public class HomeController : Controller
    {
    private readonly DbConnector _dbConnector;
 
    public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
                string message = " You have registered successfully!";

        // GET: /Home/
         [HttpGet]
        [Route("")]
        public IActionResult Index() //PASSING NEW USER THROUGH from form
        {
            string query ="SELECT * FROM new_users";
            List<Dictionary<string,object>> result = _dbConnector.Query(query);
            ViewBag.allUsers = result;
            return View();
            

          //rendering index.cshtml and all partials....
            
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult Register(RegisterUser user){ //Pass the newly made user through

             if(ModelState.IsValid)
            {
                RegisterUser(user);
                return RedirectToAction("Success");
            }
            
             return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            List<Dictionary<string,object>> users = _dbConnector.Query($"SELECT id, password FROM new_users WHERE email = '{user.LogEmail}'");

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //user exists
            if((users.Count == 0 || user.LogPassword == null) || hasher.VerifyHashedPassword(user, (string)users[0]["password"], user.LogPassword) == 0)
            {
                // we are bad
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            }
            if(ModelState.IsValid)
            {
                // go somewhere cool.  login user to session
                HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("success")]
        public string Success()
        {
            
            return "Success!";
        }
        public void RegisterUser(RegisterUser user) 
        {
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            string hashed = hasher.HashPassword(user, user.Password);
            string query = $@"Insert INTO new_users(first_name,last_name, email,password,created_at)
                            VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{hashed}',NOW())"; // selecting because its unique and can be used to start SESSION.
                    HttpContext.Session.SetInt32("id", Convert.ToInt32(_dbConnector.Query(query)[0]["id"]));
                    ViewBag.name=user.FirstName;
        }


//REFERENCE METHOD BELOW TO GET CURRENT USER NAME OVER TO NEW PAGE LATER.


    //     [HttpGet]
    // [Route("RouteName/{example}")]
    // public IActionResult Method(string example)
    // {
    //     //Code body
    // }
         
    }
}
