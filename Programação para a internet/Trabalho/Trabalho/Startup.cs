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
            services.AddDbContext<TrabalhoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringTrabalhoLogins")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TrabalhoDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddTransient<IClientRepository, EFClientRepository>();
            services.AddTransient<IQuestionRepository, EFQuestionRepository>();
            services.AddTransient<IAnswerRepository, EFAnswerRepository>();
            services.AddTransient<IDiseasesRepository, EFDiseasesRepository>();
            services.AddTransient<IQue_DisRepository, EFQues_DisRepository>();
            services.AddTransient<IType_ClientRepository, EFType_ClientRepository>();
            services.AddTransient<ISur_QueRepository, EFSur_QueRepository>();
            services.AddTransient<ISurveyRepository, EFSurveyRepository>();
            services.AddTransient<IDifficultyRepository, EFDifficultyRepository>();
            services.AddTransient<ITrailsStatusRepository, EFTrailsStatusRepository>();
            services.AddTransient<IStatusRepository, EFStatusRepository>();
            services.AddTransient<ITra_AnRepository, EFTra_AnRepository>();
            services.AddTransient<IAns_QueRepository, EFAns_QueRepository>();
            services.AddTransient<ITrailsRepository, EFTrailsRepository>();


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
