﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Services
{
    public interface IWebhookHandlerService
    {
        Task HandleWebhookAsync(HttpRequest request);
    }
}
