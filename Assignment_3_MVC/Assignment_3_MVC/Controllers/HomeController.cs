using Assignment_3_MVC.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment_3_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["str1"] = "This is a string passed using ViewData";
            ViewData["num1"] = 100;

            ViewBag.str2 = "This is a string passed using ViewBag";
            ViewBag.num2 = 200;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public ActionResult SaveUser(User u)
{
   StreamWriter sw = new 
	StreamWriter("C://Users//chandan//Documents//App_data//user.txt");
   sw.WriteLine("User details added on: " + 
	DateTime.Now.ToString());
   sw.WriteLine("User name: " + u.UserName);
   sw.WriteLine("Password: " + u.Password);
   sw.WriteLine();
   sw.Close();
   return Content("User details have been saved");
}

        public IActionResult HtmlHelpers()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}