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
    public class Que_DisController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public Que_DisController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Que_Dis
        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Que_Dis.Include(q => q.Diseases).Include(q => q.Question);
            return View(await trabalhoDbContext.ToListAsync());
        }

        // GET: Que_Dis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var que_Dis = await _context.Que_Dis
                .Include(q => q.Diseases)
                .Include(q => q.Question)
                .SingleOrDefaultAsync(m => m.Que_DisID == id);
            if (que_Dis == null)
            {
                return NotFound();
            }

            return View(que_Dis);
        }

        // GET: Que_Dis/Create
        public IActionResult Create()
        {
            ViewData["DiseasesID"] = new SelectList(_context.Diseases, "DiseasesID", "DiseasesName");
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionToClient");
            return View();
        }

        // POST: Que_Dis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Que_DisID,QuestionID,DiseasesID")] Que_Dis que_Dis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(que_Dis);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DiseasesID"] = new SelectList(_context.Diseases, "DiseasesID", "DiseasesName", que_Dis.DiseasesID);
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionToClient", que_Dis.QuestionID);
            return View(que_Dis);
        }

        // GET: Que_Dis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var que_Dis = await _context.Que_Dis.SingleOrDefaultAsync(m => m.Que_DisID == id);
            if (que_Dis == null)
            {
                return NotFound();
            }
            ViewData["DiseasesID"] = new SelectList(_context.Diseases, "DiseasesID", "DiseasesID", que_Dis.DiseasesID);
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", que_Dis.QuestionID);
            return View(que_Dis);
        }

        // POST: Que_Dis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Que_DisID,QuestionID,DiseasesID")] Que_Dis que_Dis)
        {
            if (id != que_Dis.Que_DisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(que_Dis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Que_DisExists(que_Dis.Que_DisID))
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
            ViewData["DiseasesID"] = new SelectList(_context.Diseases, "DiseasesID", "DiseasesID", que_Dis.DiseasesID);
            ViewData["QuestionID"] = new SelectList(_context.Question, "QuestionID", "QuestionID", que_Dis.QuestionID);
            return View(que_Dis);
        }

        // GET: Que_Dis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var que_Dis = await _context.Que_Dis
                .Include(q => q.Diseases)
                .Include(q => q.Question)
                .SingleOrDefaultAsync(m => m.Que_DisID == id);
            if (que_Dis == null)
            {
                return NotFound();
            }

            return View(que_Dis);
        }

        // POST: Que_Dis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var que_Dis = await _context.Que_Dis.SingleOrDefaultAsync(m => m.Que_DisID == id);
            _context.Que_Dis.Remove(que_Dis);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Que_DisExists(int id)
        {
            return _context.Que_Dis.Any(e => e.Que_DisID == id);
        }
    }
}
