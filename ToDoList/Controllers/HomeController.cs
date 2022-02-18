using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Work> Works = new List<Work>
        {
            new Work{ Id=1, Task_Name="Do homework",Status="Pending"},
            new Work{ Id=2, Task_Name="Programming Exam",Status="Done"},
            new Work{ Id=3, Task_Name="Clean Disk C",Status="Scheduled"}
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                Works = Works
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddWork(Work work)
        {
            Works.Add(work);
            IndexViewModel model = new IndexViewModel
            {
                Works = Works
            };
            return RedirectToAction("Index","Home");
        }
        public IActionResult DeleteWork(int id)
        {
            Works.Remove(Works.FirstOrDefault(w => w.Id == id));
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
