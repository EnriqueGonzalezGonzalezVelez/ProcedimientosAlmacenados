using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcedimientosAlmacenados.Models;
using ProcedimientosAlmacenados.Repositories;

namespace ProcedimientosAlmacenados
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            String cadenaPeliculas = this.configuration.GetConnectionString("CadenaPeliculas");

            services.AddDbContext<PeliculasContext>
                (options => options.UseSqlServer(cadenaPeliculas));

            services.AddTransient<RepositoryPeliculas>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Peliculas}/{action=Index}/{id?}");
            });
        }
    }
}
