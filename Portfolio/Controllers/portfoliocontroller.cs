using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace portfolio.Controllers
{
    public class portfoliocontroller : Controller
    {
        [HttpGet]
        [Route("/")]
          public IActionResult Index()
        {
            return View();
           
        }
        [HttpGet]
        [Route("/contact")]
          public IActionResult Contact()
        {
            return View();
           
            //Both of these returns will render the same view (You only need one!)
        }


        // [HttpPost]
        // [Route("method")]
        //   public IActionResult Contact()
        // {
        //     return View();
           
        //     //Both of these returns will render the same view (You only need one!)
        // }
        [HttpGet]
        [Route("/projects")]
            public IActionResult projects()
        {
            return View();
           
            //Both of these returns will render the same view (You only need one!)
        }
    }
}