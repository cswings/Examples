using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public class Line : IShape
    {
        private string loc;
        public void Display()
        {
            Console.WriteLine("Line is displayed");
        }

        public void Fill()
        {
            Console.WriteLine("Line is filled");
        }

        public void SetColor(string color)
        {
            Console.WriteLine($"Line's color is now {color}");
        }

        public void SetLocation(string location)
        {
            loc = location;
            Console.WriteLine($"Line's location is set at {location}");
        }

        public void UnDisplay()
        {
            Console.WriteLine("Line is no longer displayed");
        }

        public void GetLocation()
        {
            Console.WriteLine($"Line's location is {loc}");
        }
    }
}