using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{

    public interface IlogBook
    {
        void Message(string message);

        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);

        string MessageWithReturnStr(string message);

        bool LogWithOutputResult(string str , out string outputStr);
      
    }

    public class LogBook : IlogBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            return balanceAfterWithdrawal >= 0;
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello" + str;
            return true;
        }

       
    }

    //public class LogFaker : IlogBook
    //{
    //    public void Message(string message)
    //    {
           
    //    }
    //}


}
