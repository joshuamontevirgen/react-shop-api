using Core.Infrastructure;
using Core.Payments.Infrastructure;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.DataGenerators.Infrastructure;

namespace UnitTester
{
    internal class SetupDI
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;
        public SetupDI()
        {
            services = new ServiceCollection();
            services.AddShopCore();
            services.AddDataGenerators();
            services.AddPaymentMethods();
            serviceProvider = services.BuildServiceProvider();
        }
        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
