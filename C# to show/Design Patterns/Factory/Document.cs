using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    /// The 'ConcreteFactory2' class
    public class Document : Resolution
    {
        
        public void Print()
        {
            Console.Write("Printing a Document ");
        }
        public override Print PrintChoice()
        {
            Print();
            return new HighResPrintDriver();
        }
        public override Display DisplayChoice()
        {
            new Widget().Draw();
            return new HighResDisplayDriver();
        }
    }
}