using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Paymaya.Models.Webhooks;

namespace Paymaya.Infrastructure
{
    internal class RouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            foreach (var eventName in Webhook.EventNames)
            {
                endpointRouteBuilder.MapControllerRoute(
                    $"Paymaya.Webhook.{eventName}",
                    $"Paymaya/Webhook/{eventName}",
                    new { controller = "Webhook", action = eventName }
                );
            }
        }
    }
}
