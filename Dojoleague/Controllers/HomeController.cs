using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoLeague.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

using System.Linq;






namespace DojoLeague.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly DojoLeagueContext _context;
 
        public HomeController(DojoLeagueContext context) //Constructor.
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
                System.Console.WriteLine("You MAde It!");

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
                System.Console.WriteLine("THE OBJECT SHOULD BE MADE HERE I AM CHEKC YOUR CODEAJKSDJKAHSDJKGALJKSDJAGSDGJASGDJAGSJDGLASGDJHG");
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
