using Microsoft.AspNetCore.Mvc;
using Assignment_7_mvc.Models;

namespace Assignment_7_mvc.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            Product p = new Product();
            return View(p.GetProducts());
        }
    }
}
