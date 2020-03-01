using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class EndCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Ending a Macro");
        }

        public void UnExecute()
        {
            Console.WriteLine("Begin Undoing Macro");
            Console.WriteLine("");
        }
    }
}