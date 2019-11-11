using System.Collections.Generic;
using InlamningEtt.WebUI.Data.Entities;

namespace InlamningEtt.WebUI.Data
{
    public interface IBankRepository
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Account> GetAccounts();
    }

    public class BankRepository : IBankRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 123, AccountId = 20,
                    Name = "Lars Bengtsson"
                },
                new Customer
                {
                    Id = 1234, AccountId = 25,
                    Name = "Erik Eriksson"
                },
                new Customer
                {
                    Id = 12345, AccountId = 32,
                    Name = "Anna Svensson"
                },
            };
        }

        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account {Balance = 5000M, CustomerId = 123, Id = 20},
                new Account {Balance = 5200M, CustomerId = 1234, Id = 25},
                new Account {Balance = 5820M, CustomerId = 1234, Id = 26},
                new Account {Balance = 5300M, CustomerId = 12345, Id = 32},
            };
        }
    }
}
