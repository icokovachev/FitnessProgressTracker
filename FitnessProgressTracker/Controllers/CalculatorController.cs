using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessProgressTracker.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Calculator //Added funcionality
           (int age,double weight,      //TODO: Textboxes in ui
            double height, double neck, 
            double waist, double hip)
        {
            ViewData["Message"] = "This is the " +
                "calculator page.";

            return View();
        }
    }
}