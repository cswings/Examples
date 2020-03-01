using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    public abstract class OutputDecorator : Output
    {
        protected Output _output;
       
        public abstract void Write(Object a);
        public abstract void WriteString(string s);
    }
}