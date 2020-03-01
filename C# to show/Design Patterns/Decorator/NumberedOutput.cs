using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    //this adds newlines, and precedes each write with the current line number (1-based) right-justified in a field of width 5, followed by a colon and a space.
    public class NumberedOutput : OutputDecorator
    {
        Output output;
        private int lineCount = 0;
        public NumberedOutput(Output opout)
        {
            output = opout;
        }

        public override void Write(object a)
        {
            lineCount++;
            if(a.ToString() != "")
            {
                //precedes each write with the current line number (1-based) 
                //right -justified in a field of width 5, followed by a colon and a space
                string num = lineCount.ToString();
                string just = String.Format("{0,5}: ", num);
                output.Write(just+a+"\n");
            }    
            
        }

        public override void WriteString(string s)
        {
        }
    }
}