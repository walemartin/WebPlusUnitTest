
using WebPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlus.Data;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebPlus.Tests
{
    
    public class HomeControllerTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Add(100);

            // ASSERT
            Assert.Equals(1100, account.Balance);
        }

        [Fact]
        public void Adding_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

        [Fact]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Withdraw(100);

            // ASSERT
            Assert.Equals(900, account.Balance);
        }

        [Fact]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdrawing_More_Than_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Fact]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var account = new BankAccount(1000);
            var otherAccount = new BankAccount();

            // ACT
            account.TransferFundsTo(otherAccount, 500);

            // ASSERT
            Assert.Equals(500, account.Balance);
            Assert.Equals(500, otherAccount.Balance);
        }

        [Fact]
        public void TransferFundsTo_Non_Existing_Account_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}