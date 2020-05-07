using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Repositories;
using ContosoUniversity.Repositories.Implements;
using ContosoUniversity.Services;
using ContosoUniversity.Services.Implements;
using AutoMapper;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;

namespace ContosoUniversity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddDbContext<SchoolContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));

            //Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();

            //Services
            services.AddScoped<ICourseService, CourseService>();


            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Services
            services.AddScoped<IStudentService, StudentService>();

            //Services Enrollment
            services.AddScoped<IEnrollmentService, EnrollmentService>();

            //Repositories Enrollment
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            //automapper 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //REPOSOTORIES PARCIAL
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IOfficeAssignmentRepository, OfficeAssignmentRepository>();



            //SERVICES PARCIAL
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IOfficeAssignmentService, OfficeAssignmentService>();


            //services.AddAutoMapper(options =>
            //{
            //    options.CreateMap<StudentDTO, Student>();

            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}