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
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.TuristAnswer.Where(t => t.TuristID == 2).Include(t => t.Answer).ThenInclude(y => y.Questions);
            //var trabalhoDbContext = _context.TuristAnswer.Include(t => t.Answer).Where(r=>r.AnswerID==r.Answer.AnswerID).Include(t => t.Turist);
            return View(await trabalhoDbContext.ToListAsync());
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
        public async Task<IActionResult> Create(string sortOrder, string currentFilter, string searchString, int? page)
        {
            /* ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID");
              ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID");
              return View();*/
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // var listofdata = from z in _context.TuristAnswer.Where(q => q.Answer.Questions.QuestionsState == true).Include(t => t.Answer).ThenInclude(q => q.Questions).ThenInclude(a => a.Answer).ThenInclude(d => d.Difficulty)
            //      select z;

            var lista = from z in _context.Questions.Where(q => q.QuestionsState == true).Include(a => a.Answer) select z;


            int pageSize = 1;

            return View(await PaginatedList<Questions>.CreateAsync(lista.AsNoTracking(), page ?? 1, pageSize)); 
        }

        // POST: TuristAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string sortOrder, string currentFilter, string searchString, int? page, bool concluir, [Bind("TuristAnswerID,SurveyNumber,AnswerDate,TuristAnswerState,TuristID,AnswerID")] TuristAnswer turistAnswer)
        {
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var listofdata = from z in _context.TuristAnswer.Include(t => t.Answer).ThenInclude(q => q.Questions).ThenInclude(a => a.Answer).ThenInclude(d => d.Difficulty)
                             select z;

            var lista = from z in _context.Questions.Include(a => a.Answer) select z;

            int pageSize = 1;


            if (ModelState.IsValid && ModelState.Count > 0)
            {
                if (turistAnswer.AnswerID != 0)
                {


                    turistAnswer.SurveyNumber = 1;
                    turistAnswer.AnswerDate = System.DateTime.Today;
                    turistAnswer.TuristID = 2;
                    turistAnswer.TuristAnswerState = true;
                    _context.Add(turistAnswer);
                    await _context.SaveChangesAsync();
                }





            }
            if (concluir)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(await PaginatedList<Questions>.CreateAsync(lista.AsNoTracking(), page ?? 1, pageSize));
                /* ViewData["AnswerID"] = new SelectList(_context.Answer, "AnswerID", "AnswerID", turistAnswer.AnswerID);
                 ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", turistAnswer.TuristID);*/
            }
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
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "Email", turistAnswer.TuristID);
            return View(turistAnswer);
        }

        // POST: TuristAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristAnswerID,SurveyNumber,AnswerDate,TuristAnswerState,TuristID,AnswerID")] TuristAnswer turistAnswer)
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
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "Email", turistAnswer.TuristID);
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
            var turistAnswer2 = _context.TuristAnswer;
            foreach(var id2 in turistAnswer2.Where(a => a.TuristID==id))
            {
                var turistAnswer = await _context.TuristAnswer.SingleOrDefaultAsync(m => m.TuristAnswerID == id2.TuristAnswerID);
                _context.TuristAnswer.Remove(turistAnswer);
            }
            
            
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TuristAnswerExists(int id)
        {
            return _context.TuristAnswer.Any(e => e.TuristAnswerID == id);
        }
    }
}
