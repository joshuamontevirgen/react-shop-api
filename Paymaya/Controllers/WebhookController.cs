using Microsoft.AspNetCore.Mvc;
using Paymaya.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Controllers
{
    internal class WebhookController : Controller
    {
        WebhookHandlerService _webhookHandlerService;
        public WebhookController(WebhookHandlerService webhookHandlerService)
        {
            _webhookHandlerService = webhookHandlerService;
        }
        [HttpPost]
        public async Task<IActionResult> CHECKOUT_SUCCESS()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> CHECKOUT_FAILURE()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> CHECKOUT_DROPOUT()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PAYMENT_SUCCESS()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PAYMENT_FAILED()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> PAYMENT_EXPIRED()
        {
            await _webhookHandlerService.HandleWebhookAsync(Request);
            return Ok();
        }
    }
}
