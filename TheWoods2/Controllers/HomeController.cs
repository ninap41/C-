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
using Microsoft.EntityFrameworkCore;

using System.Linq;






namespace Woods.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly WoodsContext _context;
 
        public HomeController(WoodsContext context) //Constructor.
        //dependancy injection. 
        //Recieve configured and instantiated copy of my factory into my Controller constructor
        //and hold onto by setting it to the class level variable above (readonly)
        {
              _context = context; 
            
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           List<Trail> trails = _context.Trails.ToList();
            List_Trail existingtrails = new List_Trail(trails);
            return View(existingtrails);

         
            
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create_Trail(MakeTrails  newtrail)
        {   
           if (ModelState.IsValid)
            {
                MakeTrails newTrail = new MakeTrails
                {
                    Trail_Name = newtrail.Trail_Name,
                    Description = newtrail.Description,
                    Trail_Length = newtrail.Trail_Length,
                    Elevation_Change = newtrail.Elevation_Change,
                    Latitude = newtrail.Latitude,
                    Longitude = newtrail.Longitude
                 
                };

                _context.Add(newTrail);
            
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
              return RedirectToAction("Index");  
         }


        [HttpGet]
        [Route("Add_Trail")]
        public IActionResult Add_Trail()
        {   
            return View("Add_Trail");
        }
        [HttpGet]
        [Route("/{id}")]
        public IActionResult Trail(int id)
        {
            int Id = id;
            Trail thisTrail = _context.Trails.SingleOrDefault(t => t.Id == id);
            ViewBag.Trail = thisTrail;
            return View();

        }
    }
}   
