using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessProgressTracker.Models;

namespace FitnessProgressTracker.Controllers
{
    public class ExerciseTrackerController : Controller
    {
        private readonly ExerciseTrackerContext _context;

        public ExerciseTrackerController(ExerciseTrackerContext context)
        {
            _context = context;
        }

        // GET: ExerciseTracker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exer_tracker.ToListAsync());
        }

        // GET: ExerciseTracker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exer_tracker = await _context.Exer_tracker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exer_tracker == null)
            {
                return NotFound();
            }

            return View(exer_tracker);
        }

        // GET: ExerciseTracker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseTracker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ExerciseTracker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exer_tracker = await _context.Exer_tracker.FindAsync(id);
            if (exer_tracker == null)
            {
                return NotFound();
            }
            return View(exer_tracker);
        }

        // POST: ExerciseTracker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ExerciseTracker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exer_tracker = await _context.Exer_tracker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exer_tracker == null)
            {
                return NotFound();
            }

            return View(exer_tracker);
        }

        // POST: ExerciseTracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exer_tracker = await _context.Exer_tracker.FindAsync(id);
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
