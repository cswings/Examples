using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public class Point : IShape
    {
        private string loc;
        public void Display()
        {
            Console.WriteLine("Point is displayed");
        }

        public void Fill()
        {
            Console.WriteLine("Point is filled");
        }

        public void SetColor(string color)
        {
            Console.WriteLine($"Point's color is now {color}");
        }

        public void SetLocation(string location)
        {
            loc = location;
            Console.WriteLine($"Point's location is set at {location}");
        }

        public void UnDisplay()
        {
            Console.WriteLine("Point is no longer displayed");
        }

        public void GetLocation()
        {
            Console.WriteLine($"Point's location is {loc}");
        }
    }
}