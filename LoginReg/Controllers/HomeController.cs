using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using loginRegBoiler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;
namespace loginRegBoiler.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly loginRegBoilerContext _context;
 
        public HomeController(loginRegBoilerContext context) //Constructor.
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
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserName",newUser.First_Name);
                HttpContext.Session.SetInt32("UserID", newUser.UsersId);

                return RedirectToAction("Dashboard_Page");
            } 
            else 
                {
                return RedirectToAction("Index");
                }
            }


            [HttpPost]
	        [Route("Login")]
	        public IActionResult LoginUser(string Email, string Password)
	        {
	            var loginUser = _context.Users.SingleOrDefault(user => user.Email == Email);
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
	                    HttpContext.Session.SetInt32("UserID", loginUser.UsersId);     //     REFERENCE THIS FOR SESSION IN EVERY ROUTE
	                    return RedirectToAction("Dashboard_Page");
	                }
                    else
	                {
	                    TempData["PasswordError"] = "Invalid password";
	                    return RedirectToAction("Index");
	                }
                }
            }


//__________________DASHBOARD/HomePage___________________________________________________________________________________________

    [HttpGet]
	        [Route("Dashboard_Page")]
	        public IActionResult Dashboard_Page()

	        {
	            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");
           
	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
	            else
                {
                    ViewBag.UserId = userID;// Integar for session
                    User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                    ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
	                ViewBag.User = thisuser; 
                    ViewBag.UserName = currentUser.First_Name; // USERNAME STRING
                
	            }
                return View();
	        }

//___________________Render Templates________________________________________________________________________

//______________________Create Object_______________________________________________________________________________________


//____________Delete Objects_________________________________________________________________________________________________




  

//_________________LogOut_________________________________________________________________________________________________________

            [HttpGet]
            [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }

       }

}
    
