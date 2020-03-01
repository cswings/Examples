using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class BeginCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Beginning a Macro");
        }

        public void UnExecute()
        {
            Console.WriteLine("End Undoing Macro");
            Console.WriteLine("");
        }
    }
}