using Assignment_7_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment_7_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return Content("<h1>This is a demo of ContentResult</h1>");
            }
            else if (id.ToLower() == "plain")
            {
                return Content("<h1>This is a demo of ContentResult</h1>", "text/plain");
            }
            else if (id.ToLower() == "html")
            {
                return Content("<h1>This is a demo of ContentResult</h1>", "text/html");
            }
            else if (id.ToLower() == "xml")
            {
                return Content("<h1>This is a demo of ContentResult</h1>", "text/xml");
            }
            return Content("Invalid content type");
        }

        public IActionResult DownloadFile()
        {
            if (!System.IO.File.Exists(@"e:\lighthouse.jpg"))
            {
                return Content("File to be downloaded not found");
            }
            return File(@"e:\lighthouse.jpg", "image/jpg", "default.jpg");
        }

        public ActionResult Google()
        {
            return Redirect("http://www.google.com");
        }

        public ActionResult StartPage()
        {
            return RedirectToAction("Index", new { id = "xml" });
        }


        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
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