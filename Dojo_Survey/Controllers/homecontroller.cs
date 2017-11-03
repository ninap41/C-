using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Dojo_Survey.Controllers

{
    public class homecontroller : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Home()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }   

        [HttpPost]
        [Route("/process")]
        public IActionResult result(string name, string location,string language, string comment)

        {
            // ViewBag.Errors = new List<string>();

            // if(name == null){
            //     ViewBag.Errors.Add("Please Enter A Name");
            // }
            //  if(location == null){
            //     ViewBag.Errors.Add("Please Enter A Location");
            // }
            //  if(language == null){
            //     ViewBag.Errors.Add("Please Enter A Language");
            // }
            //     if(comment == null){
            //     comment= "";
            // }

            // if(ViewBag.Errors.Count > 0){
            //     return View("/");
            // }

            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment=comment;

            return View();



        }  
        

        
    }
}