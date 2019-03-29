﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessProgressTracker.Models;

namespace FitnessProgressTracker.Controllers
{
    public class CalculatorModelsController : Controller
    {
        private readonly CalculatorContext _context;

        public CalculatorModelsController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: CalculatorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalculatorModel.ToListAsync());
        }

        // GET: CalculatorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatorModel = await _context.CalculatorModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calculatorModel == null)
            {
                return NotFound();
            }

            return View(calculatorModel);
        }

        // GET: CalculatorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalculatorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Height,Weight,Waist,Hip,Neck,BodyFatPer,BodyFatMass,LeanMass")] CalculatorModel calculatorModel)
        {
            if (ModelState.IsValid)
            {

                Math.Round(calculatorModel.BodyFatPer = (calculatorModel.Weight / Math.Pow(calculatorModel.Height, 2)) * 10000, 2);
                Math.Round(calculatorModel.BodyFatMass = (calculatorModel.BodyFatPer / 100) * calculatorModel.Weight, 2);
                Math.Round(calculatorModel.LeanMass = calculatorModel.Weight - calculatorModel.BodyFatMass, 2);
                _context.Add(calculatorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculatorModel);
        }

        // GET: CalculatorModels/Edit/5        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatorModel = await _context.CalculatorModel.FindAsync(id);
            if (calculatorModel == null)
            {
                return NotFound();
            }
            return View(calculatorModel);
        }

        // POST: CalculatorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: CalculatorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculatorModel = await _context.CalculatorModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (calculatorModel == null)
            {
                return NotFound();
            }

            return View(calculatorModel);
        }

        // POST: CalculatorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculatorModel = await _context.CalculatorModel.FindAsync(id);
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
