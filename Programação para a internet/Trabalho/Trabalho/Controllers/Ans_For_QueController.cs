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
    public class Ans_For_QueController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public Ans_For_QueController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Ans_For_Que
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Ans_For_Que.Include(a => a.Question).Include(a => a.Type_Answer);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Ans_For_Que/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_For_Que = await _context.Ans_For_Que
                .Include(a => a.Question)
                .Include(a => a.Type_Answer)
                .SingleOrDefaultAsync(m => m.Ans_For_QueID == id);
            if (ans_For_Que == null)
            {
                return NotFound();
            }

            return View(ans_For_Que);
        }

        // GET: Ans_For_Que/Create
        public IActionResult Create()
        {
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionToClient");
            ViewData["Type_AnswerID"] = new SelectList(_context.Type_Answer, "Type_AnswerID", "PossibleAnswer");
            return View();
        }

        // POST: Ans_For_Que/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ans_For_QueID,Type_AnswerID,QuestionID")] Ans_For_Que ans_For_Que)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ans_For_Que);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_For_Que.QuestionID);
            ViewData["Type_AnswerID"] = new SelectList(_context.Type_Answer, "Type_AnswerID", "Type_AnswerID", ans_For_Que.Type_AnswerID);
            return View(ans_For_Que);
        }

        // GET: Ans_For_Que/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_For_Que = await _context.Ans_For_Que.SingleOrDefaultAsync(m => m.Ans_For_QueID == id);
            if (ans_For_Que == null)
            {
                return NotFound();
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_For_Que.QuestionID);
            ViewData["Type_AnswerID"] = new SelectList(_context.Type_Answer, "Type_AnswerID", "Type_AnswerID", ans_For_Que.Type_AnswerID);
            return View(ans_For_Que);
        }

        // POST: Ans_For_Que/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ans_For_QueID,Type_AnswerID,QuestionID")] Ans_For_Que ans_For_Que)
        {
            if (id != ans_For_Que.Ans_For_QueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ans_For_Que);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ans_For_QueExists(ans_For_Que.Ans_For_QueID))
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
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_For_Que.QuestionID);
            ViewData["Type_AnswerID"] = new SelectList(_context.Type_Answer, "Type_AnswerID", "Type_AnswerID", ans_For_Que.Type_AnswerID);
            return View(ans_For_Que);
        }

        // GET: Ans_For_Que/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_For_Que = await _context.Ans_For_Que
                .Include(a => a.Question)
                .Include(a => a.Type_Answer)
                .SingleOrDefaultAsync(m => m.Ans_For_QueID == id);
            if (ans_For_Que == null)
            {
                return NotFound();
            }

            return View(ans_For_Que);
        }

        // POST: Ans_For_Que/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ans_For_Que = await _context.Ans_For_Que.SingleOrDefaultAsync(m => m.Ans_For_QueID == id);
            _context.Ans_For_Que.Remove(ans_For_Que);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Ans_For_QueExists(int id)
        {
            return _context.Ans_For_Que.Any(e => e.Ans_For_QueID == id);
        }
    }
}
