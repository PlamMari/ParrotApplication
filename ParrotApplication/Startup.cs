using ParrotsApplication.Data;
using ParrotsApplication.Models.Mappers;
using ParrotsApplication.Repositories;
using ParrotsApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace ParrotsApplication
{
    public class Startup
    {
        public Startup(IConfiguration Config)
        {
            this.Config = Config;
        }
        public IConfiguration Config { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "Beer Management API",                    
                });
            });
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //EF
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Config.GetConnectionString("DefaultConnection")));
            //IoC
            // Repositories
            services.AddScoped<IParrotsRepository, ParrotsRepository>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            // Services
            services.AddScoped<IParrotsService, ParrotsService>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            // Helpers
            services.AddTransient<ParrotMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            });
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
