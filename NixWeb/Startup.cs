using FluentValidation;
using FluentValidation.AspNetCore;
using Helpers;
using Helpers.ObjectMapers;
using Helpers.Validators;
using Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.UI;
using ModelsUI;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NixWeb
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
            services.AddDbContext<Context>(
            options => options.UseSqlServer(Configuration.GetConnectionString("MainConnection")), ServiceLifetime.Transient);

            services.AddScoped<IRepository<User>, EntityRepository<User>>();
            services.AddScoped<IRepository<Course>, EntityRepository<Course>>();
            services.AddScoped<IRepository<Role>, EntityRepository<Role>>();
            services.AddScoped<IRepository<Material>, EntityRepository<Material>>();
            services.AddScoped<IRepository<Video>, EntityRepository<Video>>();
            services.AddScoped<IRepository<Article>, EntityRepository<Article>>();
            services.AddScoped<IRepository<Book>, EntityRepository<Book>>();
            services.AddScoped<IRepository<Skill>, EntityRepository<Skill>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddSingleton<Interfaces.IValidator<User>, UserValidator>();
            services.AddSingleton<Interfaces.IValidator<CourseUI>, CourseValidator>();
            services.AddSingleton<Interfaces.IValidator<BookUI>, BookValidator>();
            services.AddSingleton<Interfaces.IValidator<ArticleUI>, ArticleValidator>();
            services.AddSingleton<Interfaces.IValidator<VideoUI>, VideoValidator>();
            services.AddSingleton<IPasswordHasher, Helpers.MD5Hasher>();
            services.AddSingleton<IMaper<List<string>, List<Author>>, ListString_ListAuthors_Maper>();
            services.AddSingleton<IMaper<List<AuthorUI>, List<Author>>, ListAuthorUI_ListAuthor_Maper>();
            services.AddSingleton<IMaper<VideoUI, Video>, VideoUI_Video_Maper>();
            services.AddSingleton<IMaper<BookUI, Book>, BookUI_Book_Maper>();
            services.AddSingleton<IMaper<ArticleUI, Article>, ArticleUI_Article_Maper>();
            services.AddSingleton<IMaper<Video, VideoUI>, Video_VideoUI_Maper>();
            services.AddSingleton<IMaper<Book, BookUI>, Book_BookUI_Maper>();
            services.AddSingleton<IMaper<Article, ArticleUI>, Article_ArticleUI_Maper>();
            services.AddSingleton<IMaper<CourseUI, Course>, CourseUI_Course_Maper>();
            services.AddSingleton<IMaper<Course, CourseUI>, Course_CourseUI_Maper>();
            services.AddSingleton<IMaper<List<Course>, List<CourseUI>>, ListCourse_ListCourseUI_Maper>();
            services.AddSingleton<IMaper<List<Material>, List<VideoUI>>, ListMaterial_ListVideoUI_Maper>();
            services.AddSingleton<IMaper<List<Material>, List<ArticleUI>>, ListMaterial_ListArticleUI_Maper>(); 
            services.AddSingleton<IMaper<List<Material>, List<BookUI>>, ListMaterial_ListBookUI_Maper>();
            services.AddSingleton<IMaper<Skill, SkillUI>, Skill_SkillUI_Maper>();
            services.AddSingleton<IMaper<List<Skill>, List<SkillUI>>, ListSkill_ListSkillUI_Maper>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(options =>
                     {
                         options.RequireHttpsMetadata = false;
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidIssuer = AuthOptions.ISSUER,
                             ValidateAudience = true,
                             ValidAudience = AuthOptions.AUDIENCE,
                             ValidateLifetime = true,
                             IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                             ValidateIssuerSigningKey = true,
                         };
                     });

            services.AddAuthorization(/*opt =>
            {
                opt.AddPolicy("Authorized", policy =>
                {
                    policy.RequireClaim("Role", "Default");
                });
            }*/); 


            services.AddControllers();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
