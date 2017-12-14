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
    public class AnswersController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public AnswersController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Answer.Include(a => a.Client).Include(a => a.Survey);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.Client)
                .Include(a => a.Survey)
                .SingleOrDefaultAsync(m => m.AnswerID == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID");
            ViewData["SurveyID"] = new SelectList(_context.Survey, "SurveyID", "SurveyID");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerID,AnswerToClient,ClientID,SurveyID")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", answer.ClientID);
            ViewData["SurveyID"] = new SelectList(_context.Survey, "SurveyID", "SurveyID", answer.SurveyID);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerID == id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", answer.ClientID);
            ViewData["SurveyID"] = new SelectList(_context.Survey, "SurveyID", "SurveyID", answer.SurveyID);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerID,AnswerToClient,ClientID,SurveyID")] Answer answer)
        {
            if (id != answer.AnswerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.AnswerID))
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", answer.ClientID);
            ViewData["SurveyID"] = new SelectList(_context.Survey, "SurveyID", "SurveyID", answer.SurveyID);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer
                .Include(a => a.Client)
                .Include(a => a.Survey)
                .SingleOrDefaultAsync(m => m.AnswerID == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerID == id);
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.AnswerID == id);
        }
    }
}
