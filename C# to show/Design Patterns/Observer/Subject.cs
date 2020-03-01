using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    public interface Subject
    {

        void registerObserver(LocalStocks d);
        void removeObserver(LocalStocks d);
        void notifyObservers();
    }
}