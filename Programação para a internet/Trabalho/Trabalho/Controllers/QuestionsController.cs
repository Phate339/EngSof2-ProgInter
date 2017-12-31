using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

using Trabalho.Models.ViewModels;

namespace Trabalho.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public QuestionsController(TrabalhoDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index(int? id, int? Type_AnswerID)
        {
            var viewModel = new QuestionListViewModel();
            viewModel.Question = await _context.Question
                  .Include(i => i.Ans_For_Que)
                  .ThenInclude(i=>i.Type_Answer)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["QuestionID"] = id.Value;
                Question question = viewModel.Question.Where(
                    i => i.QuestionID == id.Value).Single();
                viewModel.Type_Answer = question.Ans_For_Que.Select(s => s.Type_Answer);
            }

            if (Type_AnswerID != null)
            {
                ViewData["Type_AnswerID"] = Type_AnswerID.Value;
                var selectedType_Answer= viewModel.Type_Answer.Where(x => x.Type_AnswerID == Type_AnswerID).Single(); 
            }

            return View(viewModel);
        }




        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .SingleOrDefaultAsync(m => m.QuestionID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            Select_YN_Rebind();
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionID,QuestionToClient,QuestionState")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewDieasesYesOrNo");
            }



            Select_YN_Rebind();
            return View(question);
        }

        private void Select_YN_Rebind()
        {
            List<SelectListItem> Select_YN = new List<SelectListItem>();
            Select_YN.Add(new SelectListItem
            {
                Text = "Select"

            });
            Select_YN.Add(new SelectListItem
            {
                Text = "No",
                Value = bool.FalseString
            });
            Select_YN.Add(new SelectListItem
            {
                Text = "Yes",
                Value = bool.TrueString
            });
            ViewData["Select_YN"] = Select_YN;
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionID == id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionID,QuestionToClient,QuestionState")] Question question)
        {
            if (id != question.QuestionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionID))
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
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .SingleOrDefaultAsync(m => m.QuestionID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionID == id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult ViewDieasesYesOrNo()
        {

            return View();
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionID == id);
        }
    }
}
