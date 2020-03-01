using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program11
{
    public interface IDatabase
    {
        bool Exists(string key);
        string Get(string key);
    }
}