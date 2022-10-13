using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private readonly IlogBook _logBook;
        public int Balance { get; set; } = 0;

        public BankAccount(IlogBook logBook)
        {
            _logBook = logBook;
        }


        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit");
            Balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if (amount <= Balance)
            {
                _logBook.LogToDb("WithDrawal Account" + amount.ToString());
                Balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(Balance);
            }

            return _logBook.LogBalanceAfterWithdrawal(Balance-amount);
        }


        public int GetCurrentBalance()
        {
            return Balance;
        }
    }
}
