using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
     /// The 'AbstractProductB' abstract class
    public interface Print
    {
        string UsefulFunctionB();
        string AnotherUsefulFunctionB(Display collaborator);
    }
}