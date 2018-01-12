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
    public class TypeAnswersController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public TypeAnswersController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        // GET: TypeAnswers
        public async Task<IActionResult> Index()
        {
            var typeAnswer = _context.TypeAnswer.Include(t => t.Questions).AsNoTracking();
          
            return View(await typeAnswer.ToListAsync());
        }

        // GET: TypeAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnswer = await _context.TypeAnswer
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(m => m.TypeAnswerID == id);
            if (typeAnswer == null)
            {
                return NotFound();
            }

            return View(typeAnswer);
        }

        // GET: TypeAnswers/Create
        public IActionResult Create()
        {
            PopulateQuestionsDropDownList();
            return View();
        }

        // POST: TypeAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeAnswerID,PossibleAnswer,QuestionsID")] TypeAnswer typeAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateQuestionsDropDownList(typeAnswer.QuestionsID);
            return View(typeAnswer);
        }

        // GET: TypeAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnswer = await _context.TypeAnswer.AsNoTracking().SingleOrDefaultAsync(m => m.TypeAnswerID == id);
            if (typeAnswer == null)
            {
                return NotFound();
            }
            PopulateQuestionsDropDownList(typeAnswer.QuestionsID);
            return View(typeAnswer);
        }

        // POST: TypeAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnswerToUpdate = await _context.TypeAnswer
                .SingleOrDefaultAsync(t => t.TypeAnswerID == id);

            if (await TryUpdateModelAsync<TypeAnswer>(typeAnswerToUpdate,
                "", 
                t =>t    ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateQuestionsDropDownList(typeAnswerToUpdate.QuestionsID);
            return View(typeAnswerToUpdate);
        }


        private void PopulateQuestionsDropDownList(object selectedQuestions = null)
        {
            var questionsQuery = from q in _context.Questions
                                   orderby q.QuestionsToClient
                                   select q;
            ViewBag.QuestionsID = new SelectList(questionsQuery.AsNoTracking(), "QuestionsID", "QuestionsToClient", selectedQuestions);
        }


        // GET: TypeAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAnswer = await _context.TypeAnswer
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(m => m.TypeAnswerID == id);
            if (typeAnswer == null)
            {
                return NotFound();
            }

            return View(typeAnswer);
        }

        // POST: TypeAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeAnswer = await _context.TypeAnswer.SingleOrDefaultAsync(m => m.TypeAnswerID == id);
            _context.TypeAnswer.Remove(typeAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TypeAnswerExists(int id)
        {
            return _context.TypeAnswer.Any(e => e.TypeAnswerID == id);
        }
    }
}
