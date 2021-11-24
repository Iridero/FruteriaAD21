using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FruteriaAD21.Services;
namespace FruteriaAD21
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CategoriasService>();
            string connectionString = Configuration.GetConnectionString("DefaultConnectio");
            services.AddDbContext<fruteriashopContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddMvc(
                options => options.EnableEndpointRouting = false
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
