using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    /// The 'Client' class 
    public class Driver
    {        
        public void Client(Resolution res)
        {                        
            var productB = res.PrintChoice(); //document
            Console.WriteLine(productB.UsefulFunctionB());
            var productA = res.DisplayChoice(); //widget
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }
}