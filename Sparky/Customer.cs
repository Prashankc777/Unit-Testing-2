using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int Discount = 15;
        public string GreetMessage { get; set; } 


        public string GreetAndCombinedName(string firstName, string middleName, string lastName)
        {
            GreetMessage =  $"{firstName} {middleName} {lastName}";
            return GreetMessage;
        }

    }
}
