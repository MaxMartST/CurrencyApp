using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CurrencyApp.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CurrencyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            if (!memoryCache.TryGetValue("key_currency", out CurrencyConverter model))
            {
                throw new Exception("Ошибка получения данных");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
