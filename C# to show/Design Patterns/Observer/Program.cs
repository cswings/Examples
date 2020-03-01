using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> read = new List<string>();
            StockData stock = new StockData();
            Average avg = new Average(stock);
            Selections sel = new Selections(stock);
            PercentChange per = new PercentChange(stock);
            string textFile = "Ticker.dat";
            string line;
            int lineCount = 0;
            int count = 0;

            using (StreamReader file = new StreamReader(textFile))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        lineCount = 0;
                        read.Add(line);
                    }
                    else
                    {
                        count++;
                        lineCount++; 
                        if(count == 4)
                        {
                            stock.removeObserver(sel);
                        }
                        if (lineCount < 2)
                        {
                            stock.farmData(read);
                            read.Clear();
                        }
                    }
                }
                file.Close();
            }
        }
    }
}
