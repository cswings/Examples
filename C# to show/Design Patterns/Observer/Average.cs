using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Program2
{
    public class Average : LocalStocks, Display
    {
        private List<double> toAverage = new List<double>();
        private List<double> averages = new List<double>();
        private List<string> lastUpdate = new List<string>();
        private Subject stockData;


        public Average(Subject thing)
        {
            this.stockData = thing;
            stockData.registerObserver(this);
        }
        public void update(List<string> read)
        {

            getData(read);
        }
        public void print()
        {
            //print to file
            string file = "Average.dat";
            //first create the file, then append to it
            if (!File.Exists(file))
            {
                using (StreamWriter writer = File.CreateText(file))
                {
                    for (int i = 0; i < averages.Count(); i++)
                    {
                        writer.WriteLine($"{lastUpdate[i]}, Average Price: {averages[i]}");
                    }
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(file))
                {
                    for (int i = 0; i < averages.Count(); i++)
                    {
                        writer.WriteLine($"{lastUpdate[i]}, Average Price: {averages[i]}");
                    }
                }
            }
            averages.Clear();
            lastUpdate.Clear();
        }

        internal void getData(List<string> read)
        {
            
            //get first number
            foreach(string line in read)
            {
               
                string numToFind = "";
                var firstWord = line.IndexOf(" ") > -1
                    ? line.Substring(0, line.IndexOf(" "))
                    : line;
                if (firstWord != "Last")
                {
                    foreach (char letter in line)
                    {
                        //check for digit
                        if (Char.IsDigit(letter) || (letter == '.' && numToFind.Count() > 0))
                        {
                            numToFind += letter;
                        }
                        if (Char.IsWhiteSpace(letter) && numToFind.Count() > 0)
                        {
                            //done with this line
                            toAverage.Add(Double.Parse(numToFind));
                            break;
                        }
                    }
                }
                else
                {
                    //get only date and time
                    //first line is lastUpdate
                    int lineBegin = line.IndexOf('S');
                    int lineEnd = line.IndexOf('E');
                    int length = lineEnd - lineBegin;
                    string lineFin = line.Substring(lineBegin, length);
                    lastUpdate.Add(lineFin);
                }                               
            }
            averages.Add(toAverage.Average());
            toAverage.Clear();
            //display 
            print();
        }
    }
}