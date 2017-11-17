using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho.Models;

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

        [HttpPost]
        public ViewResult Surveys(SurveysResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                return View("Thanks", response);
            }
            else
            {
                // There are validation errors
                return View();
            }
        }

        public ViewResult SurveysList()
        {
            return View(Repository.Responses.Where(r => r.Height < 180));
        }

        public IActionResult conditions()
        {
            return View();
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
