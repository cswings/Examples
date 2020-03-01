using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public class Adapter : IShape
    {
        private readonly XXCircle circle;
        public Adapter(XXCircle _cir)
        {
            circle = _cir;
        }
        public void Display()
        {
            circle.DisplayIt();
        }

        public void Fill()
        {
            circle.FillIt();
        }
        
        public void SetColor(string color)
        {
            circle.SetItsColor(color);
        }
        
        public void SetLocation(string location)
        {
            circle.SetLocation(location);
        }

        public void UnDisplay()
        {
            circle.UnDisplayIt();
        }

        public void GetLocation()
        {
            circle.GetLocation();
        }
    }
}