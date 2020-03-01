using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    //adds a newline with every write
    public class LineOutput : OutputDecorator
    {
        Output output;
        public LineOutput(Output opout)
        {
            output = opout;
        }


        public override void Write(object a)
        {
            if (a.ToString() != "")
            {
                output.Write(a+"\n");
            }
        }

        public override void WriteString(string s)
        {
        }
    }
}