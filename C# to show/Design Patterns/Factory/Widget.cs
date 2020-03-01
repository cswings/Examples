using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    /// The 'ConcreteFactory1' class
    public class Widget : Resolution
    {
        
        public void Draw()
        {
            Console.Write("Drawing a Widget ");
        }
        public override Print PrintChoice()
        {
            new Document().Print();
            return new LowResPrintDriver();
        }
        public override Display DisplayChoice()
        {
            Draw();
            return new LowResDisplayDriver();
        }

       
    }
}