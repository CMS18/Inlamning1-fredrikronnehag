using InlamningEtt.WebUI.Data;
using InlamningEtt.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InlamningEtt.WebUI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IBankRepository _bankRepository;

        public TransactionController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var model = new TransactionViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO
            }

            return RedirectToAction(nameof(Index));
        }
    }
}