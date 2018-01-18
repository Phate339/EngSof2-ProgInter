using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Models;

namespace Trabalho.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";
            const string teacherName = "alan";
            const string teacherPass = adminPass;
            const string turistName = "john";
            const string turistPass = adminPass;


            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("Professor"))
            {
                await roleManager.CreateAsync(new IdentityRole("Professor"));
            }

            if (!await roleManager.RoleExistsAsync("Turista"))
            {
                await roleManager.CreateAsync(new IdentityRole("Turista"));
            }

            // Create other roles ...

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminName };
                await userManager.CreateAsync(admin, adminPass);
            }

            if (!await userManager.IsInRoleAsync(admin, "Admin"))
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            ApplicationUser teacher = await userManager.FindByNameAsync(teacherName);
            if (teacher == null)
            {
                teacher = new ApplicationUser { UserName = teacherName };
                await userManager.CreateAsync(teacher, teacherPass);
            }

            if (!await userManager.IsInRoleAsync(teacher, "Professor"))
            {
                await userManager.AddToRoleAsync(teacher, "Professor");
            }


            ApplicationUser turist = await userManager.FindByNameAsync(turistName);
            if (turist == null)
            {
                turist = new ApplicationUser { UserName = turistName };
                await userManager.CreateAsync(turist, turistPass);
            }

            if (!await userManager.IsInRoleAsync(turist, "Turista"))
            {
                await userManager.AddToRoleAsync(turist, "Turista");
            }


        }
    }
}
