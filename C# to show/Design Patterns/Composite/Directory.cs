using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program9
{
    public class Directory : Component
    {
        string name;
        int line;
        List<Component> directoryComponents = new List<Component>();
        public Directory(string name, int line)
        {
            this.name = name;
            this.line = line;
        }
        public override void Add(Component component)
        {
            directoryComponents.Add(component);
        }
        public override int GetLine()
        {
            return line;
        }
        public string GetName()
        {
            return name;
        }

        public override string Operation()
        {
            int i = 0;
            string result = "";
            foreach (Component comp in directoryComponents)
            {
                result += comp.Operation();
                if(i != directoryComponents.Count - 1)
                {
                    result += "+";
                }
                i++;
            }
            return result;
        }
    }
}