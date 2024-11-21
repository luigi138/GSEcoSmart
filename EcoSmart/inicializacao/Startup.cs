using EcoSmart.Persistencia;
using EcoSmart.Repository;
using EcoSmart.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EcoSmart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configure services in the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers
            services.AddControllers();

            // Add Swagger for API documentation
            services.AddSwaggerGen();

            // Configure database context
            services.AddDbContext<EcoSmartDbContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

            // Register dependencies for Dependency Injection
            services.AddScoped<IEnergyRecordRepository, EnergyRecordRepository>();
            services.AddScoped<IEnergyRecordService, EnergyRecordService>();
        }

        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable Swagger in development
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enforce HTTPS redirection
            app.UseHttpsRedirection();

            // Add routing middleware
            app.UseRouting();

            // Add authorization middleware
            app.UseAuthorization();

            // Map controller routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
