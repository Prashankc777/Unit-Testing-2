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
        public int OrderTotal { get; set; }

        public bool IsPlatinum { get; set; } = false;


        public string GreetAndCombinedName(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First name");
            }
            GreetMessage =  $"{firstName} {middleName} {lastName}";
            return GreetMessage;
        }


        public CustomerType GetCustomerDetail()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }

            return new PlatinumCustomer(); 
        } 


        public class CustomerType
        {
            
            
        }
        public class BasicCustomer : CustomerType
        {
            

        }

        public class PlatinumCustomer : CustomerType
        {
            

        }



    }
}
