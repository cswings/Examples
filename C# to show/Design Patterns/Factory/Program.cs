using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "DocumentToRead.txt";
            string line;
            if(!File.Exists(file))
            {
                Console.WriteLine("Error, file not found");
                return;
            }
            StreamReader read = new StreamReader(file);
            while ((line = read.ReadLine()) != null)
            {
                if(line == "high")
                {
                    new Driver().Client(new Document());
                }
                else if (line == "low")
                {
                    new Driver().Client(new Widget());
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
