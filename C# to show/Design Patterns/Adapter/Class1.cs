using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public class Rectangle : IShape
    {
        private string loc;
        public void Display()
        {
            Console.WriteLine("Rectangle is displayed");
        }

        public void Fill()
        {
            Console.WriteLine("Rectangle is filled");
        }

        public void SetColor(string color)
        {
            Console.WriteLine($"Rectangle's color is now {color}");
        }

        public void SetLocation(string location)
        {
            loc = location;
            Console.WriteLine($"Rectangle's location is set at {location}");
        }

        public void UnDisplay()
        {
            Console.WriteLine("Rectangle is no longer displayed");
        }

        public void GetLocation()
        {
            Console.WriteLine($"Rectangle's location is {loc}");
        }
    }
}