using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program7
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape rec = new Rectangle();
            IShape point = new Point();
            IShape line = new Line();
            XXCircle adaptee = new XXCircle();
            IShape cir = new Adapter(adaptee);
            rec.Display();
            point.Display();
            line.Display();
            cir.Display();
            Console.WriteLine("");
            rec.SetLocation("top right");            
            point.SetLocation("top left");            
            line.SetLocation("bottom left");            
            cir.SetLocation("bottom right");
            Console.WriteLine("");
            rec.SetColor("blue");
            point.SetColor("red");
            line.SetColor("yellow");
            cir.SetColor("black");
            Console.WriteLine("");
            rec.GetLocation();
            point.GetLocation();
            line.GetLocation();
            cir.GetLocation();
            Console.WriteLine("");
            rec.UnDisplay();
            point.UnDisplay();
            line.UnDisplay();
            cir.UnDisplay();

            Console.ReadKey();
        }
    }
}
