using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;
using Trabalho.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Trabalho.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public QuestionsController(TrabalhoDbContext context)
        {
            _context = context;    
        }

    
        // GET: Questions
        public async Task<IActionResult> Index()
        {
          

            return View(await _context.Questions.Include(a=>a.Answer).ThenInclude(d=>d.Difficulty).ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .SingleOrDefaultAsync(m => m.QuestionsID == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }



        // GET: Questions/Create
        public IActionResult Create()
        {

            Select_YN_Rebind();
            var questions = new Questions();
            questions.Answer = new List<Answer>();
            PopulateAssignedDifficultyData(questions);

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionsID,QuestionsToClient,QuestionsState")] Questions questions, string[] selectedDifficulty)
        {


            if (selectedDifficulty != null)
            {
                questions.Answer = new List<Answer>();
                foreach (var difficulty in selectedDifficulty)
                {
                    var difficultyToAdd = new Answer { QuestionsID = questions.QuestionsID, DifficultyID = int.Parse(difficulty) };
                    questions.Answer.Add(difficultyToAdd);
                }
            }


            if (ModelState.IsValid)
            {
                _context.Add(questions);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            Select_YN_Rebind();
            PopulateAssignedDifficultyData(questions);
            return View(questions);
        }

        private void Select_YN_Rebind()
        {
            List<SelectListItem> Select_YN = new List<SelectListItem>();
            Select_YN.Add(new SelectListItem
            {
                Text = "Selecione"

            });
            Select_YN.Add(new SelectListItem
            {
                Text = "Desativar",
                Value = bool.FalseString
            });
            Select_YN.Add(new SelectListItem
            {
                Text = "Ativar",
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

            var questions = await _context.Questions.Include(a=>a.Answer).ThenInclude(d=>d.Difficulty).SingleOrDefaultAsync(m => m.QuestionsID == id);
            if (questions == null)
            {
                return NotFound();
            }
            PopulateAssignedDifficultyData(questions);
            return View(questions);
        }

        private void PopulateAssignedDifficultyData(Questions questions)
        {
            var allDifficulty = _context.Difficulty;
            var QuestionDifficulty = new HashSet<int>(questions.Answer.Select(c => c.DifficultyID));
            var viewModel = new List<DifficultyViewModel>();
            foreach (var difficulty in allDifficulty)
            {
                viewModel.Add(new DifficultyViewModel
                {
                    DifficultyID = difficulty.DifficultyID,
                    DifficultyName = difficulty.DifficultyName,
                    Assigned = QuestionDifficulty.Contains(difficulty.DifficultyID)
                });
            }
            ViewData["Difficulty"] = viewModel;
        }
        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedDifficulty)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsToUpdate = await _context.Questions
                .Include(i => i.Answer)
                    .ThenInclude(i => i.Difficulty)
                .SingleOrDefaultAsync(m => m.QuestionsID == id);

            if (await TryUpdateModelAsync<Questions>(
                questionsToUpdate,
                "",
                i => i.QuestionsToClient, i => i.QuestionsState))
            {

                UpdateQuestionType_Answer(selectedDifficulty, questionsToUpdate);
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
            UpdateQuestionType_Answer(selectedDifficulty, questionsToUpdate);
            PopulateAssignedDifficultyData(questionsToUpdate);
            return View(questionsToUpdate);
        }


        private void UpdateQuestionType_Answer(string[] selectedDifficulty, Questions questionsToUpdate)
        {
            if (selectedDifficulty == null)
            {
                questionsToUpdate.Answer = new List<Answer>();
                return;
            }

            var selectedDifficultyHS = new HashSet<string>(selectedDifficulty);
            var questionsDifficulty = new HashSet<int>
                (questionsToUpdate.Answer.Select(c => c.Difficulty.DifficultyID));
            foreach (var difficulty in _context.Difficulty)
            {
                if (selectedDifficultyHS.Contains(difficulty.DifficultyID.ToString()))
                {
                    if (!questionsDifficulty.Contains(difficulty.DifficultyID))
                    {
                        questionsToUpdate.Answer.Add(new Answer { QuestionsID = questionsToUpdate.QuestionsID, DifficultyID = difficulty.DifficultyID });
                    }
                }
                else
                {

                    if (questionsDifficulty.Contains(difficulty.DifficultyID))
                    {
                        Answer difficultyToRemove = questionsToUpdate.Answer.SingleOrDefault(i => i.DifficultyID == difficulty.DifficultyID);
                        _context.Remove(difficultyToRemove);
                    }
                }
            }
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                .SingleOrDefaultAsync(m => m.QuestionsID == id);
            if (questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questions = await _context.Questions.SingleOrDefaultAsync(m => m.QuestionsID == id);
            _context.Questions.Remove(questions);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QuestionsExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionsID == id);
        }
    }
}
