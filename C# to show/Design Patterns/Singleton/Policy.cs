using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program5
{
    public class Policy
    {
        private static Policy _instance;
        private readonly string descrip = "Save 15% or more";
        private static readonly object _lockObj = new object();
        public Dictionary<int, string> policies = new Dictionary<int, string>();
        private string Name;
        private int Id;

        public static Policy GetInstance()
        {
            if (_instance == null)
            {
                lock (_lockObj)
                {

                    if (_instance == null)
                    {
                        _instance = new Policy();
                    };
                }
            }
            return _instance;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string update)
        {
            Name = update;
        }

        public string GetId()
        {
            return Id.ToString();
        }

        public void SetId(int toSet)
        {
            Id = toSet;
        }
        public void SavePolicy()
        {
            policies.Add(Id, Name);

        }
        public string GetDescription()
        {
            return descrip;
        }
 
    }
}
