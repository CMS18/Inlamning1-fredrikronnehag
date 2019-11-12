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
                var success = _bankRepository.Deposit(model.Deposit.AccountID, model.Deposit.Amount);
                if (success)
                {
                    TempData["Message"] = $"Deposited {model.Deposit.Amount:C} to account #{model.Deposit.AccountID}.";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["Error"] = $"An error occured with the deposit. Please check that the account number and amount are correctly formatted.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = _bankRepository.Withdraw(model.Withdraw.AccountID, model.Withdraw.Amount);
                if (success)
                {
                    TempData["Message"] = $"Withdrew {model.Withdraw.Amount:C} from account #{model.Withdraw.AccountID}.";
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error"] = $"Insufficient funds.";
            }
            else
            {
                TempData["Error"] = $"An error occured with the deposit. Please check that the account number and amount are correctly formatted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}