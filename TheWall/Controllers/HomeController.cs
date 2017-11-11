using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
    
             
        }
        private string Logged(){
            return "Logged";
        }
      
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            
           HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
      

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(string logged){
        string query ="SELECT * FROM new_users";
            List<Dictionary<string,object>> result = _dbConnector.Query(query);
            ViewBag.allUsers = result;
            

            // string UserString= TempData["new_person"].ToString();
            // User newUser = JsonConvert.DeserializeObject<User>(UserString);
            // ViewBag.newUsers = newUser;
       
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            string query ="SELECT * FROM new_users";
            List<Dictionary<string,object>> result = _dbConnector.Query(query);
            ViewBag.allUsers = result;


            if(ModelState.IsValid){
                try 
                {
                    
                    List<Dictionary<string, object>> RegisteredUser = _dbConnector.Query($"SELECT * FROM new_users WHERE email='{user.Email}'");
                    var CurrentUser = RegisteredUser[0];
                    if((string)CurrentUser["email"] == user.Email){
                        ViewBag.Error = "This email already belongs to a user!";
                        return View("Index");
                    }
                }
                catch 
                {
                    _dbConnector.Execute($"INSERT INTO new_users (first_name, last_name, email, password) VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}')");

                    List<Dictionary<string, object>> CurrentUser = _dbConnector.Query($"SELECT * FROM new_users WHERE email='{user.Email}'");
                    
                    HttpContext.Session.SetString("FirstName", user.FirstName);
                    HttpContext.Session.SetString("Email", user.Email);
                    
                    string logged = "2";
                    HttpContext.Session.SetString("logged", (string)logged);

                    ViewBag.logged =  HttpContext.Session.GetString("logged");
                    ViewBag.firstname = HttpContext.Session.GetString("FirstName");
                    ViewBag.email = HttpContext.Session.GetString("Email");
                    TempData["email"]= user.Email;
                    HttpContext.Session.SetString("Email", TempData["email"].ToString());


                   

                    return View("Index", user);
                }
               
                
            }

            
            return View("Index", user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            string query ="SELECT * FROM new_users";
            List<Dictionary<string,object>> result = _dbConnector.Query(query);
            ViewBag.allUsers = result;
            if(ModelState.IsValid){

                List<Dictionary<string, object>> RegisteredUser = _dbConnector.Query($"SELECT * FROM new_users WHERE email='{email}'");
                var user = RegisteredUser[0];
                
                if((string)user["email"] == email && (string)user["password"] == password){
                    ViewBag.firstname  = (string)user["first_name"];
                    HttpContext.Session.SetString("Email", (string)user["email"]);
                    ViewBag.email = HttpContext.Session.GetString("email");
                    string logged = "1";
                    HttpContext.Session.SetString("logged", (string)logged);
                 
                    return View("Index");
                }
                else {
                    ViewBag.Error = "That user is not in our database!";
                    return View("Index");
                } 
            }

            return View("Index");
        }

        // [HttpGET]
        // [Route("Redirect")]
        // public IActionResult ControllerSwitch()
        // {
        //    View("Wall");
        // }
    }
}