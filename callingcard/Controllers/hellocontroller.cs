using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace callingcard.Controllers
{
   public class CardsController : Controller
    {

        [HttpGet]
        [Route("/")]
        public JsonResult CallCard(string FirstName, string LastName, int Age, string FavColor)
        
        {

             var AnonObject = new {
                         FirstName = "Tim",
                         LastName = "Toolman",
                         Age = 42,
                        FavColor = "Brown"
                     };

            


     

    return Json(AnonObject.FirstName, AnonObject.LastName, AnonObject.Age, AnonObject.FavColor);
            }
            //This builds a JSON response with the given route parameters
        }
    }
