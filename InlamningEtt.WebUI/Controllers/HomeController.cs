using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InlamningEtt.WebUI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InlamningEtt.WebUI.Models;

namespace InlamningEtt.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBankRepository _bankRepository;

        public HomeController(ILogger<HomeController> logger, IBankRepository bankRepository)
        {
            _logger = logger;
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Accounts = _bankRepository.GetAccounts().ToList(),
                Customers = _bankRepository.GetCustomers().ToList()
            };

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
