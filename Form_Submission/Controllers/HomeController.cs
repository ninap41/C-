using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form_Submission.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Form_Submission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(string new_users)
        {
           ViewBag.new_users = new_users;


            return View();
        }

        [HttpPost]
        [Route("/process")]                     //strings below to be "set"
        public IActionResult Process(string first_name, string last_name, string email, int age, string password){
             User NewUser = new User //constructor
            {   // var left are GET from Models, left is SET from parameters above
                FirstName = first_name,
                LastName = last_name,
                Age = age,
                Email = email,
                Password = password

            };

                // string newError = "";
                // ViewBag.newError = errors
            

               if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }
            // otherwise validation passes, redirect to success
            else
            {
                return RedirectToAction("Success");  
            }

           

        }
        [HttpGet]
        [Route("/success")]
        public IActionResult Success(){
            string success_message = "You Have Registered Successfully!";
            
            ViewBag.success_message = success_message;
            


            
           


            return View();

        }
    }
}
