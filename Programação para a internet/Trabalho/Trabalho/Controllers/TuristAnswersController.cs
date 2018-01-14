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
    public class TuristAnswersController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public TuristAnswersController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: TuristAnswers
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;

           if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var listofdata =from z in _context.TuristAnswer.Include(t => t.Answer).ThenInclude(q => q.Questions).ThenInclude(a => a.Answer).ThenInclude(d=>d.Difficulty)
                            select z;

            int pageSize = 1;
            return View(await PaginatedList<TuristAnswer>.CreateAsync(listofdata.AsNoTracking(), page ?? 1,pageSize));
        }

        // GET: TuristAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistAnswer = await _context.TuristAnswer
                .Include(t => t.Answer)
                .Include(t => t.Turist)
                .SingleOrDefaultAsync(m => m.TuristAnswerID == id);
            if (turistAnswer == null)
            {
                return NotFound();
            }

            return View(turistAnswer);
        }

        // GET: TuristAnswers/Create
        public IActionResult Create()
        {
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID");
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID");
            return View();
        }

        // POST: TuristAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristAnswerID,SurveyNumber,AnswerDate,TuristID,AnswerID")] TuristAnswer turistAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turistAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", turistAnswer.AnswerID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", turistAnswer.TuristID);
            return View(turistAnswer);
        }

        // GET: TuristAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistAnswer = await _context.TuristAnswer.SingleOrDefaultAsync(m => m.TuristAnswerID == id);
            if (turistAnswer == null)
            {
                return NotFound();
            }
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", turistAnswer.AnswerID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", turistAnswer.TuristID);
            return View(turistAnswer);
        }

        // POST: TuristAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristAnswerID,SurveyNumber,AnswerDate,TuristID,AnswerID")] TuristAnswer turistAnswer)
        {
            if (id != turistAnswer.TuristAnswerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turistAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristAnswerExists(turistAnswer.TuristAnswerID))
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
            ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", turistAnswer.AnswerID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", turistAnswer.TuristID);
            return View(turistAnswer);
        }

        // GET: TuristAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turistAnswer = await _context.TuristAnswer
                .Include(t => t.Answer)
                .Include(t => t.Turist)
                .SingleOrDefaultAsync(m => m.TuristAnswerID == id);
            if (turistAnswer == null)
            {
                return NotFound();
            }

            return View(turistAnswer);
        }

        // POST: TuristAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turistAnswer = await _context.TuristAnswer.SingleOrDefaultAsync(m => m.TuristAnswerID == id);
            _context.TuristAnswer.Remove(turistAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TuristAnswerExists(int id)
        {
            return _context.TuristAnswer.Any(e => e.TuristAnswerID == id);
        }
    }
}
