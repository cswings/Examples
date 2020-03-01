using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class Receiver
    {     
        public string DataBaseKey { get; set; }
        public string DataBaseValue { get; set; }
        public Receiver(string key, string value)
        {
            DataBaseKey = key;
            DataBaseValue = value;
        }      
    }
}