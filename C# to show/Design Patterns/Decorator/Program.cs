using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "";
            char choice = ' ';
            char filter = ' ';
            string name = "";
            string line;
            List<char> totalChoices = new List<char>();

            Console.WriteLine("Please enter a file to read.");
            file = Console.ReadLine();
            while (!File.Exists(file))
            {
                Console.WriteLine("File not found, please enter a file to read.");
                file = Console.ReadLine();
            }
            Console.WriteLine("File found!");
            Console.WriteLine("");
            Console.WriteLine("The following decorators can be applied to the output of this file:");
            Console.WriteLine("\t1. LineOutput");
            Console.WriteLine("\t2. NumberedOutput");
            Console.WriteLine("\t3. TeeOuput");
            Console.WriteLine("\t4. FilterOutput");
            Console.WriteLine("");
            Console.WriteLine("Please select a combination of decorators one at a time, enter s to stop");
            choice = Console.ReadKey().KeyChar;
            
            using (StreamWriter outputFile = File.CreateText("output.txt"))
            {
                Output oput = new StreamOutput(outputFile);
                while (choice != 's')
                {
                    while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != 's')
                    {
                        Console.WriteLine(" Incorrect choice! Try again!");
                        choice = Console.ReadKey().KeyChar;
                    }
                    if (choice == 's')
                    {
                        break;
                    }
                    switch (choice)
                    {
                        case '1':
                            oput = new LineOutput(oput);
                            totalChoices.Add(choice);
                            break;
                        case '2':
                            oput = new NumberedOutput(oput);
                            totalChoices.Add(choice);
                            break;
                        case '3':                            
                            totalChoices.Add(choice);
                            Console.WriteLine("");
                            Console.WriteLine("Please provide a name for the output file for TeeOutput: ");
                            name = Console.ReadLine();
                            //check for extension, add .txt
                            string ext = Path.GetExtension(name);
                            if (ext == "")
                            {
                                name = name + ".txt";
                            }
                            var bb = new TeeOutput(oput);
                            bb.AddFile(name);
                            oput = bb;                            
                            break;
                        case '4':                   
                            
                            totalChoices.Add(choice);
                            Console.WriteLine("");
                            Console.WriteLine("Please choose one filter: ");
                            //display at least 2 predicates to choose from
                            Console.WriteLine(" 1. ContainsDigit  2. ContainsPeriod");
                            filter = Console.ReadKey().KeyChar;
                            while (filter != '1' && filter != '2')
                            {
                                Console.WriteLine(" Incorrect choice! Try again!");
                                filter = Console.ReadKey().KeyChar;
                            }
                            if(filter == '1')
                            {
                                var cc = new FilterOutput(oput);
                                cc.ContainsDigit();
                                oput = cc;
                                
                            }
                            else
                            {
                                var oo = new FilterOutput(oput);
                                oo.ContainsPeriod();
                                oput = oo;
                            }
                            break;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Your choices so far: ");
                    foreach (char it in totalChoices)
                    {
                        Console.Write(it + " ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Please select another decorator, enter s to stop");
                    choice = Console.ReadKey().KeyChar;
                }
                //use readIn and apply decorators to each line
                Console.WriteLine("");
                //open file and read into list
                StreamReader read = new StreamReader(file);
                while ((line = read.ReadLine()) != null)
                {               
                    oput.Write(line);
                }
            }
        }
    }
}
