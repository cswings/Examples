using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program9
{
    public abstract class Component
    {
        // lists the entries in the current directory horizontally
        public void List()
        {

        }
        public abstract int GetLine();

        public abstract string Operation();

        //	prints a hierarchical listing of the current directory subtree (starting from the current node)
        public void Listall()
        {

        }

        //	changes directory to the named, adjacent subdirectory
        public void Chdir(string directory)
        {

        }

        public virtual void Add(Component dir)
        {

        }
 
        //	moves up the tree to the parent (like cd ..)
        public void Up()
        {

        }

        //	prints the number of files (not directories) in the current directory
        public void Count()
        {

        }

        //	prints the number of files (not directories) in the subtree starting from the current node
        public void Countall()
        {

        }

        //	quit the program
        public void Q()
        {

        }

        public void GetChild()
        {
            throw new System.NotImplementedException();
        }
    }
}