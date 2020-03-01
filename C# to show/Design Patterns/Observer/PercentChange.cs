using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Program2
{
    public class PercentChange : LocalStocks, Display
    {
        private List<string> whichOnes = new List<string>();
        private Dictionary<string, Tuple<double, double>> check = new Dictionary<string, Tuple<double, double>>();
        private List<string> tenPercent = new List<string>();
        private Subject stockData;
        private int count = 0;
        public PercentChange(Subject thing)
        {
            this.stockData = thing;
            stockData.registerObserver(this);
        }
        public void update(List<string> read)
        {
            calculate(read);
        }
        public void print()
        {
            //print to file
            string file = "Change10.dat";
            //first create the file, then append to it
            if (!File.Exists(file))
            {
                using (StreamWriter writer = File.CreateText(file))
                {
                    writer.WriteLine($"{whichOnes[count - 1]}:");
                    for (int i = 0; i < tenPercent.Count(); i++)
                    {
                        writer.WriteLine($"{tenPercent[i]}");
                    }
                    writer.WriteLine("");
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(file))
                {
                    writer.WriteLine($"{whichOnes[count - 1]}:");
                    for (int i = 0; i < tenPercent.Count(); i++)
                    {
                        writer.WriteLine($"{tenPercent[i]}");
                    }
                    writer.WriteLine("");
                }
            }
            tenPercent.Clear();
        }
        public void calculate(List<string> read)
        {
            count++;
            
            //get the info, parse it, check whether or not any 10% changes have been made
            foreach (string line in read)
            {                
                var firstWord = line.IndexOf(" ") > -1
                    ? line.Substring(0, line.IndexOf(" "))
                    : line;
                if (firstWord != "Last")
                {
                    int where = 0;
                    int first = 0;
                    int second = 0;
                    int outter = 0;
                    string[] liner = line.Split(null);
                    //get index of blankspace and delete all other items after, they aren't important
                    var index = Array.IndexOf(liner, "");
                    var count = liner.Count();
                    var howFar = count - (index+2);
                    var myList = liner.ToList();
                    myList.RemoveRange(index+2, howFar);
                    liner = myList.ToArray();
                    for(int i = 0; i < liner.Count(); i++)
                    {
                        foreach(char letter in liner[i])
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
                            first = i;
                            second = i + 3;
                            break;
                        }
                    }

                    var nums = Tuple.Create(Double.Parse(liner[first]), Double.Parse(liner[second]));
                    if(check.ContainsKey(liner[where]))
                    {
                        double diff = Math.Abs((check[liner[where]].Item1 - nums.Item1) / check[liner[where]].Item1)*100;
                        //check if above 10
                        if(diff >= 10)
                        {
                            tenPercent.Add(liner[where] + " " + nums.Item1 + " " + nums.Item2);
                        }
                        check[liner[where]] = nums;                        
                    }
                    else
                    {
                        check.Add(liner[where], nums);
                        if (Math.Abs(nums.Item2) >= 10)
                        {
                            tenPercent.Add(liner[where] + " " + nums.Item1 + " " + nums.Item2);
                        }
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
            if(count > 0)
            {
                print();
            }

        }
    }
}