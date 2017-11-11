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

using Woods.Factory;

namespace Woods.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly TrailFactory _trailFactory;
        private readonly DbConnector _dbConnector; //local copy class level variables to accept in constructor
 
        public HomeController(DbConnector connector, TrailFactory trailFactory) //Constructor.
        //dependancy injection. 
        //Recieve configured and instantiated copy of my factory into my Controller constructor
        //and hold onto by setting it to the class level variable above (readonly)
        {
            _trailFactory = trailFactory; //Factory Added Here
            _dbConnector = connector;
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // string query ="SELECT * FROM trails";
            // List<Dictionary<string,object>> result = _dbConnector.Query(query);
            // ViewBag.allTrails = result;
            IEnumerable<Trails> Result = _trailFactory.FindAll();
            ViewBag.allTrails = Result;

            return View();
            
        }

        [HttpGet]
        [Route("Add_Trail")]
        public IActionResult Add_Trail()
        { 
            IEnumerable<Trails> Result = _trailFactory.FindAll();
            ViewBag.allTrails = Result;
            return View("Add_Trail");
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult Create_Trail(Trails trailnew)
        {   
            if(TryValidateModel(trailnew)){
                // System.Console.WriteLine(trail);
                    _trailFactory.Add(trailnew);
                    ViewBag.newTrail = trailnew;
                //  string query = $"INSERT INTO trails (trail_name, description,trail_length, elevation_change, latitude,longitude) VALUES ('{trail.Trail_Name}', {trail.Description}, '{trail.Trail_Length}', {trail.Elevation_Change}, {trail.Latitude}, '{trail.Longitude}')";
                // List<Dictionary<string,object>> newTrail = _dbConnector.Query(query);
                // ViewBag.newTrail = newTrail;
                //  string stringVersionOfNewItem = JsonConvert.SerializeObject(trail);
                // TempData["newTrail"] = stringVersionOfNewItem;

                     return RedirectToAction("Add_Trail", trailnew);

                }
                else {

                ViewBag.errors= ModelState.Values;

                    return RedirectToAction("Index");


            }
        
    }
}
}
