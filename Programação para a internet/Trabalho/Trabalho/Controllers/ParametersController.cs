using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    public class ParametersController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public ParametersController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Parameters
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Parameters.Include(p => p.Answer).Include(p => p.Difficulty);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameters = await _context.Parameters
                .Include(p => p.Answer)
                .Include(p => p.Difficulty)
                .SingleOrDefaultAsync(m => m.ParametersID == id);
            if (parameters == null)
            {
                return NotFound();
            }

            return View(parameters);
        }

        // GET: Parameters/Create
        public IActionResult Create()
        {
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID");
            ViewData["DifficultyID"] = new SelectList(_context.Difficulty, "DifficultyID", "DifficultyID");
            return View();
        }

        // POST: Parameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParametersID,DifficultyID,AnswerID")] Parameters parameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameters);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", parameters.AnswerID);
            ViewData["DifficultyID"] = new SelectList(_context.Difficulty, "DifficultyID", "DifficultyID", parameters.DifficultyID);
            return View(parameters);
        }

        // GET: Parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameters = await _context.Parameters.SingleOrDefaultAsync(m => m.ParametersID == id);
            if (parameters == null)
            {
                return NotFound();
            }
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", parameters.AnswerID);
            ViewData["DifficultyID"] = new SelectList(_context.Difficulty, "DifficultyID", "DifficultyID", parameters.DifficultyID);
            return View(parameters);
        }

        // POST: Parameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParametersID,DifficultyID,AnswerID")] Parameters parameters)
        {
            if (id != parameters.ParametersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametersExists(parameters.ParametersID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", parameters.AnswerID);
            ViewData["DifficultyID"] = new SelectList(_context.Difficulty, "DifficultyID", "DifficultyID", parameters.DifficultyID);
            return View(parameters);
        }

        // GET: Parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameters = await _context.Parameters
                .Include(p => p.Answer)
                .Include(p => p.Difficulty)
                .SingleOrDefaultAsync(m => m.ParametersID == id);
            if (parameters == null)
            {
                return NotFound();
            }

            return View(parameters);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parameters = await _context.Parameters.SingleOrDefaultAsync(m => m.ParametersID == id);
            _context.Parameters.Remove(parameters);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ParametersExists(int id)
        {
            return _context.Parameters.Any(e => e.ParametersID == id);
        }
    }
}
