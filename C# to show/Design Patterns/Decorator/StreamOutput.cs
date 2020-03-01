using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    public class StreamOutput : Output
    {
        //class contains a reference to an output stream, and its write method expects a streamable argument 
        //(something that can be inserted into a C++ stream (via <<) or that has a toString method in Java – these are in the files that accompany this Zip file
        private StreamWriter sink;

        public StreamOutput(StreamWriter stream)
        {
            sink = stream;
        }
      

        public  void Write(object a)
        {
            WriteString(a.ToString());
        }

        public  void WriteString(string s)
        {
            if (s != "")
            {
                sink.Write(s);
            }
        }
    }
}