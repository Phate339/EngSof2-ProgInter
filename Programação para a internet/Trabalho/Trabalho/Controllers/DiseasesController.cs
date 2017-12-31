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
    public class DiseasesController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public DiseasesController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: Diseases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseases.ToListAsync());
        }

        // GET: Diseases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseases = await _context.Diseases
                .SingleOrDefaultAsync(m => m.DiseasesID == id);
            if (diseases == null)
            {
                return NotFound();
            }

            return View(diseases);
        }

        // GET: Diseases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiseasesID,DiseasesName,Description,Care")] Diseases diseases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseases);
                await _context.SaveChangesAsync();
                return RedirectToAction("SureView");
            }
            return View(diseases);
        }

        // GET: Diseases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseases = await _context.Diseases.SingleOrDefaultAsync(m => m.DiseasesID == id);
            if (diseases == null)
            {
                return NotFound();
            }
            return View(diseases);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiseasesID,DiseasesName,Description,Care")] Diseases diseases)
        {
            if (id != diseases.DiseasesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseasesExists(diseases.DiseasesID))
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
            return View(diseases);
        }

        // GET: Diseases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseases = await _context.Diseases
                .SingleOrDefaultAsync(m => m.DiseasesID == id);
            if (diseases == null)
            {
                return NotFound();
            }

            return View(diseases);
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diseases = await _context.Diseases.SingleOrDefaultAsync(m => m.DiseasesID == id);
            _context.Diseases.Remove(diseases);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


       public IActionResult SureView()
        {

            return View();
        }


        private bool DiseasesExists(int id)
        {
            return _context.Diseases.Any(e => e.DiseasesID == id);
        }
    }
}
