using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public class XXCircle
    {
        private string loc;
        public void SetLocation(string location)
        {
            loc = location;
            Console.WriteLine($"Circle's location is set at {location}");
        }

        public void GetLocation()
        {
            Console.WriteLine($"Circle's location is {loc}");
        }

        public void DisplayIt()
        {
            Console.WriteLine("Circle is now displayed");
        }

        public void FillIt()
        {
            Console.WriteLine("Circle is filled");
        }

        public void SetItsColor(string color)
        {
            Console.WriteLine($"Circle's color is now {color}");
        }

        public void UnDisplayIt()
        {
            Console.WriteLine("Circle is no longer displayed");
        }
    }
}