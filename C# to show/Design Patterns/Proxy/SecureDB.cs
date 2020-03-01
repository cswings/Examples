using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program11
{
    public class SecureDB : IDatabase //proxy
    {
        IDatabase db;
        IDatabase sdb;
        private string _user;
        private string _pass;
        bool authenticated = false;
        public SecureDB(IDatabase db, IDatabase pass) //need 2 parameters
        {
            this.db = db;
            sdb = pass;                  
            Console.WriteLine("Enter username: ");
            string user = Console.ReadLine();
            _user = user;
            Console.WriteLine("Enter password: ");
            string userpw = Console.ReadLine();
            _pass = userpw;
           
        }
        private void auth()
        {
            if (sdb.Get("username") != _user)
            {
                Console.WriteLine("Invalid username");
                Console.WriteLine("Program will now exit");
                Console.ReadKey();
                Environment.Exit(1);
            }
            if (sdb.Get("password") != _pass)
            {
                Console.WriteLine("Invalid password");
                Console.WriteLine("Program will now exit");
                Console.ReadKey();
                Environment.Exit(1);
            }
            authenticated = true;
        }

        public bool Exists(string key)
        {
            if(!authenticated)
            {
                auth();
            }
            return (db.Exists(key));
        }

        public string Get(string key)
        {
            if (!authenticated)
            {
                auth();
            }
            return db.Get(key);
        }
    }
}