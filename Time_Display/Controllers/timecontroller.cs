using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Time_Display.Controllers
{
    public class timecontroller : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(){

         return View();
           
        }

//         [HttpPost]
//         [Route("")]
//         public IActionResult Other()
// {
//     // Return a view (We'll learn how soon!)
// }

    }
}