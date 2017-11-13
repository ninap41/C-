using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Woods.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;





namespace Woods.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly WoodsContext _context;
 
        public HomeController(WoodsContext context) //Constructor.
       
        {
              _context = context; 
            
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Trail> allTrails = _context.Trails.OrderBy(t => t.Id).ToList();
            ViewBag.allTrails = allTrails;
            return View();//allTrails

         
        }


        [HttpPost]
        [Route("Create_Trail")]
        public IActionResult Create_Trail(Trail model)
        {   
           if (ModelState.IsValid)
            {

                Trail newTrail = new Trail
                {
                    Trail_Name = model.Trail_Name,
                    Description = model.Description,
                    Trail_Length = model.Trail_Length,
                    Elevation_Change = model.Elevation_Change,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude
                 
                };

                _context.Add(newTrail);
                _context.SaveChanges();
                List<Trail> allTrails = _context.Trails.OrderBy(r => r.Trail_Name).ToList();
                ViewBag.Trails = allTrails;
                return View("Add_Trail");
            }
              return View("Index");  
         }


        [HttpGet]
        [Route("Add_Trail")]
        public IActionResult Add_Trail()
        {   
             List<Trail> allTrails = _context.Trails.OrderBy(r => r.Trail_Name).ToList();
            ViewBag.Trails = allTrails;
            return View("Add_Trail");

        }


        [HttpGet]
        [Route("/{id}")]
        public IActionResult Trail(int id)
        {
            // int Id = id;
            // Trail thisTrail = _context.Trails.SingleOrDefault(t => t.Id == id);
            // ViewBag.Trail = thisTrail;
            return View();

        }
    }
}   
