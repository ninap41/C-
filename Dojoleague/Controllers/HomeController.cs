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
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;
namespace DojoLeague.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly DojoLeagueContext _context;
 
        public HomeController(DojoLeagueContext context) //Constructor.
        {
              _context = context; 
            
        }

        bool DirectMe = false;
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            
            List<Ninja> allNinjas = _context.Ninjas.OrderBy(t => t.Id).ToList();
            ViewBag.allNinjas = allNinjas;
           return View();
        }

        [HttpGet]
        [Route("/Dojos")]
        public IActionResult Dojos(){
            List<Dojo> Dojos = _context.Dojos.ToList();
            List<Ninja> Ninjas = _context.Ninjas.ToList();

            Wrapper model = new Wrapper(Ninjas, Dojos);
           
            // List<Dojo> allDojos = _context.Dojos.OrderBy(t => t.Id).ToList();
            // ViewBag.allDojos = allDojos;

            return View(model);
        }

        [HttpGet]
        [Route("Add_Dojo")]
        public IActionResult Add_Dojo(){
        
           
            
                
           
            return View();
        }


        [HttpPost]
        [Route("Create_Dojo")]
        public IActionResult Create_Dojo(Dojo model)
        {  
       
        if (ModelState.IsValid)
            {
          
                Dojo newDojo= new Dojo
                {
                    Name = model.Name,
                    Location= model.Location,
                    AddlInfo = model.AddlInfo,
                };

                 if(TryValidateModel(newDojo) == false){

                    ViewBag.ModelFields = ModelState.Values;
                    List<Ninja> Ninjas = _context.Ninjas.OrderBy(t => t.Id).ToList();
                    ViewBag.allNinjas = Ninjas;
                    return View();
                }
                else{
                _context.Add(newDojo);
                _context.SaveChanges();
                List<Ninja> Ninjas = _context.Ninjas.OrderBy(t => t.Id).ToList();
                ViewBag.allNinjas= Ninjas;
                // ViewBag.newdojo = newDojo.Name;
                return View("Index");
                
                }
                return View("Index");
            }
          
             
              return View("Add_Dojo");  
         }

        [HttpPost]
        [Route("Create_Ninja")]
        public IActionResult Create_Ninja(Ninja model)
        {   
           if (ModelState.IsValid)
            {
                Ninja newNinja= new Ninja
                {
                    Name = model.Name,
                    Level= model.Level,
                    DojoName= model.DojoName,
                    Description = model.Description,
                };
                
                if(TryValidateModel(newNinja) == false){

                    ViewBag.ModelFields = ModelState.Values;
                    List<Ninja> Ninjas = _context.Ninjas.OrderBy(t => t.Id).ToList();
                    ViewBag.allNinjas = Ninjas;
                    return View();
                }
                
                _context.Add(newNinja);
                _context.SaveChanges();
                List<Ninja> allNinjas = _context.Ninjas.OrderBy(t => t.Id).ToList();
                ViewBag.allNinjas = allNinjas;
                return View("Index");
            }
              return View("Index");  
         }



   
        [HttpGet]
        [Route("/ninja/{id}")]
        public IActionResult Single_Ninja(int id)
        {
            int Id = id;
            Ninja thisNinja = _context.Ninjas.SingleOrDefault(t => t.Id == id);
            ViewBag.Ninja= thisNinja;
            return View();

        }

          [HttpGet]
        [Route("/dojo/{id}")]
        public IActionResult Single_Dojo(int id)
        {
            int Id = id;
            Dojo thisDojo = _context.Dojos.SingleOrDefault(d => d.Id == (int)Id);
            List<Ninja> ninjas = _context.Ninjas.ToList();
            ViewBag.Dojo= thisDojo;
            ViewBag.Ninjas= ninjas;
            return View();

        }
    }
}   
