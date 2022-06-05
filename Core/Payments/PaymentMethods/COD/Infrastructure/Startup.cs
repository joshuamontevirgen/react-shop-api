using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Payments.PaymentMethods.COD.Infrastructure
{
    public static class Startup
    {
        public static void AddCOD(this IServiceCollection services)
        {
            services.AddScoped<ICODPaymentMethod, CODPaymentProcessor>();
        }
    }
}
