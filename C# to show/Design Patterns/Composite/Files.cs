using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program9
{
    public class Files : Component
    {
        string name;
        int line;
        
        public Files(string name, int line)
        {
            this.name = name;
            this.line = line;
        }

        public override int GetLine()
        {
            return line;
        }

        public override string Operation()
        {
            return "file";
        }

    }
}