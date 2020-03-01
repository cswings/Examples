﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    /// The 'ProductB2' class
    public class HighResPrintDriver : Print
    {
        public string AnotherUsefulFunctionB(Display collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            return $"{result}";
        }

        public string UsefulFunctionB()
        {
            return "using a HighResPrintDriver";
        }
    }
}