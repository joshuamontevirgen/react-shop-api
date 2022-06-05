using Core.Payments.PaymentMethods.COD.Infrastructure;
using Core.Payments.PaymentMethods.Paymaya.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.Infrastructure
{
    public static class Startup
    {
        public static void AddPaymentMethods(this IServiceCollection services)
        {
            services.AddCOD();
            services.AddPaymaya();
        }
    }
}
