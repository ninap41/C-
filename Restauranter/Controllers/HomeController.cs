using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Restauranter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;
namespace Restauranter.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly RestauranterContext _context;
 
        public HomeController(RestauranterContext context) //Constructor.
        {
              _context = context; 
            
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           return View();
        }


        [HttpPost]
        [Route("Create_Review")]
        public IActionResult Create_Review(Review model)
        {   
           if (ModelState.IsValid)
            {
                Review newReview= new Review
                {
                        Restaurant_Name = model.Restaurant_Name,
                        Reviewer_Name = model.Reviewer_Name,
                        Reviews = model.Reviews,
                        Visit_Date= model.Visit_Date,
                        Rating = model.Rating

                };

                _context.Add(newReview);
                _context.SaveChanges();
                 return View("Index"); 
            }
              return View("Index");  
         }


       [HttpGet]
        [Route("/View_Reviews")]
        public IActionResult View_Reviews()
        {
            List<Review> allReviews = _context.Reviews.OrderBy(r => r.Visit_Date).ToList();
            ViewBag.Reviews = allReviews;
            return View();
        }
        [HttpGet]
        [Route("/{id}")]
        public IActionResult Review(int id)
        {
            int Id = id;
            Review thisReview = _context.Reviews.SingleOrDefault(t => t.Id == id);
            ViewBag.Review = thisReview;
            return View();

        }
    }
}   
