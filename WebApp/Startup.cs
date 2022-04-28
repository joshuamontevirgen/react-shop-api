using Core.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.DataGenerator;
using WebApplication3.Jwt;

namespace WebApplication3
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {

                builder.AllowAnyOrigin()//.WithOrigins("https://thankful-stone-0a2b60b00.1.azurestaticapps.net", "https://reactshop.itdcsystems.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();

            //jwt config
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SECRET)),
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddShopCore();
            services.Scan(scan =>
                    scan.FromCallingAssembly()
                        .AddClasses()
                        .AsMatchingInterface()
                        .WithTransientLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
         
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
    
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var scope = app.ApplicationServices.CreateScope();
            var generator = scope.ServiceProvider.GetRequiredService<ITestDataGenerator>();
            AddTestData(generator);
        }

        //https://stackoverflow.com/questions/67171224/entity-framework-core-use-in-memory-database-and-fill-with-fake-data
        private static void AddTestData(ITestDataGenerator testDataGenerator)
        {
            testDataGenerator.GenerateCategories();
            testDataGenerator.GenerateItems();
            testDataGenerator.GenerateUsers();
        }
    }
}
