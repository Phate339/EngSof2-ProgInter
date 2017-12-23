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
    public class SurveysController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public SurveysController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Survey.Include(s => s.Question).Include(s => s.Turist);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.Question)
                .Include(s => s.Turist)
                .SingleOrDefaultAsync(m => m.SurveyID == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID");
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurveyID,Type_AnswerID,DiseasesID,DateAnswer,TuristID,QuestionID")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", survey.QuestionID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", survey.TuristID);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.SingleOrDefaultAsync(m => m.SurveyID == id);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", survey.QuestionID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", survey.TuristID);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurveyID,Type_AnswerID,DiseasesID,DateAnswer,TuristID,QuestionID")] Survey survey)
        {
            if (id != survey.SurveyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.SurveyID))
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
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", survey.QuestionID);
            ViewData["TuristID"] = new SelectList(_context.Turist, "TuristID", "TuristID", survey.TuristID);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .Include(s => s.Question)
                .Include(s => s.Turist)
                .SingleOrDefaultAsync(m => m.SurveyID == id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survey = await _context.Survey.SingleOrDefaultAsync(m => m.SurveyID == id);
            _context.Survey.Remove(survey);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SurveyExists(int id)
        {
            return _context.Survey.Any(e => e.SurveyID == id);
        }
    }
}
