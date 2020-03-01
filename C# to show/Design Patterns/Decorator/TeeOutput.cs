using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    //writes to two streams at a time; the one it wraps, plus one it receives as a constructor argument
    public class TeeOutput : OutputDecorator
    {
        Output output;
        private List<string> fileNames = new List<string>();
        public TeeOutput(Output opout)
        {
            output = opout;
        }

        public override void Write(object a)
        {
            if (a.ToString() != "")
            {
                string file = fileNames.First();
                if (!File.Exists(file))
                {
                    using (StreamWriter writer = File.CreateText(file))
                    {
                        writer.WriteLine(a.ToString());
                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(file))
                    {
                        writer.WriteLine(a.ToString());
                    }
                }
                output.Write(a);
            }
        }
        public void AddFile(string name)
        {
            fileNames.Add(name);
        }

        public override void WriteString(string s)
        {
        }
    }
}