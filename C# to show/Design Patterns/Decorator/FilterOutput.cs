using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program3
{
    //writes only those objects that satisfy a certain condition (unary predicate), received as a constructor parameter.
    public class FilterOutput : OutputDecorator
    {
        Output output;
        private bool digit;
        private bool period;
        public FilterOutput(Output opout)
        {
            output = opout;
        }
        public override void Write(object a)
        {
            if(digit == true)
            {
                //scan for digit             
                string holder = a.ToString();
                if(holder.Any(c => char.IsDigit(c)))
                {
                    output.Write(a);
                }
                
            }
            else if(period == true)
            {
                //scan for period               
                string holder = a.ToString();
                int index = holder.IndexOf('.');
                Console.WriteLine("");
                if (index != -1)
                {
                    output.Write(a);
                }            
                
            }
            
        }

        public static bool IsTuple(Type tuple)
        {
            if (!tuple.IsGenericType)
                return false;
            var openType = tuple.GetGenericTypeDefinition();
            return openType == typeof(Tuple<>)
                || openType == typeof(Tuple<,>)
                || openType == typeof(Tuple<,,>)
;
        }

        public void ContainsDigit()
        {
            digit = true;
        }
        public void ContainsPeriod()
        {
            period = true;
        }

        public override void WriteString(string s)
        {
        }
    }
}