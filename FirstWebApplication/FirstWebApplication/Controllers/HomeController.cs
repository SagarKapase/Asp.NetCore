using FirstWebApplication.DataDbContext;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var model = new Employees();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(Employees model)
        {
            if (ModelState.IsValid)
            {
                //Add the employee to the database
                try
                {
                    applicationDbContext.Employees.Add(model);
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

        public async Task<IActionResult> ShowEmployees()
        {
            try
            {
                List<Employees> allEmployees = await applicationDbContext.Employees.ToListAsync();
                return View(allEmployees);
            }
            catch(Exception ex)
            {
                return View("Error while fetching the data from db");
            }
            
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    applicationDbContext.Employees.Remove(employee);
                    applicationDbContext.SaveChanges();
                }
                return RedirectToAction("ShowEmployees");
            }catch (Exception ex)
            {
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
