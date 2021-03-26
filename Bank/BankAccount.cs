using System;

namespace BankAcountNS
{
    
    /// <summary>
    /// Bank account demo class
    /// </summary>
    /// <param name="args"></param>
        
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        public BankAccount()
        {

        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit( double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
                //Console.WriteLine("esto debería ser una exception");
            }

            m_balance -= amount; // a probar
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                // voy a agregar algunos comentarios
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(-11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance );
        }
    }    
}
