using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;
using UserDashboard.Factory;


namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;

        public HomeController(DbConnector connect)
        {
            userFactory = new UserFactory();

        }

        // private readonly DbConnector _dbConnector;
 
        // public YourController(DbConnector connect)
        // {
        //     _dbConnector = connect;
        // }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("signin")]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpGet]
        [Route("goregister")]
        public IActionResult GoRegister(string firstname, string lastname, string email, string password, string pwconfirm)
        {
            User newUser = new User
                {
                    firstname = firstname,
                    lastname = lastname,
                    email = email,
                    password = password,
                    pwconfirm = pwconfirm,
                };
                TryValidateModel(newUser);
                ViewBag.errors = ModelState.Values;
                // if(ModelState.IsValid){
                //     PasswordHasher<User> Hasher = new PasswordHasher<User>();
                //     newUser.password = Hasher.HashPassword(newUser,newUser.password);
                //     userFactory.Add(newUser);
                //     int userId = userFactory.GetLastId();
                //     HttpContext.Session.SetInt32("userId", userId);
                //     return RedirectToAction("Success");
                // }
            return View("Register");
        }
    }
}
