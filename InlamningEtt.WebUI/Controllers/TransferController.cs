using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InlamningEtt.WebUI.Data;
using InlamningEtt.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InlamningEtt.WebUI.Controllers
{
    public class TransferController : Controller
    {
        private IBankRepository repo;
        public TransferController(IBankRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var model = new TransactionViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = repo.Transfer(model.Transfer.TransferFrom, model.Transfer.TransferTo, model.Transfer.Amount);
                if (success)
                {
                    TempData["Message"] = $"Transfered {model.Transfer.Amount:C} from account #{model.Transfer.TransferFrom} to account #{model.Transfer.TransferTo}.";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["Error"] = $"An error occured with the transfer. Please check that the accounts and amount are correctly formatted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
