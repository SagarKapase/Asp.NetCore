using FirstWebApplication.DataDbContext;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            var model = new AddEmployee();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(AddEmployee model)
        {
            if (ModelState.IsValid)
            {
                //Add the employee to the database
                try
                {
                    applicationDbContext.AddEmployees.Add(model);
                    applicationDbContext.SaveChanges();
                    return RedirectToAction("Success");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
            return View(model);
        }

        public IActionResult Success()
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
