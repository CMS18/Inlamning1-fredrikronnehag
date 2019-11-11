using System.Collections.Generic;
using InlamningEtt.WebUI.Data.Entities;

namespace InlamningEtt.WebUI.Models
{
    public class HomeViewModel
    {
        public List<Customer> Customers = new List<Customer>();
        public List<Account> Accounts = new List<Account>();
    }
}
