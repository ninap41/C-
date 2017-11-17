using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BeltExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore; //this is magic
using System.Linq;

namespace BeltExam.Controllers
{   
      public class HomeController : Controller
    {

        private readonly BeltExamContext _context;
 
        public HomeController(BeltExamContext context) //Constructor.
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
                    User_Level = null,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                if(newUser.UsersId == 1){
                    newUser.User_Level = "Admin";
                }
                else{
                    newUser.User_Level = "Normal";
                }
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


//__________________DASHBOARD/HomePage___________________________________________________________________________________________

    [HttpGet]
	        [Route("Dashboard_Page")]  //*THIS SHOULD HABE ALL USERS DISPLAYED */
	        public IActionResult Dashboard_Page()

	        {
	            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");
           
	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
	            else
                {
                    List<User> users = _context.Users.Include(u => u.Messages).ToList();
                    List<User> allUsers = _context.Users.ToList();
                    User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                    ViewBag.AllUsers = allUsers;
                    ViewBag.UserId = userID;// Integar for session
                    ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
	                ViewBag.User = thisuser; 
                    ViewBag.UserName = currentUser.First_Name; // USERNAME STRING
                
	            }
                return View();
	        }

//___________________Render Templates________________________________________________________________________
            
            [HttpGet]
            [Route("/Add_User")]
            public IActionResult Add_User(){
                string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");

	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
	            else
                {
                    User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);

                    ViewBag.UserId = userID;// Integar for session
                    ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
	                ViewBag.User = thisuser; 
                    ViewBag.UserName = currentUser.First_Name; 
                    return View();

                }
            }




            [HttpGet]
            [Route("/edit_profile/{UsersId}")]
            public IActionResult Edit_Profile(int UsersId)
            {
                string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	            int? userID = HttpContext.Session.GetInt32("UserID");

	            if(thisuser == null) //if not logged or registered
	            {
	                return RedirectToAction("Index");
	            }
                else{

                User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                User editUser = _context.Users.SingleOrDefault(sin => sin.UsersId == (int)UsersId);
                ViewBag.UserToBeEdited = editUser;
                ViewBag.UserId = userID;// Integar for session
                ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
	            ViewBag.User = thisuser; 
                ViewBag.UserName = currentUser.First_Name;
                }
                return View();
            }





             [HttpGet]
        [Route("/profile/{UsersId}")]
        public IActionResult User_Profile(int UsersId) //WEDDING PAGE
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
            User PageUser = _context.Users.SingleOrDefault(tu => tu.UsersId == (int)UsersId);
        
          
            List<User> users = _context.Users.Include(m=>m.Messages).Include(ch=> ch.Comments).ToList(); //Makes a list of comments and Messaged from this user.
            List<Message> thisUsersMessages = _context.Messages.Where(m => m.Posted_For == UsersId).Include(m => m.Comments).ThenInclude(c => c.User).ToList();
            List<Comment> comments =_context.Comments.Include( z => z.Message).Include(what => what.User).ToList();
            // List<Comment> thismessagescomments =_context.Comments.Where( z => z.Message).Include(what => what.User).ToList();


            // Wrapper model= new Wrapper(users,messages,comments);

            ViewBag.UserId = userID;// Integar for session
            ViewBag.IdOfUser = currentUser; //WHOLE OBJECT
	        ViewBag.User = thisuser; 
            ViewBag.UserName = currentUser.First_Name; // USERNAME STRING
            ViewBag.Messages= thisUsersMessages;

            // ViewBag.Comments = thisMessagesComments;
            ViewBag.PageUser = PageUser;
            return View("User_Profile");
            }
            ViewBag.User = thisuser; // Int OBJECT PK

            return View("User_Profile");
        }





//______________________Create Object_______________________________________________________________________________________
       
       
       
       
       
        [HttpPost]
        [Route("Create_User")]
        public IActionResult Create_User(RegisterUser registeringUser)
        {
            if(TryValidateModel(registeringUser))
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User newUser = new User {
                    First_Name = registeringUser.First_Name,
                    Last_Name = registeringUser.Last_Name,
                    Email = registeringUser.Email.ToLower(),
                    User_Level=registeringUser.User_Level,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                newUser.Password = hasher.HashPassword(newUser, registeringUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                TempData["Created_User1"] = "CoolBeans,";
                TempData["Created_User2"] = "you made a new user.";
                return RedirectToAction("Dashboard_Page");
            } 
            else 
                {
                TempData["Unsuccess"] = "Something Didnt Go Right. Try Again Please.";
                return RedirectToAction("Index");
                }
            }




            [HttpPost]
            [Route("edit/{UsersId}")]

            public IActionResult Edit_User(User model, int UsersId){
                string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
                int? userID = HttpContext.Session.GetInt32("UserID");
            if(userID == null) 
                {
                TempData["UserError"] = "You are not logged in!";  
                return View("Index");    
                }
            else
                {
                User updateUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)UsersId);

                updateUser.First_Name= model.First_Name;
                updateUser.Last_Name= model.Last_Name;
                updateUser.Email= model.Email;
                updateUser.User_Level= model.User_Level;
                updateUser.Description= model.Description;

                _context.Update(updateUser);
                _context.SaveChanges();

                TempData["EditSuccess"] = "Successful Update";
                return RedirectToAction("Edit_Profile");
            
                }
            }



            [HttpPost]
            [Route("user_page/{UsersId}/create_message")]
            public IActionResult Create_Message(int UsersId, Message model)
            {
                int? userID = HttpContext.Session.GetInt32("UserID");
                string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
                User UserBeingMessaged = _context.Users.SingleOrDefault(user => user.UsersId == (int)UsersId);
                User currentUser= _context.Users.SingleOrDefault(use => use.UsersId == (int)userID);
                if(userID == null) 
                {
                    TempData["UserError"] = "You are not logged in!";  
                    return View("Index");    
                }
                else{
                
                    Message newMessage = new Message 
                    {
                        UserId = currentUser.UsersId,
                        Creator = currentUser,
                        Posted_For = UserBeingMessaged.UsersId,
                        Content = model.Content,
                        Created_At= DateTime.Now,
                        Updated_At= DateTime.Now
                    };
                        _context.Add(newMessage);
                        _context.SaveChanges();
                        TempData["ItWorked"]= "Thanks For Posting A Message To The Page!";
                        return RedirectToAction("User_Profile");

                    
                }
            }



            [HttpPost]
            [Route("comment_on/{MessageId}")]
            public IActionResult Create_Comment(int messageid, Comment model)
            {
                int? userID = HttpContext.Session.GetInt32("UserID");
                string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
                Message MessageBeingCommented = _context.Messages.Single(c => c.MessageId== (int)messageid);
                User currentUser= _context.Users.SingleOrDefault(use => use.UsersId == (int)userID);
                if(userID == null) 
                {
                    TempData["UserError"] = "You are not logged in!";  
                    return View("Index");    
                }
                else{

                    Comment newComment = new Comment
                    {
                        MessageId= MessageBeingCommented.MessageId,
                        Message = MessageBeingCommented,
                        UserId = currentUser.UsersId,
                        User = currentUser,
                        Content = model.Content,
                        Created_At= DateTime.Now,
                        Updated_At= DateTime.Now
                    };
                        _context.Add(newComment);
                        _context.SaveChanges();
                        TempData["ItWorked2"]= "Thanks For Posting A Comment To The Page!";
                        return RedirectToAction("User_Profile");
                }
                
            }


             [HttpGet]
        [Route("edit/{MessageId}")]
        public IActionResult DeleteMessage( int messageId, Message model)
        {
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	        int? userID = HttpContext.Session.GetInt32("UserID");
	        if(thisuser == null) //if not logged or registered
	        {
	                return RedirectToAction("Index");
	        }
            else
            {
                
                if(ModelState.IsValid){
                User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                ViewBag.UserId = currentUser;
                // Message editMes = _context.Messages.SingleOrDefault(u => u.MessageId == (int)messageId);
                Message editMessage = new Message {
                    Creator = currentUser,
                    MessageId = model.MessageId,
                    Updated_At = DateTime.Now,
                    Content = model.Content,
                };
                _context.Update(editMessage);
                _context.SaveChanges();
                TempData["MEsDL"]= "Message Deleted";
                return RedirectToAction("Dashboard_Page"); 
                }
                return RedirectToAction("Dashboard_Page"); 
            }

        }

//____________Delete Objects_________________________________________________________________________________________________


        [HttpGet]
        [Route("remove_profile/{UsersId}")]
        public IActionResult DeleteUser(int UsersId)
        {
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	        int? userID = HttpContext.Session.GetInt32("UserID");
	        if(thisuser == null) //if not logged or registered
	        {
	                return RedirectToAction("Index");
	        }
            else
            {
                User delUser = _context.Users.SingleOrDefault(u => u.UsersId == UsersId);
                _context.Remove(delUser);
                _context.SaveChanges();
                TempData["Deleted"] = "Deleted This User Successfully";
                return RedirectToAction("Dashboard_Page"); 
            }

        }

         [HttpGet]
        [Route("delete/{MessageId}")]
        public IActionResult DeleteMessage( int messageId)
        {
            string thisuser = HttpContext.Session.GetString("UserName"); //transfer session
	        int? userID = HttpContext.Session.GetInt32("UserID");
	        if(thisuser == null) //if not logged or registered
	        {
	                return RedirectToAction("Index");
	        }
            else
            {
                if(ModelState.IsValid){
                User currentUser = _context.Users.SingleOrDefault(user => user.UsersId == (int)userID);
                ViewBag.UserId = currentUser;
                Message delMes = _context.Messages.SingleOrDefault(u => u.MessageId == (int)messageId);
                _context.Remove(delMes);
                _context.SaveChanges();
                TempData["MEsDL"]= "Message Deleted";
                return RedirectToAction("Dashboard_Page"); 
                }
                return RedirectToAction("Dashboard_Page"); 
            }

        }

  

//_________________LogOut_________________________________________________________________________________________________________

            [HttpGet]
            [Route("Logout")]
            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }

       }

}
    
