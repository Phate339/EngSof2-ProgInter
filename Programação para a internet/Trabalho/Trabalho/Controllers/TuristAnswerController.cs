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
    public class TuristAnswerController : Controller
    {
        private readonly TrabalhoDbContext _context;

        public TuristAnswerController(TrabalhoDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
            {
                var question = _context.Questions.Include(t => t.TypeAnswer).AsNoTracking(); 

                var typeAnswer = _context.TypeAnswer.Include(t => t.Questions).AsNoTracking();

                return View(await typeAnswer.ToListAsync());
        }
    }
}