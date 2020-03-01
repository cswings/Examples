using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    public class StockData : Subject
    {
        private List<LocalStocks> observers; //list of observers
        private int counter = 0;
        //data
        private List<string> holder = new List<string>();


        public StockData()
        {
            observers = new List<LocalStocks>();
        }

        public void registerObserver(LocalStocks l)
        {
            observers.Add(l);
        }
        public void removeObserver(LocalStocks l)
        {
            var i = observers.IndexOf(l);
            if (i >= 0)
            {
                observers.RemoveAt(i);
            }
        }
        public void notifyObservers()
        {
            foreach (LocalStocks obs in observers)
            {
                if(counter < 2)
                {
                    var it = obs.GetType();
                    if(it.Name!="Selections")
                    {
                        obs.update(holder);
                    }
                }
                else
                {
                    obs.update(holder);
                }
                
            }
        }
        public void dataUpdated()
        {
            notifyObservers();
        }
        public void farmData(List<string> dat)
        {
            counter++;
            holder = dat;
            dataUpdated();
        }

    }
}