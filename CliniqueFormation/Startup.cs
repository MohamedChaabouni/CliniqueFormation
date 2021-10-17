using Data;
using Data.Interfaces;
using Domains.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CliniqueFormation
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
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddScoped<IDbRepository, DbRepository>()
                .AddScoped<IRendezVousService, RendezVousService>();

            // AddScoped        -- Scope : request [Request: create, Destroy: Response]
            // AddSingleton     -- Scope : [web app Startup: create, destroy: web app Finish]
            // AddTransition    -- Scope : [Chaque appel : create, destroy: fin d'utilisation : GC (Garbage collection)]

            //var interfaceMarker = typeof(IInterfaceMarker).Assembly;
            //var implementationMarker = typeof(IServiceImplementationMarker).Assembly;

            //var interfaces = interfaceMarker.GetTypes();
            //var implementations = implementationMarker.GetTypes();

            //foreach (var implementation in implementations)
            //{
            //    // interface, implentation
            //    var _interface = implementation.GetInterfaces().FirstOrDefault();
            //    // name convetion
            //    //var _interface = interfaces.FirstOrDefault(x => x.Name == $"I{implementation.Name}");
            //    if (_interface != null)
            //    {
            //        services.AddScoped(_interface, implementation);
            //    }
            //}

            services.AddAutoMapper(typeof(IProfileAssemblyMarker).Assembly);
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
