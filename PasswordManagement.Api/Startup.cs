using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PasswordManagement.Api.Mappers;
using PasswordManagement.Api.Repositories;
using PasswordManagement.Api.Repositories.Interfaces;
using PasswordManagement.Api.Resources;
using PasswordManagement.Api.Services;
using PasswordManagement.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManagement.Api
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
            services.AddDbContext<PasswordManagementContext>(opt => 
                opt.UseInMemoryDatabase(Configuration.GetConnectionString("MyDb")));

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IPasswordCardRepository, PasswordCardRepository>();
            services.AddTransient<IPasswordCardService, PasswordCardService>();
            
            services.AddScoped<IApiErrorResources, ApiErrorResources>();
            services.AddScoped<IPasswordCardServiceResources, PasswordCardServiceResources>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
