using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace pokemoninfo.Controllers
{

    
    public class HomeController : Controller
    {
            // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index(int id)
        {
             var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;
            // string fire = "fire";
            // string water = "water";
            // string grass = "grass";



         
            return View("Index");
        }

        
       [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult GetInfo(int id)
        {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;

            


        return View("Pokemon");
 
}
    
    }
}
