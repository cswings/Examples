using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program4
{
    /// The 'AbstractFactory' abstract class
    public abstract class Resolution
    {
        public abstract Display DisplayChoice();
        public abstract Print PrintChoice();
    }
}