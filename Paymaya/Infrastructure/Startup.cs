using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Infrastructure
{
    public static class Startup
    {
        public static void AddPaymaya(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
    }
}
