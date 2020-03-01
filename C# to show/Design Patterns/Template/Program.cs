using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program8
{
    class Program
    {
        static void Main(string[] args)
        {
            string visa_cc_1 = "4111111111111111";
            string visa_cc_2 = "4222222222222";
            string visa_cc_3 = "4012888888881881";
            string diner_cc_1 = "30569309025904";
            string diner_cc_2 = "38520000023237";
            string master_cc_1 = "5555555555554444";
            string master_cc_2 = "5105105105105100";
            int month1 = 2;
            int month2 = 12;
            int year1 = 19;
            int year2 = 20;
            Console.WriteLine("Visa Card Info:");
            Console.WriteLine($"{visa_cc_1} {month2}/{year1}");
            CreditCard visa1 = new VisaCard(visa_cc_1, month2, year1);
            if(visa1.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine($"{visa_cc_2} {month1}/{year2}");
            CreditCard visa2 = new VisaCard(visa_cc_2, month1, year2);
            if(visa2.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine($"{visa_cc_3} {month2}/{year2}");
            CreditCard visa3 = new VisaCard(visa_cc_3, month2, year2);
            if(visa3.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine("");
            Console.WriteLine("Diners Card Info:");
            Console.WriteLine($"{diner_cc_1} {month2}/{year1}");
            CreditCard diner1 = new DinersCard(diner_cc_1, month2, year1);
            if(diner1.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine($"{diner_cc_2} {month2}/{year2}");
            CreditCard diner2 = new DinersCard(diner_cc_2, month2, year2);
            if(diner2.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine("");
            Console.WriteLine("MasterCard Info:");
            Console.WriteLine($"{master_cc_1} {month2}/{year1}");
            CreditCard master1 = new MasterCard(master_cc_1, month2, year1);
            if(master1.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.WriteLine($"{master_cc_2} {month1}/{year1}");
            CreditCard master2 = new MasterCard(master_cc_2, month1, year1);
            if(master2.IsValid())
            {
                Console.WriteLine("Valid!");
            }
            Console.ReadKey();

        }
    }
}
