using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System;
using Newtonsoft.Json;





namespace random_Passcode.Controllers



{
    public class randomcontroller : Controller
    {
        [HttpGet]
        [Route("/random")]
        public IActionResult random()
        
        {
            if(HttpContext.Session.GetInt32("SessionCount") == null){
                HttpContext.Session.SetInt32("SessionCount", 1); 
                string PossibleChar="abcdefghIjKlmNoPqrstuvwxyz0123456789";
                string Passcode="";
                Random Rand = new Random();

                for(int i =0; i < 14; i++){ // i represents the length of what I want to generate.
                    Passcode = Passcode + PossibleChar[Rand.Next(0,PossibleChar.Length)];
                    ViewBag.PassCode = Passcode; //Passcode is ThreadStaticAttribute empty string
                } 
            }
            else {
                HttpContext.Session.SetInt32("SessionCount", (int)HttpContext.Session.GetInt32("SessionCount") + 1);
            }
           
            
            // ViewBag.SessionCount = SessionCount;
            // HttpContext.Session.SetInt32("SessionCount", (int)SessionCount);
            // HttpContext.Session.Clear("SessionCount");
            
            return View();
        }   

         [HttpGet]
        [Route("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("random");
            //return View("Index");
        }
        
            //return View("Index");
        

 
        

        
    }
}