using FitnessProgressTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessProgressTracker.Controllers
{
    /// <summary>
    /// This is the Calculator controller. It's calculating BMI, Body fat mass and lean mass
    /// </summary>
    public class CalculatorModelsController : Controller
    {
        /// <summary>
        /// Creating the DB context
        /// </summary>
        private readonly CalculatorContext _context;

        /// <summary>
        /// The method takes the previously created private context and creates a initialized parameter
        /// </summary>
        /// <param name="context"></param>
        public CalculatorModelsController(CalculatorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method calls for the Index view from the Calculator
        /// </summary>
        /// <returns>View(await _context.CalculatorModel.ToListAsync());</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalculatorModel.ToListAsync());
        }

        /// <summary>
        /// The method calls for the Details view from the Calculator, takes the ID (if found, if not returns "404 /Not found/")
        /// and gives the 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///         if(id - not found) return NotFound();
        ///         if(id - found ) CalculatorModel calculatorModel = await _context.CalculatorModel.FirstOrDefaultAsync
        ///         (m => m.ID == id);
        /// </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CalculatorModel calculatorModel = await _context.CalculatorModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calculatorModel == null)
            {
                return NotFound();
            }

            return View(calculatorModel);
        }

        /// <summary>
        /// Calls for the Create page in Calculator View
        /// </summary>
        /// <returns> View(); </returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This is the main funciton of the CalculatorModel. Fitst it calls for the Create page in Calculator View. 
        /// Than it takes some variables (ID,Height,Weight, Waist,Hip,Neck,BodyFatPer,"BodyFatMass,LeanMass") and submits them 
        /// to the formulas to be calculated;
        /// Than returns you to the Index page; 
        /// </summary>
        /// <param name="calculatorModel"></param>
        /// <returns> View(calculatorModel) </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ("ID,Height,Weight,Waist,Hip,Neck,BodyFatPer,BodyFatMass,LeanMass" )]CalculatorModel calculatorModel)
        {
            if (ModelState.IsValid)
            {
                calculatorModel.BodyFatPer = Math.Round((calculatorModel.Weight / Math.Pow(calculatorModel.Height, 2)) * 10000, 2);
                calculatorModel.BodyFatMass = Math.Round((calculatorModel.BodyFatPer / 100) * calculatorModel.Weight, 2);
                calculatorModel.LeanMass = Math.Round(calculatorModel.Weight - calculatorModel.BodyFatMass, 2);
                _context.Add(calculatorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculatorModel);
        }

        /// <summary>
        /// Calls for the Edit page in Calculator View;
        /// Checks the ID of the database entry and returns the view;
        /// </summary>
        /// <param name="id"></param>
        /// <returns> View(calculatorModel) </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CalculatorModel calculatorModel = await _context.CalculatorModel.FindAsync(id);
            if (calculatorModel == null)
            {
                return NotFound();
            }
            return View(calculatorModel);
        }

        /// <summary>
        /// This method calls for the Edit page of the Calculator view;
        /// Checks the id of the DB entry and gives the view with the opiton for the user to change the variables
        /// (ID,Height,Weight,Waist,Hip,Neck,BodyFatPer,BodyFatMass,LeanMass );
        /// Than it pass the entry back to the DB with the changes and takes the user to the Index page of Calculator View;
        /// </summary>
        /// <param name="id"></param>
        /// <param name="calculatorModel"></param>
        /// <returns> View(); </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Height,Weight,Waist,Hip,Neck,BodyFatPer,BodyFatMass,LeanMass")] CalculatorModel calculatorModel)
        {
            if (id != calculatorModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculatorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculatorModelExists(calculatorModel.ID))
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
            return View(calculatorModel);
        }

        /// <summary>
        /// Calls for the Delete page in the Calculator View;
        /// </summary>
        /// <param name="id"></param>
        /// <returns> View(calculatorModel) </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            CalculatorModel calculatorModel = await _context.CalculatorModel.FirstOrDefaultAsync(m => m.ID == id);

            if (calculatorModel == null)
            {
                return NotFound();
            }
            return View(calculatorModel);
        }

        /// <summary>
        /// Confirmes the Delete function; Checks and Deletes the given ID from the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns> _context.CalculatorModel.Any(e => e.ID == id) </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CalculatorModel calculatorModel = await _context.CalculatorModel.FindAsync(id);
            _context.CalculatorModel.Remove(calculatorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculatorModelExists(int id)
        {
            return _context.CalculatorModel.Any(e => e.ID == id);
        }
    }
}
