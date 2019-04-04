using FitnessProgressTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessProgressTracker.Controllers
{
    /// <summary>
    /// This is the Exercise Tracker controller;
    /// </summary>
    public class ExerciseTrackerController : Controller
    {
        /// <summary>
        /// Creates the DB context for Exercise Tracker
        /// </summary>
        private readonly ExerciseTrackerContext _context;

        /// <summary>
        /// Initializes the DB context
        /// </summary>
        /// <param name="context"></param>
        public ExerciseTrackerController(ExerciseTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Calls for the Index page of the Exercise Tracker View;
        /// </summary>
        /// <returns> View(await _context.Exer_tracker.ToListAsync()) </returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exer_tracker.ToListAsync());
        }

        /// <summary>
        /// Checks if the id of the DB entry is valid;
        /// if it is calls for the Details view of the Exercise Tracking View;
        /// if it is not - calls for the Not Found /404/ page;
        /// </summary>
        /// <param name="id"></param>
        /// <returns> View(exer_tracker) </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exer_tracker exer_tracker = await _context.Exer_tracker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exer_tracker == null)
            {
                return NotFound();
            }

            return View(exer_tracker);
        }

        /// <summary>
        /// Calls for the Create page of the Exercise Tracker View;
        /// </summary>
        /// <returns> View(); </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Main function of this Controller;
        /// It creates new DB entry with given variables ("ID,DOB,exercise,repeats,load,time_between")
        /// </summary>
        /// <param name="exer_tracker"></param>
        /// <returns> View(exer_tracker); </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DOB,exercise,repeats,load,time_between")] Exer_tracker exer_tracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exer_tracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exer_tracker);
        }

        /// <summary>
        /// Calls for the Edit page in Exercise Tra View;
        /// Checks the ID of the database entry and returns the view;        
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exer_tracker exer_tracker = await _context.Exer_tracker.FindAsync(id);
            if (exer_tracker == null)
            {
                return NotFound();
            }
            return View(exer_tracker);
        }

        /// <summary>
        /// This method calls for the Edit page of the Exercise Tracker view;
        /// Checks the id of the DB entry and gives the view with the opiton for the user to change the variables
        /// ("ID,DOB,exercise,repeats,load,time_between")
        /// Than it pass the entry back to the DB with the changes and takes the user to the Index page of Exercise Tracker View; 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exer_tracker"></param>
        /// <returns> View(exer_tracker) </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DOB,exercise,repeats,load,time_between")] Exer_tracker exer_tracker)
        {
            if (id != exer_tracker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exer_tracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exer_trackerExists(exer_tracker.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exer_tracker);
        }

        /// <summary>
        /// Checks if the id of the db entry is valid
        /// Than calls for the Delete page of the Exercise Tracker View;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exer_tracker exer_tracker = await _context.Exer_tracker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exer_tracker == null)
            {
                return NotFound();
            }

            return View(exer_tracker);
        }

        /// <summary>
        /// This is the Delete function of the Exercise tracker controller; 
        /// checks if the id of the db entry is valid
        /// than waits for confirmation form the user
        /// if confirmation is given - it deletes the db entry
        /// if not - returns to the Index page
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return _context.Exer_tracker.Any(e => e.ID == id) </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Exer_tracker exer_tracker = await _context.Exer_tracker.FindAsync(id);
            _context.Exer_tracker.Remove(exer_tracker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exer_trackerExists(int id)
        {
            return _context.Exer_tracker.Any(e => e.ID == id);
        }
    }
}
