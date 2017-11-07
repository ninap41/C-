using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using loginregistration.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace loginregistration.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View(); //rendering index.cshtml and all partials....
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginForm()
        
        {
            return View(); //rendering index.cshtml and all partials....
        }
        [HttpPost]
        [Route("register")]

        public IActionResult Register()
        {
            return View(); //rendering index.cshtml and all partials....

        }   
    }
}
