using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;
using Microsoft.AspNetCore.Identity;

namespace Trabalho.Controllers
{
    public class TuristsController : Controller
    {
 
        private readonly TrabalhoDbContext _context;

        public TuristsController( TrabalhoDbContext context)
        {
     
            _context = context;    
        }

        // GET: Turists
        public async Task<IActionResult> Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            var turist = from s in _context.Turist
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                turist = turist.Where(s => s.TuristName.Contains(searchString) || s.Email.Contains(searchString));
            }

            return View(await turist.AsNoTracking().ToListAsync());
        }

        // GET: Turists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = await _context.Turist
                .SingleOrDefaultAsync(m => m.TuristID == id);
            if (turist == null)
            {
                return NotFound();
            }

            return View(turist);
        }

        // GET: Turists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristID,TuristName,Phone,Genre,Birthday,NIF,Email,EmergencyContact,TuristState,TypeTurist")] Turist turist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(turist);
        }

        // GET: Turists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = await _context.Turist.SingleOrDefaultAsync(m => m.TuristID == id);
            if (turist == null)
            {
                return NotFound();
            }
            return View(turist);
        }

        // POST: Turists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristID,TuristName,Phone,Genre,Birthday,NIF,Email,EmergencyContact,TuristState,TypeTurist")] Turist turist)
        {

            if (id != turist.TuristID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
           
                    _context.Update(turist);


                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristExists(turist.TuristID))
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
            return View(turist);
        }

        // GET: Turists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = await _context.Turist
                .SingleOrDefaultAsync(m => m.TuristID == id);
            if (turist == null)
            {
                return NotFound();
            }

            return View(turist);
        }

        // POST: Turists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turist = await _context.Turist.SingleOrDefaultAsync(m => m.TuristID == id);
            _context.Turist.Remove(turist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TuristExists(int id)
        {
            return _context.Turist.Any(e => e.TuristID == id);
        }
    }
}
