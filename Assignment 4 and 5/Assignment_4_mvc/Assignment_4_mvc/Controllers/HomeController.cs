using Assignment_4_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_4_mvc.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext context = new MyDbContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(context.AccountTable);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateAccount(Account a)
        {
            context.AccountTable.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? accno)
        {
            var account_to_edit = (from a in context.AccountTable
                                   where a.AccountNumber == accno
                                   select a).SingleOrDefault();
            return View(account_to_edit);
        }

        public ActionResult EditAccount(Account a)
        {
            context.Entry<Account>(a).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? accno)
        {
            var account_to_delete = (from a in context.AccountTable
                                     where a.AccountNumber == accno
                                     select a).SingleOrDefault();
            context.Entry<Account>(account_to_delete).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
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