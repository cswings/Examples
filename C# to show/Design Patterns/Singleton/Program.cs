using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program5
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 0;
            string fullName = "";
            Console.WriteLine("Enter a name for the insurance policy, enter q to quit.");
            fullName = Console.ReadLine();
            if (fullName != "q" && !fullName.ToCharArray().Any(char.IsDigit))
            {
                while (true)
                {
                    id++;
                    Policy person = Policy.GetInstance();
                    person.SetId(id);
                    person.SetName(fullName);
                    person.SavePolicy();
                    Console.WriteLine("Enter a name for the insurance policy, enter q to quit.");
                    fullName = Console.ReadLine();
                    while (String.IsNullOrEmpty(fullName) || fullName.ToCharArray().Any(char.IsDigit))
                    {
                        Console.WriteLine("Enter a correct name for the insurance policy, enter q to quit.");
                        fullName = Console.ReadLine();
                    }
                    if ( fullName == "q" )
                    {
                        //print all policies and end
                        Console.WriteLine("Current Policy:");
                        Console.WriteLine($"{person.GetDescription()}");
                        Console.WriteLine("Current Policy Holders:");
                        Console.WriteLine("ID:\tName:");
                        foreach(var thing in person.policies)
                        {
                            Console.WriteLine($"{thing.Key}\t{thing.Value}");
                        }
                        Console.ReadKey();
                        return;
                    }                   
                }
            }

        }
    }
}
