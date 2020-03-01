using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program7
{
    public interface IShape
    {
        void SetLocation(string location);
        void UnDisplay();
        void GetLocation();
        void Display();
        void Fill();
        void SetColor(string color);
    }
}