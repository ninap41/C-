
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;





namespace Dojodachi.Controllers



{

    public class dojocontroller : Controller
    {
         public string message ="";
         public Random chance = new Random();
        [HttpGet]
        [Route("dojo")]
        public IActionResult dojo()
        
        {
            if(HttpContext.Session.GetInt32("meals") == null){
                    HttpContext.Session.SetString("alive","alive");
                    HttpContext.Session.SetString("emotion", "He Seems okay!");

                    HttpContext.Session.SetInt32("fullness", 20); 
                    HttpContext.Session.SetInt32("happiness", 20);
                    HttpContext.Session.SetInt32("meals", 3);
                    HttpContext.Session.SetInt32("energy", 50);
                    HttpContext.Session.SetString("message", message);

                }
                ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
                ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
                ViewBag.energy = HttpContext.Session.GetInt32("energy");
                ViewBag.meals = HttpContext.Session.GetInt32("meals");
                ViewBag.message= HttpContext.Session.GetString("message");
                ViewBag.emotion= HttpContext.Session.GetString("emotion");


            ViewBag.alive = HttpContext.Session.GetString("alive");
            ViewBag.message = HttpContext.Session.GetString("message");
            if(ViewBag.energy < 15){
                ViewBag.emotion = $"Your Pet is nearly exhausted to death! Get some rest soon!";
                ViewBag.message = "He's grumpy now.";
                ViewBag.message = $"";

            }
            if(ViewBag.happiness <= 0 || ViewBag.fullness <= 0 || ViewBag.energy <= 0){
                ViewBag.alive = "dead";
                ViewBag.emotion = $"Your Pet has passed away sadly... Restart?";
                 ViewBag.message = $"";
            }
            if(ViewBag.happiness == 100 && ViewBag.fullness == 100){
                ViewBag.alive = "Win";
                ViewBag.emotion = $"Your Pet has lived a wonderful life! Good Job <3. Restart?";
                 ViewBag.message = $"";

            }
            
            return View("dojo");
        }   //rendering route and setting DATA


        [HttpGet]
        [Route("feed")]
        public IActionResult Feed()
        {
            
            
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? new_fullness= HttpContext.Session.GetInt32("fullness") + chance.Next(5,11);
            
            if(meals > 0)
            {
            meals -= 1;
            HttpContext.Session.SetInt32("meals", (int)meals);
            HttpContext.Session.SetInt32("fullness", (int)new_fullness);
            HttpContext.Session.SetString("message", message);
            HttpContext.Session.SetString("message", $"You fed your Pet. His Fullness is now  at {fullness}!");
            }
            if (fullness > 110){
                happiness -= 10;
                HttpContext.Session.SetString("emotion", "He's been fed just enough! Much more and his happiness will drop.");
                HttpContext.Session.SetInt32("happiness", (int)happiness);

            }

            if(meals == 0){
                meals = 0;
                HttpContext.Session.SetString("message", $"You have no more meals!");


            }
            

             return RedirectToAction("dojo");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play(){
            int? happiness= HttpContext.Session.GetInt32("happiness");
            int? energy= HttpContext.Session.GetInt32("energy");
            int? new_happy= HttpContext.Session.GetInt32("happiness") + chance.Next(5,10);
            HttpContext.Session.SetString("message", message);
            HttpContext.Session.SetString("message", $"You played with your Pet. His happiness increased to {happiness}!");



            energy -=  10;

            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("happiness", (int)new_happy);
            return RedirectToAction("dojo");
        }


        [HttpGet]
        [Route("work")]
            public IActionResult Work(){
            int? energy= HttpContext.Session.GetInt32("energy");
            int? meals= HttpContext.Session.GetInt32("meals");
            int? added_meals= HttpContext.Session.GetInt32("meals") +   chance.Next(1,4);
            HttpContext.Session.SetString("message", message);
            HttpContext.Session.SetString("message", $"Your pet worked. His energy decreased to {energy} but he aquired {(int)meals} meals!");

            energy -=  5;

            HttpContext.Session.SetInt32("meals", (int)added_meals);
            HttpContext.Session.SetInt32("energy", (int)energy);
            return RedirectToAction("dojo");
        }



        [HttpGet]
        [Route("sleep")]
            public IActionResult Sleep(){
      
            int? energy= HttpContext.Session.GetInt32("energy");
            int? fullness= HttpContext.Session.GetInt32("fullness");
            int? happiness= HttpContext.Session.GetInt32("happiness");

            

            HttpContext.Session.SetString("message", message);

            
           happiness -= 5;
           fullness -= 5;
            energy +=  15;

            HttpContext.Session.SetInt32("energy", (int)energy);
            HttpContext.Session.SetInt32("fullness", (int)fullness);
            HttpContext.Session.SetInt32("happiness", (int)happiness);
            HttpContext.Session.SetString("message","Your Dojodachi got nice and rested");

            return RedirectToAction("dojo");
        }


         [HttpGet]
        [Route("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("dojo");
        }
        
        //     //return View("Index");
        

 
        

        
    }
}