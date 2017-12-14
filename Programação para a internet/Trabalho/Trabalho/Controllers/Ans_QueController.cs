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
    public class Ans_QueController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public Ans_QueController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Ans_Que
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Ans_Que.Include(a => a.Question);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Ans_Que/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_Que = await _context.Ans_Que
                .Include(a => a.Question)
                .SingleOrDefaultAsync(m => m.Ans_QueID == id);
            if (ans_Que == null)
            {
                return NotFound();
            }

            return View(ans_Que);
        }

        // GET: Ans_Que/Create
        public IActionResult Create()
        {
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID");
            return View();
        }

        // POST: Ans_Que/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ans_QueID,ResPer,QuestionID")] Ans_Que ans_Que)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ans_Que);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_Que.QuestionID);
            return View(ans_Que);
        }

        // GET: Ans_Que/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_Que = await _context.Ans_Que.SingleOrDefaultAsync(m => m.Ans_QueID == id);
            if (ans_Que == null)
            {
                return NotFound();
            }
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_Que.QuestionID);
            return View(ans_Que);
        }

        // POST: Ans_Que/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ans_QueID,ResPer,QuestionID")] Ans_Que ans_Que)
        {
            if (id != ans_Que.Ans_QueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ans_Que);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ans_QueExists(ans_Que.Ans_QueID))
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
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", ans_Que.QuestionID);
            return View(ans_Que);
        }

        // GET: Ans_Que/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ans_Que = await _context.Ans_Que
                .Include(a => a.Question)
                .SingleOrDefaultAsync(m => m.Ans_QueID == id);
            if (ans_Que == null)
            {
                return NotFound();
            }

            return View(ans_Que);
        }

        // POST: Ans_Que/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ans_Que = await _context.Ans_Que.SingleOrDefaultAsync(m => m.Ans_QueID == id);
            _context.Ans_Que.Remove(ans_Que);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Ans_QueExists(int id)
        {
            return _context.Ans_Que.Any(e => e.Ans_QueID == id);
        }
    }
}
