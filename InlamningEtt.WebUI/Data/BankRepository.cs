using System.Collections.Generic;
using InlamningEtt.WebUI.Data.Entities;

namespace InlamningEtt.WebUI.Data
{
    public interface IBankRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Account> GetAccounts();
        void Withdraw(int accountId, decimal amount);
        void Deposit(int accountId, decimal amount);

    }

    public class BankRepository : IBankRepository
    {
        private static List<Customer> _customers = new List<Customer>
        {
            new Customer {Id = 123, Name = "Lars Bengtsson"},
            new Customer {Id = 1234, Name = "Erik Eriksson"},
            new Customer {Id = 12345, AccountId = 32, Name = "Anna Svensson"},
        };

        private static List<Account> _accounts = new List<Account>
        {
            new Account {Balance = 5000M, CustomerId = 123, Id = 20},
            new Account {Balance = 5200M, CustomerId = 1234, Id = 25},
            new Account {Balance = 5820M, CustomerId = 1234, Id = 26},
            new Account {Balance = 5300M, CustomerId = 12345, Id = 32},
        };

        public IEnumerable<Customer> GetCustomers() => _customers;

        public IEnumerable<Account> GetAccounts() => _accounts;

        public void Withdraw(int accountId, decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public void Deposit(int accountId, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
