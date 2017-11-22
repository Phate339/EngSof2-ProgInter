using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;
using Trabalho.Models.ViewModels;

namespace Trabalho.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
        }
            
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
