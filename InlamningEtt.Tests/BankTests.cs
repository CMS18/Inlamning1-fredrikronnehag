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

        }

        [Fact]
        public void Withdraw_MoreThanBalance_BalanceShouldNotChange()
        {

        }

        [Fact]
        public void Deposit_ValidAmount_BalanceShouldBeCorrect()
        {

        }

        [Fact]
        public void Deposit_InvalidAmount_BalanceShouldNotChange()
        {

        }
    }
}
