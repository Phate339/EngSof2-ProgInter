using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trabalho.Models;
using Trabalho.Services;
using Trabalho.Data;

namespace Trabalho
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<TrabalhoUsersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringTrabalhoUsers")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TrabalhoDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddTransient<IQuestionRepository, EFQuestionRepository>();
            services.AddTransient<IDiseasesRepository, EFDiseasesRepository>();
            services.AddTransient<IQue_DisRepository, EFQues_DisRepository>();
            services.AddTransient<ISurveyRepository, EFSurveyRepository>();
            services.AddTransient<IDifficultyRepository, EFDifficultyRepository>();
            services.AddTransient<ITrailsRepository, EFTrailsRepository>();
            services.AddTransient<ITuristRepository, EFTuristRepository>();
            services.AddTransient<IType_AnswerRepository, EFType_AnswerRepository>();
            services.AddTransient<IAns_For_QueRepository, EFAns_For_QueRepository>();
            services.AddTransient<ITra_SurRepository, EFTra_SurRepository>();

            services.AddDbContext<TrabalhoDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("ConnectionStringTrabalho")
                )
            );

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
