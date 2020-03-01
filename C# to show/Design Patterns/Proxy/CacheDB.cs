using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program11
{
    public class CacheDB : IDatabase //proxy
    {
        private IDatabase db;
        private List<string> cache = new List<string>();
        public CacheDB(IDatabase db) //db object
        {
            this.db = db;
        }

        public bool Exists(string key)
        {
            //first check cache
            if(cache.Contains(key))
            {
                Console.WriteLine($"found key {key} in cache");
            }
            return db.Exists(key);
        }

        public string Get(string key)
        {
            string what = db.Get(key);
            if (!what.Contains("No"))
            {
                if (cache.Count < 5)
                {
                    cache.Add(key);
                }
                else
                {
                    cache.RemoveAt(0);
                    cache.Add(key);
                }
            }
            return what;           
        }

        public void Inspect() //returns the keys in the cache in order
        {
            Console.WriteLine("Cache contents: ");
            foreach(string thing in cache)
            {
                Console.Write($"[{thing}], ");
            }
            Console.WriteLine("");
        }
    }
}