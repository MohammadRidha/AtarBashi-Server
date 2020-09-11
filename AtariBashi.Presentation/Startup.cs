
using AtarBashi.Common.Helpers;
using AtarBashi.Data.DataBaseContext;
using AtarBashi.Data.Infrastructure;
using AtarBashi.Services.Seed.Interface;
using AtarBashi.Services.Seed.Service;
using AtarBashi.Services.Site.Admin.Auth.Interfaces;
using AtarBashi.Services.Site.Admin.Auth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Net;
using System.Text;


namespace AtariBashi.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });

            services.AddOpenApiDocument(
              document =>
              {
                  document.DocumentName = "Site";
                  document.ApiGroupNames = new[] { "Site" };
                  document.PostProcess = d =>
                  {
                      d.Info.Title = "Document AtarBashi";
                  };
                  document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                  {
                      Type = OpenApiSecuritySchemeType.ApiKey,
                      Name = "Authorization",
                      In = OpenApiSecurityApiKeyLocation.Header,
                      Description = "Type into the textbox: Bearer {your JWT token}."
                  });
                  document.OperationProcessors.Add(
                       new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                  // new OperationSecurityScopeProcessor("JWT"));
              });
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "Api";
                document.ApiGroupNames = new[] { "Api" };
            });

            services.AddCors();

            #region IOC

            services.AddTransient<ISeedService, SeedService>();
            services.AddScoped<IUnitOfWork<AtarBashiDbContext>, UnitOfWork<AtarBashiDbContext>>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedService seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddAppError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            // seed data
            // seeder.SeedUsers();

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            ///
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
