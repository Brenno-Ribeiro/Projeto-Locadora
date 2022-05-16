using MovieStore.AutoMapper;
using MovieStore.Context;
using MovieStore.Repositories;
using MovieStore.Repositories.Interfaces;
using MovieStore.Services;
using MovieStore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace MovieStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // AUTOMAPPER
            services.AddAutoMapper(typeof(ViewModelToDomain));
            services.AddAutoMapper(typeof(DomainToViewModel));

            services.AddCors();

            services.AddDbContext<LocadoraContext>(options =>
            {   
                options.UseNpgsql(Configuration.GetConnectionString("locadoraPostgres"));
            });
        
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Store", Version = "v1" });
            });

            // INJE��ES DE DEPEND�NCIAS
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<ICloudinaryAppService, CloudinaryAppService>();
            services.AddScoped<IMovieAppService, MovieAppService>();
            services.AddScoped<IDirectorAppService, DirectorAppService>();
            services.AddScoped<IImageAppService, ImageAppService>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LocadoraContext context)
        {

            app.UseCors(cors => 
            {
                cors.WithOrigins("http://localhost:3000","http://localhost:8000");
                cors.AllowAnyMethod();
                cors.AllowAnyHeader();
            });


            if(env.IsProduction())
            {
                Console.WriteLine("==========================================");
                Console.WriteLine(" ESTOU EM PRODUÇÃO - MOVIE-STORE-BACK-END ");
                Console.WriteLine("==========================================");     
                context.Database.Migrate();   
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStore] v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
