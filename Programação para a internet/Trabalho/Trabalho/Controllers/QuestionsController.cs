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

        public async Task<IActionResult> Index(int? id, int? Type_AnswerID, int? DiseasesID)
        {
            var viewModel = new QuestionListViewModel();
            viewModel.Question = await _context.Question
                  .Include(i => i.Ans_For_Que)
                  .ThenInclude(i=>i.Type_Answer).Include(i => i.Que_Dis).ThenInclude(i=>i.Diseases)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["QuestionID"] = id.Value;
                Question question = viewModel.Question.Where(
                    i => i.QuestionID == id.Value).Single();
                viewModel.Type_Answer = question.Ans_For_Que.Select(s => s.Type_Answer);
                viewModel.Diseases = question.Que_Dis.Select(s => s.Diseases);
           
            }

            if (Type_AnswerID != null)
            {
                ViewData["Type_AnswerID"] = Type_AnswerID.Value;
                var selectedType_Answer= viewModel.Type_Answer.Where(x => x.Type_AnswerID == Type_AnswerID).Single(); 
            }

            if (DiseasesID != null)
            {
                ViewData["DiseasesID"] = DiseasesID.Value;
                var selectedDiseasesID = viewModel.Diseases.Where(x => x.DiseasesID == DiseasesID).Single();
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

            var question = new Question();
            question.Ans_For_Que = new List<Ans_For_Que>();
            PopulateAssignedType_AnswerData(question);

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionID,QuestionToClient,QuestionState")] Question question, string[] selectedType_Answer)
        {

            if (selectedType_Answer != null)
            {
                question.Ans_For_Que = new List<Ans_For_Que>();
                foreach (var type_answer in selectedType_Answer)
                {
                    var type_answerToAdd = new Ans_For_Que { QuestionID = question.QuestionID, Type_AnswerID = int.Parse(type_answer) };
                    question.Ans_For_Que.Add(type_answerToAdd);
                }
            }



            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }



            Select_YN_Rebind();
            PopulateAssignedType_AnswerData(question);
            return View(question);
        }

        // GET: Questions/Create
        public IActionResult CreateDis()
        {
            Select_YN_Rebind();

            var question = new Question();
            question.Que_Dis= new List<Que_Dis>();
            PopulateAssignedDiseasesData(question);

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDis([Bind("QuestionID,QuestionToClient,QuestionState")] Question question, string[] selectedDiseases)
        {

            if (selectedDiseases != null)
            {
                question.Que_Dis = new List<Que_Dis>();
                foreach (var diseases in selectedDiseases)
                {
                    var diseasesToAdd = new Que_Dis { QuestionID = question.QuestionID, DiseasesID = int.Parse(diseases) };
                    question.Que_Dis.Add(diseasesToAdd);
                }
            }



            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }



            Select_YN_Rebind();
            PopulateAssignedDiseasesData(question);
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

            var question = await _context.Question.Include(i=>i.Ans_For_Que).ThenInclude(i=>i.Type_Answer).SingleOrDefaultAsync(m => m.QuestionID == id);
            if (question == null)
            {
                return NotFound();
            }

            PopulateAssignedType_AnswerData(question);
            return View(question);
        }

        private void PopulateAssignedType_AnswerData(Question question)
        {
            var allType_Answer = _context.Type_Answer;
            var QuestionType_Answer = new HashSet<int>(question.Ans_For_Que.Select(c => c.Type_AnswerID));
            var viewModel = new List<CreateQuestionType_AnswerViewModel>();
            foreach (var type_answer in allType_Answer)
            {
                viewModel.Add(new CreateQuestionType_AnswerViewModel
                {
                    Type_AnswerID = type_answer.Type_AnswerID,
                    PossibleAnswer = type_answer.PossibleAnswer,
                    Assigned = QuestionType_Answer.Contains(type_answer.Type_AnswerID)
                });
            }
            ViewData["Type_Answer"] = viewModel;
        }

        private void PopulateAssignedDiseasesData(Question question)
        {
            var allDiseases= _context.Diseases;
            var QuestionDiseases = new HashSet<int>(question.Que_Dis.Select(c => c.DiseasesID));
            var viewModel = new List<CreateQuestionDiseasesViewModel>();
            foreach (var diseases in allDiseases)
            {
                viewModel.Add(new CreateQuestionDiseasesViewModel
                {
                    DiseasesID = diseases.DiseasesID,
                    DiseasesName = diseases.DiseasesName,
                    Assigned = QuestionDiseases.Contains(diseases.DiseasesID)
                });
            }
            ViewData["Diseases"] = viewModel;
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionToUpdate = await _context.Question
                .Include(i => i.Ans_For_Que)
                    .ThenInclude(i => i.Type_Answer)
                .SingleOrDefaultAsync(m => m.QuestionID == id);

            if (await TryUpdateModelAsync<Question>(
                questionToUpdate,
                "",
                i => i.QuestionToClient, i => i.QuestionState))
            {

                UpdateQuestionType_Answer(selectedCourses, questionToUpdate);
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
            UpdateQuestionType_Answer(selectedCourses, questionToUpdate);
            PopulateAssignedType_AnswerData(questionToUpdate);
            return View(questionToUpdate);
        }


        private void UpdateQuestionType_Answer(string[] selectedType_Answer, Question questionToUpdate)
        {
            if (selectedType_Answer == null)
            {
               questionToUpdate.Ans_For_Que = new List<Ans_For_Que>();
                return;
            }

            var selectedType_AnswerHS = new HashSet<string>(selectedType_Answer);
            var questionType_Answer = new HashSet<int>
                (questionToUpdate.Ans_For_Que.Select(c => c.Type_Answer.Type_AnswerID));
            foreach (var type_answer in _context.Type_Answer)
            {
                if (selectedType_AnswerHS.Contains(type_answer.Type_AnswerID.ToString()))
                {
                    if (!questionType_Answer.Contains(type_answer.Type_AnswerID))
                    {
                       questionToUpdate.Ans_For_Que.Add(new Ans_For_Que { QuestionID = questionToUpdate.QuestionID, Type_AnswerID = type_answer.Type_AnswerID });
                    }
                }
                else
                {

                    if (questionType_Answer.Contains(type_answer.Type_AnswerID))
                    {
                        Ans_For_Que type_answerToRemove = questionToUpdate.Ans_For_Que.SingleOrDefault(i => i.Type_AnswerID == type_answer.Type_AnswerID);
                        _context.Remove(type_answerToRemove);
                    }
                }
            }
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDis(int? id, string[] selectedDiseases)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionToUpdate = await _context.Question
                .Include(i => i.Que_Dis)
                    .ThenInclude(i => i.Diseases)
                .SingleOrDefaultAsync(m => m.QuestionID == id);

            if (await TryUpdateModelAsync<Question>(
                questionToUpdate,
                "",
                i => i.QuestionToClient, i => i.QuestionState))
            {

                UpdateQuestionDiseases(selectedDiseases, questionToUpdate);
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
            UpdateQuestionDiseases(selectedDiseases, questionToUpdate);
            PopulateAssignedDiseasesData(questionToUpdate);
            return View(questionToUpdate);
        }


        private void UpdateQuestionDiseases(string[] selectedDiseases, Question questionToUpdate)
        {
            if (selectedDiseases == null)
            {
                questionToUpdate.Que_Dis = new List<Que_Dis>();
                return;
            }

            var selectedDiseasesHS = new HashSet<string>(selectedDiseases);
            var questionDiseases = new HashSet<int>
                (questionToUpdate.Que_Dis.Select(c => c.Diseases.DiseasesID));
            foreach (var diseases in _context.Diseases)
            {
                if (selectedDiseasesHS.Contains(diseases.DiseasesID.ToString()))
                {
                    if (!questionDiseases.Contains(diseases.DiseasesID))
                    {
                        questionToUpdate.Que_Dis.Add(new Que_Dis { QuestionID = questionToUpdate.QuestionID, DiseasesID = diseases.DiseasesID });
                    }
                }
                else
                {

                    if (questionDiseases.Contains(diseases.DiseasesID))
                    {
                        Que_Dis diseasesToRemove = questionToUpdate.Que_Dis.SingleOrDefault(i => i.DiseasesID == diseases.DiseasesID);
                        _context.Remove(diseasesToRemove);
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
            Question question = await _context.Question
                .Include(i => i.Ans_For_Que)
                .SingleAsync(i => i.QuestionID == id);

            _context.Question.Remove(question);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
