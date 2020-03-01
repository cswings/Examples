using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program2
{
    public class Selections : LocalStocks, Display
    {
        private List<string> whichOnes = new List<string>();
        private Dictionary<string, string> check = new Dictionary<string, string>();
        private Subject stockData;
        private string[] those = { "ALL", "BA", "BC", "GBEL", "KFT", "MCD", "TR", "WAG" };
        //Selections.dat shows the observer beginning observation after the first snapshot, observing for two snapshots, and then going away
        //register after first update, then remove observer after two snapshots
        public Selections(Subject thing)
        {
            this.stockData = thing;
            stockData.registerObserver(this);
        }
        public void update(List<string> read)
        {
            select(read);
        }
        public void print()
        {
            //print to file
            string file = "Selections.dat";
            //first create the file, then append to it
            if (!File.Exists(file))
            {
                using (StreamWriter writer = File.CreateText(file))
                {
                    writer.WriteLine($"{whichOnes[0]}"); 
                   foreach(string select in those)
                    {
                        if (check.ContainsKey(select))
                        {
                            writer.WriteLine($"{check[select]}");
                        }
                    }
                    writer.WriteLine($"");
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(file))
                {
                    writer.WriteLine($"{whichOnes[0]}");
                    foreach (string select in those)
                    {
                        if (check.ContainsKey(select))
                        {
                            writer.WriteLine($"{check[select]}");
                        }
                    }
                    writer.WriteLine($"");
                }
            }
            whichOnes.Clear();
        }
        public void select(List<string> read)
        {
            foreach (string line in read)
            {
                var firstWord = line.IndexOf(" ") > -1
                    ? line.Substring(0, line.IndexOf(" "))
                    : line;
                if (firstWord != "Last")
                {
                    int where = 0;                   
                    int outter = 0;
                    string[] liner = line.Split(null);
                    
                    for (int i = 0; i < liner.Count(); i++)
                    {
                        foreach (char letter in liner[i])
                        {
                            if (Char.IsDigit(letter))
                            {
                                outter = 1;
                                break;
                            }

                        }
                        //find the ticker
                        if (outter == 1)
                        {
                            where = i - 1;
                            break;
                        }
                    }
                    
                    if (check.ContainsKey(liner[where]))
                    {
                        check[liner[where]] = line;
                    }
                    else
                    {
                        check.Add(liner[where], line);                       
                    }

                }
                else
                {
                    int lineBegin = line.IndexOf('S');
                    int lineEnd = line.IndexOf('E');
                    int length = lineEnd - lineBegin;
                    string lineFin = line.Substring(lineBegin, length);
                    whichOnes.Add(lineFin);
                }
            }
            print();
        }
    }
}