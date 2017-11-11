using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;

namespace TheWall.Controllers
{
    public class WallController : Controller
    { 
        //  public void show()
        // {
        //     string messageQuery = "SELECT messages.id, messages.message, messages.created_at, users_id, users.first_name, users.last_name FROM theWall.messages LEFT JOIN theWall.users ON messages.users_id = users.id";

        //     string commentQuery = "SELECT comments.comment, comments.created_at, comments.messages_id, users.first_name, users.last_name FROM theWall.comments LEFT JOIN users ON comments.users_id = users.id";

        //     List<Dictionary<string, object>> messages = _dbConnector.Query(messageQuery);
        //     List<Dictionary<string, object>> comments = _dbConnector.Query(commentQuery);

        //     ViewBag.Messages = messages;
        //     ViewBag.Comments = comments;
        // }

        private readonly DbConnector _dbConnector;
 
        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
             
        }

        [HttpGet]
        [Route("Wall")]
        public IActionResult Index(User user){

            return View();
        }



    }

}