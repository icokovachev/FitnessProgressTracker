using FitnessProgressTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FitnessProgressTracker.Controllers
{
    /// <summary>
    /// Main controller; Calls for the basic pages;
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Calls for the Index page of the Main controller;
        /// </summary>
        /// <returns> View(); </returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Calls for the About page of the Home View;
        /// </summary>
        /// <returns> View with Massage </returns>
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Calls for the Contact page of the Home View;
        /// </summary>
        /// <returns> View() + Massage </returns>
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Error handler; 
        /// </summary>
        /// <returns> View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }) </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
