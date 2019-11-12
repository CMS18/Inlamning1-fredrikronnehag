using System.Collections.Generic;
using System.Linq;
using InlamningEtt.WebUI.Data.Entities;

namespace InlamningEtt.WebUI.Data
{
    public interface IBankRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int accountId);
        bool Withdraw(int accountId, decimal amount);
        bool Deposit(int accountId, decimal amount);
        bool Transfer(int fromAccount, int toAccount, decimal amount);

    }

    public class BankRepository : IBankRepository
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 123, Name = "Lars Bengtsson"},
            new Customer {Id = 1234, Name = "Erik Eriksson"},
            new Customer {Id = 12345, AccountId = 32, Name = "Anna Svensson"},
        };

        private static readonly List<Account> Accounts = new List<Account>
        {
            new Account {Balance = 5000M, CustomerId = 123, Id = 20},
            new Account {Balance = 5200M, CustomerId = 1234, Id = 25},
            new Account {Balance = 5820M, CustomerId = 1234, Id = 26},
            new Account {Balance = 5300M, CustomerId = 12345, Id = 32},
        };

        public Account GetAccount(int accountId) => Accounts.SingleOrDefault(a => a.Id == accountId);

        public IEnumerable<Customer> GetCustomers() => Customers;

        public IEnumerable<Account> GetAccounts() => Accounts;

        public bool Withdraw(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);
            if (account == null) return false;
            if (account.Balance - amount < 0 || amount <= 0) return false;
            account.Balance -= amount;
            return true;
        }

        public bool Deposit(int accountId, decimal amount)
        {
            var account = GetAccount(accountId);
            if (account == null || amount <= 0) return false;
            account.Balance += amount;
            return true;
        }

        public bool Transfer(int fromAccount, int toAccount, decimal amount)
        {
            var from = GetAccount(fromAccount);
            var to = GetAccount(toAccount);
            if (from == null || to == null || amount <= 0) return false;
            if (from.Balance - amount < 0 || amount <= 0) return false;
            to.Balance += amount;
            from.Balance -= amount;
            return true;
        }
    }
}
