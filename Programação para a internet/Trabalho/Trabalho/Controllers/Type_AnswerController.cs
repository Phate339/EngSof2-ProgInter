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
    public class Type_AnswerController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public Type_AnswerController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Type_Answer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Type_Answer.ToListAsync());
        }

        // GET: Type_Answer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Answer = await _context.Type_Answer
                .SingleOrDefaultAsync(m => m.Type_AnswerID == id);
            if (type_Answer == null)
            {
                return NotFound();
            }

            return View(type_Answer);
        }

        // GET: Type_Answer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Type_Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type_AnswerID,PossibleAnswer")] Type_Answer type_Answer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(type_Answer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Questions");
            }
            return View(type_Answer);
        }

        // GET: Type_Answer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Answer = await _context.Type_Answer.SingleOrDefaultAsync(m => m.Type_AnswerID == id);
            if (type_Answer == null)
            {
                return NotFound();
            }
            return View(type_Answer);
        }

        // POST: Type_Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type_AnswerID,PossibleAnswer")] Type_Answer type_Answer)
        {
            if (id != type_Answer.Type_AnswerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type_Answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Type_AnswerExists(type_Answer.Type_AnswerID))
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
            return View(type_Answer);
        }

        // GET: Type_Answer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Answer = await _context.Type_Answer
                .SingleOrDefaultAsync(m => m.Type_AnswerID == id);
            if (type_Answer == null)
            {
                return NotFound();
            }

            return View(type_Answer);
        }

        // POST: Type_Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type_Answer = await _context.Type_Answer.SingleOrDefaultAsync(m => m.Type_AnswerID == id);
            _context.Type_Answer.Remove(type_Answer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Type_AnswerExists(int id)
        {
            return _context.Type_Answer.Any(e => e.Type_AnswerID == id);
        }
    }
}
