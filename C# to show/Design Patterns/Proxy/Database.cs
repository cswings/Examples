using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program11
{
    public class Database : IDatabase
    {
        private StreamReader read;
        private string line;
        private string _file;
        public Database(string file)
        {
            if(!File.Exists(file))
            {
                Console.WriteLine("File not found");
                return;
            }
            _file = file;            
            //The database id is the file name. Use it to open the file, and keep the file open for the life of the object.
            //Each time you try to access the data via get() or exists(), go to the file (don’t read in all the data at first and store it in the object).
        }

        public bool Exists(string key)
        {
            read = new StreamReader(_file);
            while ((line = read.ReadLine()) != null)
            {
                if (line.Contains(key))
                {
                    return true;
                }
            }
            return false;       
        }

        public string Get(string key)
        {
            read = new StreamReader(_file);
            string value = "";
            //Whenever a user calls get(key), the value for that key is returned (throw an exception if it’s not in the file). 
            while((line = read.ReadLine())!= null)
            {
                if(line.Contains(key))
                {
                    string[] words = line.Split();
                    if(words.Length > 1)
                    {
                        value = string.Join(" ", words.Skip(1));
                        break;
                    }
                }
            }
            if(line == null)
            {
                return "No such record: " + key;
            }
            return value;
        }
    }
}