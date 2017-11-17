using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;
namespace WeddingPlanner.Controllers
{   
    
      public class HomeController : Controller
    {

        private readonly WeddingPlannerContext _context;
 
        public HomeController(WeddingPlannerContext context) //Constructor.
        {
              _context = context; 
            
        }
  
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()

        {
            List<User> AllUsers = _context.Users.ToList();
            
           return View();
        }

 [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser registeringUser)
        {
            if(TryValidateModel(registeringUser))
            {
                //create a password hasher object just like when you make a random object
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User newUser = new User {
                    First_Name = registeringUser.First_Name,
                    Last_Name = registeringUser.Last_Name,
                    Email = registeringUser.Email.ToLower(),
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                newUser.Password = hasher.HashPassword(newUser, registeringUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetString("UserName",newUser.First_Name);
                HttpContext.Session.SetInt32("UserID", newUser.UsersId);

                return RedirectToAction("Dashboard_Page");
            } 
            else 
                {
                return RedirectToAction("Index");
                }
            }


            [HttpPost]
	        [Route("Login")]
	        public IActionResult LoginUser(string Email, string Password)
	        {
	            var loginUser = _context.Users.SingleOrDefault(user => user.Email == Email);
	            if(loginUser == null)
                {
                    TempData["EmailError"] = "Invalid email!";
                    return RedirectToAction("Index");
                }
                
                else
                {
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    if (0 != hasher.VerifyHashedPassword(loginUser, loginUser.Password, Password))
                    {
	                    HttpContext.Session.SetString("UserName",loginUser.First_Name);
	                    HttpContext.Session.SetInt32("UserID", loginUser.UsersId);     //     REFERENCE THIS FOR SESSION IN EVERY ROUTE
	                    return RedirectToAction("Dashboard_Page");
	                }
                    else
	                {
	                    TempData["PasswordError"] = "Invalid password";
	                    return RedirectToAction("Index");
	                }
                }
            }


//__________________DASHBOARD___________________________________________________________________________________________

    [HttpGet]
	        [Route("Dashboard_Page")]
	        public IActionResult Dashboard_Page()

	        {
	            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");
                List<Wedding> weddings = _context.Weddings.Include(h => h.User).Include(w => w.Guests).ToList();
                List<Guest> guests = _context.Guests.Include(p=> p.Wedding).Include(j=> j.User).ToList();
                List<User> users = _context.Users.Include(o => o.Weddings).ToList();

                Wrapper model = new Wrapper(users,guests,weddings);

	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
	            else
                {
                    ViewBag.UserId = userID;// Integar for session
                    User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                    ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
                    ViewBag.Guests = guests;
	                ViewBag.User = thisuser; 
                    ViewBag.UserName = currentUser.First_Name; // USERNAME STRING
                    ViewBag.Guests = guests;
                    ViewBag.Weddings = weddings; // takes from LIST ALL WEDDING
                
	            }
                return View(model);
	        }
//______________________DASHBOARD_______________________________________________________________________________________

     [HttpGet]
        [Route("/{id}")]
        public IActionResult Single_Wedding(int id) //WEDDING PAGE
        {
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
            int? userID = HttpContext.Session.GetInt32("UserID");
            if(userID == null) 
            {
                TempData["UserError"] = "You are not logged in!";      
            }
            else
            {
            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
            Wedding thisWedding = _context.Weddings.SingleOrDefault(t => t.Id == id); //all guests in this wedding
            List<Guest> guests = _context.Guests.Where(g => g.WeddingId == (int)id).Include(g => g.User).ToList(); 
            // anytime you want a list with multiple objects WHere list through many things and .tolist
            //single 


            // gets current userID fr session
            //gets Current wedding
            //gets guest list for page. 
            
            ViewBag.User = currentUser; // Int OBJECT PK
            ViewBag.UserName = currentUser.First_Name; // USERNAME STRING
            ViewBag.Wedding= thisWedding;
            ViewBag.Guests = guests;
            return View("Single_Wedding");
            }
            ViewBag.User = thisuser; // Int OBJECT PK

            return View("Single_Wedding");
        }
    
    [HttpGet]
    [Route("add_guest/{id}")]

    public IActionResult RSVP(int id, Guest model){ //RSVP PAGE
            //All coming from the WEdding model 
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
            int? userID = HttpContext.Session.GetInt32("UserID");

            if(userID == null) {
                TempData["UserError"] = "You are not logged in!";      
            }

            else
            {

            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID); // gets whole object
            Wedding thisWedding = _context.Weddings.SingleOrDefault(wed => wed.Id == (int)id); //gets this weddung passed from parameters
            ViewBag.User = currentUser; 
            List<Guest> guests = _context.Guests.Where(g => g.WeddingId == (int)id).Include(g => g.User).ToList(); // is used when Id/any attribute is passing through top
      
            Guest newGuest = new Guest {
                    GuestId = currentUser.UsersId,
                    WeddingId= thisWedding.Id,
                    UserId= currentUser.UsersId,
                    Wedding = thisWedding,
                    User = currentUser,       //using current user. imported Object attribute --> session PK       
                     };

            _context.Add(newGuest);
            _context.SaveChanges();
        
            TempData["Success"]="Successfully RSVPed";
            return RedirectToAction("Single_Wedding");

            }
        return RedirectToAction("Single_Wedding");
    }

//____________ALLLLLLL DELETES GO HERE_________________________________________________________________________________________________

    [HttpGet]
    [Route("delete/{id}")]
    public IActionResult Delete(int id){
            //All coming from the WEdding model 
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
            int? userID = HttpContext.Session.GetInt32("UserID");

            if(userID == null) {
                TempData["UserError"] = "You are not logged in!";      
            }

            else{
            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
            ViewBag.UserId = currentUser; //Plugs in the User ID

            Wedding thisWedding = _context.Weddings.SingleOrDefault(var => var.Id == (int)id);
            _context.Remove(thisWedding);
            _context.SaveChanges();
            TempData["WeddingRemoved"] = "You have successfully removed this wedding";
            return RedirectToAction("Dashboard_Page");
            }
        return RedirectToAction("Dashboard_Page");
    }

     [HttpGet]
    [Route("leave_guest/{Id}")] //Wedding GUEST ID ATT
    public IActionResult Delete_RSVP(int Id)
    { //Wedding OBJECT. Wedding.GuestId
            //All coming from the WEdding model 
            int? userID = HttpContext.Session.GetInt32("UserID");

            if(userID == null) {
                TempData["UserError"] = "You are not logged in!";      
            }

            else{
            Wedding thiswedding =_context.Weddings.SingleOrDefault(Wed =>Wed.Id == (int)Id);
            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
            ViewBag.UserId = currentUser; //Plugs in the User ID

            // Wedding thisWedding = _context.Weddings.SingleOrDefault(var => var.Id == (int)id);
            // Guest thisGuest = _context.Guests.SingleOrDefault(x => x.GuestId == (int)Id);
            List<Guest> thisweddingguests = _context.Guests.Where(x => x.WeddingId == (int)Id).ToList();
            Guest singleguest = thisweddingguests.SingleOrDefault(sg => sg.GuestId == ViewBag.UserId.UsersId);
            

            TempData["LEAVERSVP"]= "You Will Now Not Be Attending The Wedding";
            _context.Remove(singleguest);
            _context.SaveChanges();
            return RedirectToAction("Dashboard_Page");
            }
    return RedirectToAction("Dashboard_Page");

    }

//_____________________________________________________________________________________________________________

        [HttpGet]
        [Route("Add_Wedding")]

        public IActionResult Add_Wedding(){

            int? userID = HttpContext.Session.GetInt32("UserID"); //transfer session
            string thisuser = HttpContext.Session.GetString("UserName"); 
            ViewBag.User = thisuser;
         User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);

            ViewBag.UserName = currentUser.First_Name; // USERNAME STRING


            if(userID == null)
            {
                return RedirectToAction("Index");
            }

            else
            {
            return View();
            }
        }


        [HttpPost]
        [Route("Create_Wedding")]

        public IActionResult Create_Wedding(WeddingViewModel model){ //When adding any Object that NEEDs validation. USe THE VIEW model. Not Base Model. CHANGE
            int? userID = HttpContext.Session.GetInt32("UserID");
            string thisuser = HttpContext.Session.GetString("UserName"); 
            if(userID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
            User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID); //Setting Current user to a single ID/PK. with it comes the whole object.
            ViewBag.User = thisuser;
            if(TryValidateModel(model))
            {
               Wedding makeWedding= new Wedding 
               {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Address = model.Address,
                    Date = model.Date,
                    HostId = currentUser.UsersId,
                    HostName = currentUser.First_Name,
                };

                    _context.Weddings.Add(makeWedding);
                    _context.SaveChanges();
                    TempData["Success"]="Successfully Created A Wedding";

                    return RedirectToAction("Dashboard_page");

                }    
            }
                return RedirectToAction("Dashboard_page");
     }


//__________________________________________________________________________________________________________________________

            [HttpGet]
            [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }

       }

}
    
