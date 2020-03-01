using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program9
{
    class Program
    {
        static void Main(string[] args)
        {
            //read in file
            string[] lines = File.ReadAllLines("directory.dat");
            int linecount = 0;
            Component top = new Directory("top", linecount);
            int countSpaces = 0;
            List<Component> filesToSort = new List<Component>();
            List<Component> dirToSort = new List<Component>();
            dirToSort.Add(top);
            //create directory            
            foreach (string line in lines)
            {
                //subdirectories are indicated by series of three spaces.
                countSpaces = line.Count(Char.IsWhiteSpace);               
                if (line.Contains(":"))
                {
                    string linez = line.Replace(" ", "");
                    Component dir = new Directory(linez, countSpaces);
                    dirToSort.Add(dir);
                    top.Add(dir);
                }
                else
                {
                    string linef = line.Replace(" ", "");
                    Component fil = new Files(linef, countSpaces);
                    filesToSort.Add(fil);
                    top.Add(fil);
                }
            }
            for (int i = 0; i < dirToSort.Count(); i--)
            {
                foreach (string line in lines)
                {
                    countSpaces = line.Count(Char.IsWhiteSpace);
                    if (line.Contains(":"))
                    {
                        i++;
                    }
                    else
                    {
                        if (countSpaces <= (dirToSort[i].GetLine() - 3))
                        {
                            string linef = line.Replace(" ", "");
                            Component fil = new Files(linef, countSpaces);
                            dirToSort[i].Add(fil);
                        }
                        else
                        {
                            i--;
                            string linef = line.Replace(" ", "");
                            Component fil = new Files(linef, countSpaces);
                            dirToSort[i].Add(fil);
                        }
                    }
                }
            }
            //foreach(var fold in dirToSort)
            //{
            //    int a = fold.GetLine();

            //    foreach (var page in filesToSort)
            //    {
            //        int b = page.GetLine();
            //        if (b - a == 3)
            //        {
            //            fold.Add(page);                  

            //        }
            //        else
            //        {

            //        }
            //    }
            //    filesToSort.RemoveAll(i => i.GetLine() == 3);
            //}

            //get user input
            //perform commands


        }
    }
}
