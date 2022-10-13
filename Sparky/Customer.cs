using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public string GreetAndCombinedName(string firstName, string middleName, string lastName)
        {
            return $"{firstName} {middleName} {lastName}";
        }

    }
}
