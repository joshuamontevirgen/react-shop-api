using Core.DB;
using Core.Services.Items;
using Core.Services.Users;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Items;
using Core.Domain.Users;
using Core.Domain;

namespace Core.Infrastructure
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2
    //https://ngohungphuc.wordpress.com/2018/05/01/generic-repository-pattern-in-asp-net-core/

    //https://www.c-sharpcorner.com/article/understanding-addtransient-vs-addscoped-vs-addsingleton-in-asp-net-core/
    public static class Startup
    {
        public static void AddShopCore(this IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(opt => opt.UseInMemoryDatabase(databaseName: "Test"));
            //scrutor
            services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithTransientLifetime());

        }
    }
}
