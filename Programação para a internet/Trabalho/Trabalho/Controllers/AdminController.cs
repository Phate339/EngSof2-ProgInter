using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IUserValidator<ApplicationUser> userValidator;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;

        public AdminController(UserManager<ApplicationUser> userManager,
            IUserValidator<ApplicationUser> userValid,
            IPasswordValidator<ApplicationUser> passValid,
            IPasswordHasher<ApplicationUser> passwordHash
            
            )
        {
            this.userManager = userManager;
           userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash; 

        }



        public IActionResult Index(string searchString)
        {

            ViewData["CurrentFilter"] = searchString;
            var turist = from s in userManager.Users
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                turist = turist.Where(s => s.Email.Contains(searchString));
            }

            return View( turist.ToList());
        }



        // GET: Turists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turist = await userManager.FindByIdAsync(id);
            if (turist == null)
            {
                return NotFound();
            }

            return View(turist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Utilizador não encontrado");

            }
            return View("Index", userManager.Users);


        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,string userName,string email,string password)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);

                }

                user.UserName = userName;
                IdentityResult validUserName = await userValidator.ValidateAsync(userManager, user);
                if (!validUserName.Succeeded)
                {
                    AddErrorsFromResult(validUserName);

                }

            

                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);

                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded)){
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }

                }

            }
            else
            {
                ModelState.AddModelError("", "Utilizador nao encontrado!");
            }

            return View(user);





        }


        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }

    }
}
