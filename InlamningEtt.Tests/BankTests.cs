using InlamningEtt.WebUI.Data;
using Xunit;

namespace InlamningEtt.Tests
{
    public class BankTests
    {
        [Fact]
        public void Withdraw_ValidAmount_BalanceShouldBeCorrect()
        {
            // Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(20);
            account.Balance = 5000M;
            const decimal withdraw = 500m;

            // Act
            var success = repo.Withdraw(account.Id, withdraw);

            // Assert
            Assert.True(success);
            Assert.Equal(4500M, account.Balance);
        }

        [Fact]
        public void Withdraw_InvalidAmount_BalanceShouldNotChange()
        {
            // Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(20);
            account.Balance = 5000M;
            const decimal withdraw = -500M;

            // Act
            var success = repo.Withdraw(account.Id, withdraw);

            // Assert
            Assert.False(success);
            Assert.Equal(5000M, account.Balance);
        }

        [Fact]
        public void Withdraw_MoreThanBalance_BalanceShouldNotChange()
        {
            // Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(20);
            account.Balance = 5000M;
            const decimal withdraw = 5001m;

            // Act
            var success = repo.Withdraw(account.Id, withdraw);

            // Assert
            Assert.False(success);
            Assert.Equal(5000M, account.Balance);
        }

        [Fact]
        public void Deposit_ValidAmount_BalanceShouldBeCorrect()
        {
            // Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(20);
            account.Balance = 5000M;
            const decimal deposit = 5000m;

            // Act
            var success = repo.Deposit(account.Id, deposit);

            // Assert
            Assert.True(success);
            Assert.Equal(10000M, account.Balance);
        }

        [Fact]
        public void Deposit_InvalidAmount_BalanceShouldNotChange()
        {
            // Arrange
            var repo = new BankRepository();
            var account = repo.GetAccount(20);
            account.Balance = 5000M;
            const decimal deposit = -5000m;

            // Act
            var success = repo.Deposit(account.Id, deposit);

            // Assert
            Assert.False(success);
            Assert.Equal(5000M, account.Balance);
        }
    }
}
