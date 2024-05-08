using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebappCodeFirst.Models;

namespace WebappCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext StudentDB;

        public HomeController(StudentDbContext StudentDB)
        {
            this.StudentDB = StudentDB;
        }
        public IActionResult Index()
        {
            var stdData = StudentDB.Students.ToList();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(ModelState.IsValid) 
            { 
                  StudentDB.Students.Add(std);
                  StudentDB.SaveChanges();
                  return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var stdData = await StudentDB.Students.FindAsync(id);
            return View(stdData);
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
