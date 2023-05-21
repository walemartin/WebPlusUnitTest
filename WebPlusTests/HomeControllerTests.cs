
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
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Adding_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Add(100);

            // ASSERT
            Assert.AreEqual(1100, account.Balance);
        }

        [TestMethod]
        public void Adding_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

        [TestMethod]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Withdraw(100);

            // ASSERT
            Assert.AreEqual(900, account.Balance);
        }

        [TestMethod]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [TestMethod]
        public void Withdrawing_More_Than_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [TestMethod]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var account = new BankAccount(1000);
            var otherAccount = new BankAccount();

            // ACT
            account.TransferFundsTo(otherAccount, 500);

            // ASSERT
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, otherAccount.Balance);
        }

        [TestMethod]
        public void TransferFundsTo_Non_Existing_Account_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}