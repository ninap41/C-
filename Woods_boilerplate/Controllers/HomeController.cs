using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Woods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;

// using DbConnection;

namespace Woods.Controllers
{
      public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
    
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
             string query ="SELECT * FROM woods";
            List<Dictionary<string,object>> result = _dbConnector.Query(query);
            ViewBag.allTrails = result;
           
            return View();
        }

        [HttpGet]
        [Route("Add_Trail")]
        public IActionResult Add_Trail()
        {
            
           
            return View("Add_Trail");
        }
    }
}
