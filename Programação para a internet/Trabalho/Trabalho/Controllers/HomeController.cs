using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Trabalho.Models.ViewModels;

namespace Trabalho.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public HomeController(TrabalhoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trabalhoDbContext = _context.Trails.Include(t=>t.Difficulty);

            return View(await trabalhoDbContext.ToListAsync());
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Surveys()
        {
            return View();
        }

     

        public IActionResult conditions()
        {
            return View();
        }

        /*
        private ISurveyRepository repository;
      

        public HomeController(ISurveyRepository repository)
        {
            this.repository = repository;
        }
        
        public ViewResult SurveysList()
        {
            return View(
                new SurveysListViewModels
                {
                    Survey = repository.Survey,
                      

                }
            );
        }*/
            
            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
