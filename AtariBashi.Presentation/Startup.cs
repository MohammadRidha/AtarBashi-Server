using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AtariBashi.Presentation
{
    public class Startup
    {
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();


            services.AddScoped<IUnitOfWork<AtarBashiDbContext>, UnitOfWork<AtarBashiDbContext>>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
