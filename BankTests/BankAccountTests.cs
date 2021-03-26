using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAcountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 12.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // Act 
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {

                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");

        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -12.55;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // Act 
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero()
        {
            // Arrange
            double beggingBalance = 11.99;
            double creditAmount = -10;
            BankAccount account = new BankAccount("yo", beggingBalance);

            try
            {
                // Act
                account.Credit(creditAmount);
            }
            catch (System.Exception e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");
        }
    }
}
