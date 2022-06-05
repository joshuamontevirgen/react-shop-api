using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya.Infrastructure
{
    public static class Startup
    {
        public static void AddPaymaya(this IServiceCollection services)
        {
            //https://stackoverflow.com/questions/39174989/how-to-register-multiple-implementations-of-the-same-interface-in-asp-net-core
            services.AddScoped<IPaymayaPaymentMethod, PaymayaPaymentProcessor>();           
            //services.Scan(scan =>
            //    scan.FromCallingAssembly()
            //        .AddClasses()
            //        .AsMatchingInterface()
            //        .WithTransientLifetime());
        }
    }
}
