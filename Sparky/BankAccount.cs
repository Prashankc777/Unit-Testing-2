using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; } = 0;


        public bool Deposit(int amount)
        {
            Balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            return amount <= Balance ? true : false;
        }


        public int GetCurrentBalance(int amount)
        {
            return Balance;
        }
    }
}
